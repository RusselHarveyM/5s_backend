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

        [Fact]
        public async Task GetBuilding_ReturnsBuildings()
        {
            // Arrange
            var buildings = new List<Building>
            {
                new Building { Id = 1, BuildingName = "Gregorio L. Escario", BuildingCode = "GLE" },
                new Building { Id = 2, BuildingName = "Nicholas Gregorio Escario", BuildingCode = "NGE" },
            };

            _buildingServiceMock.Setup(service => service.GetAllBuilding()).ReturnsAsync(buildings);
            var controller = new BuildingController(_buildingServiceMock.Object);

            // Act
            var result = await controller.GetBuilding() as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.Equal(buildings, result.Value);
        }

        [Fact]
        public async Task GetBuilding_NoBuildings_ReturnsNoContent()
        {
            // Arrange
            var emptyBuildingList = new List<Building>(); // Empty list
            _buildingServiceMock.Setup(service => service.GetAllBuilding()).ReturnsAsync(emptyBuildingList);
            var controller = new BuildingController(_buildingServiceMock.Object);

            // Act
            var result = await controller.GetBuilding() as StatusCodeResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status204NoContent, result.StatusCode);
        }

        [Fact]
        public async Task GetBuilding_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            _buildingServiceMock.Setup(service => service.GetAllBuilding()).ThrowsAsync(new Exception());
            var controller = new BuildingController(_buildingServiceMock.Object);

            // Act
            var result = await controller.GetBuilding();

            // Assert
            Assert.IsType<ObjectResult>(result);
            var statusCode = (result as ObjectResult)?.StatusCode;
            Assert.Equal(StatusCodes.Status500InternalServerError, statusCode);
        }

        [Fact]
        public async Task UpdateBuilding_ExistingBuilding_ReturnsOkResult()
        {
            // Arrange
            var buildingId = 1; // Replace with an existing building ID
            var existingBuilding = new Building { 
                Id = buildingId,
                BuildingName = "Gregorio L. Escario",
                BuildingCode = "NGE"
            };
            var updatedBuilding = new Building { 
                Id = buildingId,
                BuildingName = "Gregorio L. Escario",
                BuildingCode = "GLE" };

            _buildingServiceMock.Setup(service => service.GetBuildingById(buildingId)).ReturnsAsync(existingBuilding);
            _buildingServiceMock.Setup(service => service.UpdateBuilding(buildingId, updatedBuilding)).ReturnsAsync(1);

            var controller = new BuildingController(_buildingServiceMock.Object);

            // Act
            var result = await controller.UpdateBuilding(buildingId, updatedBuilding) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.Equal(1, result.Value);
        }

        [Fact]
        public async Task UpdateBuilding_NonExistingBuilding_ReturnsNotFound()
        {
            // Arrange
            var buildingId = 100; // Replace with a non-existing building ID
            var updatedBuilding = new Building { Id = buildingId, BuildingName = "Updated Building", BuildingCode = "ZZZ" };

            _buildingServiceMock.Setup(service => service.GetBuildingById(buildingId)).ReturnsAsync((Building)null);

            var controller = new BuildingController(_buildingServiceMock.Object);

            // Act
            var result = await controller.UpdateBuilding(buildingId, updatedBuilding) as StatusCodeResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status404NotFound, result.StatusCode);
        }

        [Fact]
        public async Task UpdateBuilding_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var buildingId = 1; // An existing building ID
            var updatedBuilding = new Building
            {
                Id = buildingId,
                BuildingName = "Updated Building",
                BuildingCode = "UB"
            };

            _buildingServiceMock.Setup(service => service.GetBuildingById(buildingId)).ReturnsAsync(new Building());
            _buildingServiceMock.Setup(service => service.UpdateBuilding(buildingId, updatedBuilding)).ThrowsAsync(new Exception());

            var controller = new BuildingController(_buildingServiceMock.Object);

            // Act
            var result = await controller.UpdateBuilding(buildingId, updatedBuilding);

            // Assert
            Assert.IsType<ObjectResult>(result);
            var objectResult = result as ObjectResult;
            Assert.Equal(StatusCodes.Status500InternalServerError, objectResult.StatusCode);
        }

    }
}
