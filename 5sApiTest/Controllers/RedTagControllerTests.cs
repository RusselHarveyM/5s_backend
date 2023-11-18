using _5s.Controllers;
using _5s.Model;
using _5s.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace _5sApiTest.Controllers
{
    public class RedTagControllerTests
    {
        private readonly Mock<IRedTagService> _redTagServiceMock;
        private readonly RedTagController _redTagController;

        public RedTagControllerTests()
        {
            _redTagServiceMock = new Mock<IRedTagService>();
            _redTagController = new RedTagController(_redTagServiceMock.Object);
        }

        [Fact]
        public async Task CreateRedTag_ValidRedTag_ReturnsCreatedAtRouteResult()
        {
            // Arrange
            var redTag = new RedTag { ItemName = "Sample Item", Quantity = 5, RoomId = 1 };
            var redTagId = 1;
            _redTagServiceMock.Setup(service => service.CreateRedTag(redTag)).ReturnsAsync(redTagId);

            // Act
            var result = await _redTagController.CreateRedTag(redTag) as CreatedAtRouteResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("GetRedTagById", result.RouteName);
            Assert.Equal(redTag.Id, result.RouteValues["id"]);
            Assert.Equal(redTagId, result.Value);
        }

        [Fact]
        public async Task GetRedTag_ReturnsOkResultWithRedTagList()
        {
            // Arrange
            var redTagList = new List<RedTag>
            {
                new RedTag { Id = 1, ItemName = "Sample Item 1", Quantity = 5, RoomId = 1 },
                new RedTag { Id = 2, ItemName = "Sample Item 2", Quantity = 10, RoomId = 2 }
            };
            _redTagServiceMock.Setup(service => service.GetAllRedTag()).ReturnsAsync(redTagList);

            // Act
            var result = await _redTagController.GetRedTag() as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            var redTagResult = Assert.IsType<List<RedTag>>(result.Value);
            Assert.Equal(redTagList.Count, redTagResult.Count);
        }

        [Fact]
        public async Task GetRedTagById_ValidId_ReturnsOkResultWithRedTag()
        {
            // Arrange
            var redTagId = 1;
            var redTag = new RedTag { Id = redTagId, ItemName = "Sample Item", Quantity = 5, RoomId = 1 };
            _redTagServiceMock.Setup(service => service.GetRedTagById(redTagId)).ReturnsAsync(redTag);

            // Act
            var result = await _redTagController.GetRedTag(redTagId) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            var redTagResult = Assert.IsType<RedTag>(result.Value);
            Assert.Equal(redTag.Id, redTagResult.Id);
        }

        [Fact]
        public async Task UpdateRedTag_ExistingId_ReturnsOkResultWithUpdatedRedTag()
        {
            // Arrange
            var redTagId = 1;
            var existingRedTag = new RedTag
            {
                Id = 1,
                ItemName = "Existing Item",
                Quantity = 5,
                RoomId = 2
            };
            var updatedRedTag = new RedTag
            {
                Id = redTagId,
                ItemName = "Updated Item",
                Quantity = 8,
                RoomId = 2
            };

            _redTagServiceMock.Setup(service => service.GetRedTagById(redTagId)).ReturnsAsync(existingRedTag);
            _redTagServiceMock.Setup(service => service.UpdateRedTag(redTagId, updatedRedTag)).ReturnsAsync(1);

            var controller = new RedTagController(_redTagServiceMock.Object);

            // Act
            var actionResult = await controller.UpdateRedTag(redTagId, updatedRedTag) as OkObjectResult;

            // Assert
            Assert.NotNull(actionResult);

            var updatedRedTagResult = actionResult.Value as int?;
            Assert.NotNull(updatedRedTagResult);
            Assert.Equal(1, updatedRedTagResult);
        }

        [Fact]
        public async Task UpdateRedTag_NonExistingId_ReturnsNotFound()
        {
            // Arrange
            var redTagId = 100;
            var updatedRedTag = new RedTag { Id = redTagId, ItemName = "Updated Item", Quantity = 8, RoomId = 2 };

            _redTagServiceMock.Setup(service => service.GetRedTagById(redTagId)).ReturnsAsync((RedTag)null);

            var controller = new RedTagController(_redTagServiceMock.Object);

            // Act
            var result = await controller.UpdateRedTag(redTagId, updatedRedTag) as NotFoundResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(404, result.StatusCode);
        }

        [Fact]
        public async Task DeleteRedTag_ValidName_DeletesRedTag()
        {
            // Arrange
            var redTagName = "Sample Item";
            var redTag = new RedTag { Id = 1, ItemName = redTagName, Quantity = 5, RoomId = 1 };
            _redTagServiceMock.Setup(service => service.GetRedTagByName(redTagName)).ReturnsAsync(redTag);

            // Act
            var result = await _redTagController.DeleteRedTag(redTagName) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("RedTag successfully deleted", result.Value);
        }
    }
}
