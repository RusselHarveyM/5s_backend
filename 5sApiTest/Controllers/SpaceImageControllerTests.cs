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
        public async Task UploadSpaceImage_ValidInput_ReturnsOkResult()
        {
            // Arrange
            var spaceImageServiceMock = new Mock<ISpaceImageService>();
            var spaceImageController = new SpaceImageController(spaceImageServiceMock.Object);
            
            var formFileMock = new Mock<IFormFile>();
            formFileMock.Setup(f => f.Length).Returns(10);

            // Act
            var result = await spaceImageController.UploadSpaceImage(1, formFileMock.Object) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task GetSpaceImages_ExistingSpaceId_ReturnsOkResultWithImages()
        {
            // Arrange
            var spaceId = 1;
            var expectedImages = new List<SpaceImage>
            {
                new SpaceImage
                {
                    Id = 1,
                    SpaceId = 1,
                    Image = new byte[] { 0x1, 0x2, 0x3 },
                    UploadedDate = DateTime.UtcNow
                },
                new SpaceImage
                {
                    Id = 2,
                    SpaceId = 1,
                    Image = new byte[] { 0x1, 0x2, 0x3 },
                    UploadedDate = DateTime.UtcNow
                },
            };

            var spaceImageServiceMock = new Mock<ISpaceImageService>();
            spaceImageServiceMock.Setup(service => service.GetAllSpaceImagesBySpaceId(spaceId))
                .ReturnsAsync(expectedImages);

            var controller = new SpaceImageController(spaceImageServiceMock.Object);

            // Act
            var result = await controller.GetSpaceImages(spaceId) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(result.Value);
            Assert.IsType<List<SpaceImage>>(result.Value);
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
