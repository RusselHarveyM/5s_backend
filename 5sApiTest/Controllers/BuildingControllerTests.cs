using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _5s.Controllers;
using _5s.Model;
using _5s.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace _5sApiTest.Controllers
{
    public class BuildingControllerTests
    {
        private readonly Mock<IBuildingService> _buildingServiceMock;
        private readonly BuildingController _buildingController;

        public BuildingControllerTests()
        {
            _buildingServiceMock = new Mock<IBuildingService>();
            _buildingController = new BuildingController(_buildingServiceMock.Object);
        }

        [Fact]
        public async Task CreateBuilding_ValidBuilding_ReturnsCreatedAtRouteResult()
        {
            // Arrange
            var building = new Building
            {
                Id = 1,
                BuildingName = "Gregorio L. Escario",
                BuildingCode = "GLE",
                Image = new byte[] { 0x12, 0x34, 0x56, 0x78 }
            };
            _buildingServiceMock.Setup(service => service.CreateBuilding(building)).ReturnsAsync(1);

            // Act
            var result = await _buildingController.CreateBuilding(building) as CreatedAtRouteResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status201Created, result.StatusCode);
            Assert.Equal("CreateBuilding", result.RouteName);
            Assert.Equal(1, result.RouteValues["id"]);
        }

        [Fact]
        public async Task CreateBuilding_InvalidBuilding_ReturnsInternalServerError()
        {
            // Arrange
            var building = new Building
            {
                // Invalid building data or missing required fields
            };
            _buildingServiceMock.Setup(service => service.CreateBuilding(building)).ThrowsAsync(new Exception("Invalid building"));

            // Act
            var result = await _buildingController.CreateBuilding(building) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result.StatusCode);
        }

    }
}
