using _5s.Controllers;
using _5s.Model;
using _5s.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace _5sApiTest.Controllers
{
    public class SpaceImageControllerTests
    {
        private readonly Mock<ISpaceImageService> _spaceImageServiceMock = new Mock<ISpaceImageService>();
        private readonly SpaceImageController _spaceImageController;

        public SpaceImageControllerTests()
        {
            _spaceImageController = new SpaceImageController(_spaceImageServiceMock.Object);
        }

        [Fact]
        public async Task UploadSpaceImage_ValidData_ReturnsOkResult()
        {
            // Arrange
            int spaceId = 1;
            var fileMock = new Mock<IFormFile>();
            _spaceImageServiceMock.Setup(service => service.CreateSpaceImage(It.IsAny<SpaceImage>()))
                .ReturnsAsync(1);

            // Act
            var result = await _spaceImageController.UploadSpaceImage(spaceId, fileMock.Object) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task GetSpaceImages_ExistingSpaceId_ReturnsOkResultWithImages()
        {
            // Arrange
            int spaceId = 1;
            var fakeSpaceImages = new List<SpaceImage>();
            _spaceImageServiceMock.Setup(service => service.GetAllSpaceImagesBySpaceId(spaceId))
                .ReturnsAsync(fakeSpaceImages);

            // Act
            var result = await _spaceImageController.GetSpaceImages(spaceId) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task DeleteSpaceImage_ExistingImageId_ReturnsOkResult()
        {
            // Arrange
            int imageId = 1;
            _spaceImageServiceMock.Setup(service => service.DeleteSpaceImage(imageId))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _spaceImageController.DeleteSpaceImage(imageId) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }
    }
}
