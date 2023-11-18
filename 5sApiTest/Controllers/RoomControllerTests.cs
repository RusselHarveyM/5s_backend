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
    public class RoomControllerTests
    {
        private readonly Mock<IRoomService> _roomServiceMock;
        private readonly RoomController _roomController;

        public RoomControllerTests()
        {
            _roomServiceMock = new Mock<IRoomService>();
            _roomController = new RoomController(_roomServiceMock.Object);
        }

        [Fact]
        public async Task CreateRoom_ValidRoom_ReturnsCreatedAtRouteResult()
        {
            // Arrange
            var newRoom = new Room
            {
                Id = 1,
                BuildingId = 1,
                RoomNumber = "101",
                Image = new byte[] { 0x12, 0x34, 0x56, 0x78 },
                Status = "Active"
            };

            _roomServiceMock.Setup(service => service.CreateRoom(newRoom))
                .ReturnsAsync(1);

            // Act
            var result = await _roomController.CreateRoom(newRoom) as CreatedAtRouteResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("GetRoomById", result.RouteName);
            Assert.Equal(1, result.RouteValues["id"]);
            Assert.Equal(201, result.StatusCode);
            Assert.NotNull(result.Value);
            Assert.IsType<int>(result.Value);
        }

        [Fact]
        public async Task GetRoom_ReturnsOkObjectResult()
        {
            // Arrange
            var rooms = new List<Room>
            {
                new Room
                {
                    Id = 1,
                    BuildingId = 1,
                    RoomNumber = "101",
                    Image = new byte[] { 0x12, 0x34, 0x56, 0x78 },
                    Status = "Active"
                }
            };

            _roomServiceMock.Setup(service => service.GetAllRoom())
                .ReturnsAsync(rooms);

            // Act
            var result = await _roomController.GetRoom() as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(result.Value);
        }

        [Fact]
        public async Task GetRoomById_ExistingId_ReturnsOkObjectResult()
        {
            // Arrange
            int roomId = 1;
            var room = new Room
            {
                Id = 1,
                BuildingId = 1,
                RoomNumber = "101",
                Image = new byte[] { 0x12, 0x34, 0x56, 0x78 },
                Status = "Active"
            };

            _roomServiceMock.Setup(service => service.GetRoomById(roomId))
                .ReturnsAsync(room);

            // Act
            var result = await _roomController.GetRoom(roomId) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(result.Value);
        }

        [Fact]
        public async Task GetRoom_NonExistingRoomId_ReturnsNotFound()
        {
            // Arrange
            int nonExistingId = 2;
            var rooms = new List<Room>
            {
                new Room
                {
                    Id = 1,
                    BuildingId = 1,
                    RoomNumber = "101",
                    Image = new byte[] { 0x12, 0x34, 0x56, 0x78 },
                    Status = "Active"
                }
            };

            _roomServiceMock.Setup(service => service.GetRoomById(nonExistingId)).ReturnsAsync((Room)null);
            var controller = new RoomController(_roomServiceMock.Object);

            // Act
            var actionResult = await controller.GetRoom(nonExistingId);

            // Assert
            var result = Assert.IsType<NotFoundResult>(actionResult);
            Assert.Equal(404, result.StatusCode);
        }

        [Fact]
        public async Task UpdateRoom_ValidRoom_ReturnsNoContentResult()
        {
            // Arrange
            int roomId = 1;
            var room = new Room
            {
                Id = 1,
                BuildingId = 1,
                RoomNumber = "101",
                Image = new byte[] { 0x12, 0x34, 0x56, 0x78 },
                Status = "Active"
            };

            _roomServiceMock.Setup(service => service.UpdateRooms(roomId, room))
                .ReturnsAsync(1);

            // Act
            var result = await _roomController.UpdateRoom(roomId, room) as NoContentResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(204, result.StatusCode);
        }

        [Fact]
        public async Task UpdateRoom_NonExistingId_ReturnsNotFoundResult()
        {
            // Arrange
            int roomId = 1;
            var room = new Room
            {
                Id = 1,
                BuildingId = 1,
                RoomNumber = "101",
                Image = new byte[] { 0x12, 0x34, 0x56, 0x78 },
                Status = "Active"
            };

            _roomServiceMock.Setup(service => service.UpdateRooms(roomId, room))
                .ReturnsAsync(0);

            // Act
            var result = await _roomController.UpdateRoom(roomId, room) as NotFoundResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(404, result.StatusCode);
        }

        [Fact]
        public async Task DeleteRoom_ExistingRoomNumber_ReturnsOkResultWithSuccessMessage()
        {
            // Arrange
            string roomNumber = "101";
            var existingRoom = new Room
            {
                Id = 1,
                BuildingId = 1,
                RoomNumber = roomNumber,
                Image = new byte[] { 0x12, 0x34, 0x56, 0x78 },
                Status = "Active"
            };

            _roomServiceMock.Setup(service => service.GetRoomByRoomNumber(roomNumber))
                .ReturnsAsync(existingRoom);

            _roomServiceMock.Setup(service => service.DeleteRoom(existingRoom.Id))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _roomController.DeleteRoom(roomNumber) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Room successfully deleted", result.Value);
        }

        [Fact]
        public async Task DeleteRoom_NonExistingRoomNumber_ReturnsNotFound()
        {
            // Arrange
            string roomNumber = "999";

            _roomServiceMock.Setup(service => service.GetRoomByRoomNumber(roomNumber))
                .ReturnsAsync((Room)null);

            // Act
            var result = await _roomController.DeleteRoom(roomNumber) as NotFoundResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(404, result.StatusCode);
        }
    }
}