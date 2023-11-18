using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using _5s.Controllers;
using _5s.Model;
using _5s.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace _5sApiTest.Controllers
{
    public class SpaceControllerTests
    {
        private readonly Mock<ISpaceService> _spaceServiceMock;
        private readonly SpaceController _spaceController;

        public SpaceControllerTests()
        {
            _spaceServiceMock = new Mock<ISpaceService>();
            _spaceController = new SpaceController(_spaceServiceMock.Object);
        }

        [Fact]
        public async Task CreateSpace_ValidSpace_ReturnsCreatedAtRouteResult()
        {
            // Arrange
            var space = new Space { Id = 1, Name = "Meeting Room", Pictures = new List<byte[]>(), RoomId = 1 };
            _spaceServiceMock.Setup(service => service.CreateSpace(It.IsAny<Space>())).ReturnsAsync(1);
            var controller = new SpaceController(_spaceServiceMock.Object);

            // Act
            var result = await controller.CreateSpace(space) as CreatedAtRouteResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("GetSpaceById", result.RouteName);
            Assert.Equal(1, result.RouteValues["id"]);
        }

        [Fact]
        public async Task GetSpace_ReturnsOkObjectResult()
        {
            // Arrange
            var spaces = new List<Space> { new Space { Id = 1, Name = "Meeting Room", Pictures = new List<byte[]>(), RoomId = 1 } };
            _spaceServiceMock.Setup(service => service.GetAllSpace()).ReturnsAsync(spaces);

            // Act
            var result = await _spaceController.GetSpace() as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(result.Value);
        }

        [Fact]
        public async Task GetSpaceById_ExistingId_ReturnsOkObjectResult()
        {
            // Arrange
            int spaceId = 1;
            var space = new Space { Id = spaceId, Name = "Meeting Room", Pictures = new List<byte[]>(), RoomId = 1 };
            _spaceServiceMock.Setup(service => service.GetSpaceById(spaceId)).ReturnsAsync(space);

            // Act
            var result = await _spaceController.GetSpace(spaceId) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(result.Value);
        }

        /*[Fact]
        public async Task UpdateSpace_ExistingId_ReturnsOkObjectResult()
        {
            // Arrange
            int spaceId = 1;
            var updatedSpace = new Space { Id = spaceId, Name = "New Meeting Room", Pictures = new List<byte[]>(), RoomId = 1 };
            _spaceServiceMock.Setup(service => service.UpdateSpace(spaceId, It.IsAny<Space>())).ReturnsAsync(1);

            // Act
            var result = await _spaceController.UpdateSpace(spaceId, updatedSpace) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(result.Value);
        }*/

        [Fact]
        public async Task DeleteSpace_ExistingId_ReturnsOkObjectResult()
        {
            // Arrange
            int spaceId = 1;
            _spaceServiceMock.Setup(service => service.GetSpaceById(spaceId)).ReturnsAsync(new Space { Id = spaceId, Name = "Meeting Room", Pictures = new List<byte[]>(), RoomId = 1 });

            // Act
            var result = await _spaceController.DeleteSpace(spaceId) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(result.Value);
        }
    }
}