using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _5s.Controllers;
using _5s.Services;
using _5s.Model;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace _5sApiTest.Controllers
{
    public class CommentControllerTests
    {
        private readonly Mock<ICommentService> _commentServiceMock;
        private readonly CommentController _commentController;

        public CommentControllerTests()
        {
            _commentServiceMock = new Mock<ICommentService>();
            _commentController = new CommentController(_commentServiceMock.Object);
        }

        [Fact]
        public async Task CreateComment_ValidComment_ReturnsOkResult()
        {
            // Arrange
            var comment = new Comment
            {
                Id = 1,
                Sort = "1",
                SetInOrder = "1",
                Shine = "1",
                Standarize = "1",
                Sustain = "1",
                Security = "1",
                isActive = true,
                DateModified = DateTime.Now,
                RatingId = 1
            };
            _commentServiceMock.Setup(service => service.CreateComment(comment)).ReturnsAsync(1);

            // Act
            var result = await _commentController.CreateComment(comment) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }

        [Fact]
        public async Task CreateComment_InvalidComment_ReturnsBadRequest()
        {
            // Arrange
            var invalidComment = new Comment();
            _commentController.ModelState.AddModelError("Sort", "Sort field is required");
            _commentController.ModelState.AddModelError("SetInOrder", "SetInOrder field is required");
            _commentController.ModelState.AddModelError("Shine", "Shine field is required");
            _commentController.ModelState.AddModelError("Standarize", "Standarize field is required");
            _commentController.ModelState.AddModelError("Sustain", "Sustain field is required");
            _commentController.ModelState.AddModelError("Security", "Security field is required");
            _commentController.ModelState.AddModelError("isActive", "isActive field is required");
            _commentController.ModelState.AddModelError("DateModified", "DateModified field is required");
            _commentController.ModelState.AddModelError("RatingId", "RatingId field is required");

            // Act
            var result = await _commentController.CreateComment(invalidComment) as BadRequestObjectResult;

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
            Assert.IsType<SerializableError>(result.Value);
        }

        [Fact]
        public async Task CreateComment_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var comment = new Comment { /* Define comment properties */ };
            _commentServiceMock.Setup(service => service.CreateComment(comment)).ThrowsAsync(new Exception());
            var controller = new CommentController(_commentServiceMock.Object);

            // Act
            var result = await controller.CreateComment(comment) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result.StatusCode);
        }
    }
}
