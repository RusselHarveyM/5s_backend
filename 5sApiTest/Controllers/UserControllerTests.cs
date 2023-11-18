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
    public class UserControllerTests
    {
        private readonly Mock<IUserService> _userServiceMock;
        private readonly UserController _userController;

        public UserControllerTests()
        {
            _userServiceMock = new Mock<IUserService>();
            _userController = new UserController(_userServiceMock.Object);
        }

        [Fact]
        public async Task CreateUser_ValidUser_ReturnsOkResultWithNewUser()
        {
            // Arrange
            var _userServiceMock = new Mock<IUserService>();

            var newUser = new User
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Role = "admin"
            };

            _userServiceMock.Setup(service => service.CreateUser(newUser))
                .ReturnsAsync((User user) =>
                {
                    return 1;
                });

            var _userController = new UserController(_userServiceMock.Object);

            // Act
            var result = await _userController.CreateUser(newUser) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(result.Value);
            Assert.IsType<int>(result.Value);
        }

        [Fact]
        public async Task GetUser_ExistingUsers_ReturnsOkResultWithUsers()
        {
            // Arrange
            var expectedUsers = new List<User> { /* Define user list */ };
            _userServiceMock.Setup(service => service.GetAllUser())
                .ReturnsAsync(expectedUsers);

            // Act
            var result = await _userController.GetUser() as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(result.Value);
            Assert.IsType<List<User>>(result.Value);
            // Further assertions based on the expected user list content or structure
        }

        [Fact]
        public async Task GetUserById_ExistingUserId_ReturnsOkResultWithUser()
        {
            // Arrange
            int userId = 1; // Define an existing user ID
            var expectedUser = new User { /* Define user properties */ };
            _userServiceMock.Setup(service => service.GetUserById(userId))
                .ReturnsAsync(expectedUser);

            // Act
            var result = await _userController.GetUser(userId) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(result.Value);
            Assert.IsType<User>(result.Value);
            // Further assertions based on the expected user content or structure
        }

        /*[Fact]
        public async Task UpdateUser_ExistingUserIdAndValidUser_ReturnsOkResultWithUpdatedUser()
        {
            // Arrange
            var updatedUser = new User
            {
                Id = 1,
                FirstName = "Juan",
                LastName = "Dela Cruz",
                Role = "admin"
            };

            var existingUser = new User
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Role = "user"
            };

            _userServiceMock.Setup(service => service.GetUserById(1))
                .ReturnsAsync(existingUser);

            _userServiceMock.Setup(service => service.UpdateUser(1, It.IsAny<User>()))
                .ReturnsAsync(updatedUser);

            // Act
            var result = await _userController.UpdateUser(1, updatedUser) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(result.Value);
            Assert.IsType<User>(result.Value);
        }*/

        [Fact]
        public async Task DeleteUser_ExistingUserId_ReturnsOkResultWithSuccessMessage()
        {
            // Arrange
            int userId = 1; // Define an existing user ID
            var existingUser = new User { /* Define existing user properties */ };
            _userServiceMock.Setup(service => service.GetUserById(userId))
                .ReturnsAsync(existingUser);

            // Act
            var result = await _userController.DeleteUser(userId) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("User successfully deleted", result.Value);
        }
    }
}
