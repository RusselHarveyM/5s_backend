using System.Threading.Tasks;
using Xunit;
using Moq;
using _5s.Repositories;
using _5s.Services;
using _5s.Model;

namespace _5sApiTest
{
    public class IBuildingServiceTests
    {
        private readonly Mock<IBuildingRepository> _buildingRepository;
        private readonly IBuildingService _buildingService;

        public IBuildingServiceTests()
        {
            _buildingRepository = new Mock<IBuildingRepository>();
            _buildingService = new BuildingService(_buildingRepository.Object);
        }

        [Fact]
        public async Task CreateBuilding_Returns_BuildingId()
        {
            // Arrange
            var building = new Building(); // Create a sample building object

            // Mocking repository behavior
            _buildingRepository.Setup(repo => repo.CreateBuilding(It.IsAny<Building>())).ReturnsAsync(1); 
            // Assuming 1 is the building ID returned upon successful creation

            // Act
            int buildingId = await _buildingService.CreateBuilding(building);

            // Assert
            Assert.Equal(1, buildingId); // Check if the returned ID matches the expected ID
            _buildingRepository.Verify(repo => repo.CreateBuilding(It.IsAny<Building>()), Times.Once); 
            // Verify that the repository method was called once with the correct parameter
        }

        [Fact]
        public async Task DeleteBuilding_ValidId_CallsRepositoryDeleteBuilding()
        {
            // Arrange
            int buildingId = 1; // Create a sample building ID
            // Mocking repository behavior (setting up the DeleteBuilding method)
            _buildingRepository.Setup(repo => repo.DeleteBuilding(buildingId)).Returns(Task.CompletedTask); 
            // Assuming the DeleteBuilding method returns a Task or Task.CompletedTask

            // Act
            await _buildingService.DeleteBuilding(buildingId);

            // Assert
            _buildingRepository.Verify(repo => repo.DeleteBuilding(buildingId), Times.Once);
            // Verify that the repository method was called once with the correct parameter
        }

        [Fact]
        public async Task GetAllBuilding_ReturnsBuildings()
        {
            // Arrange
            IEnumerable<Building> mockBuildings = new List<Building>
            {
                new Building { Id = 1, BuildingName = "NGE" },
                new Building { Id = 2, BuildingName = "GLE" },
            };

            // Mocking repository behavior
            _buildingRepository.Setup(repo => repo.GetAllBuildings()).ReturnsAsync(mockBuildings);

            // Act
            var result = await _buildingService.GetAllBuilding();

            // Assert
            Assert.NotNull(result); // Check if the returned result is not null
            Assert.Equal(mockBuildings, result); // Check if the returned result matches the expected result
            _buildingRepository.Verify(repo => repo.GetAllBuildings(), Times.Once);
            // Verify that the repository method was called once with the correct parameter
        }

        [Fact]
        public async Task GetBuildingById_ReturnsBuilding()
        {
            // Arrange
            int buildingId = 1; // A sample building ID
            Building mockBuilding = new Building { Id = buildingId, BuildingName = "NGE" };
            _buildingRepository.Setup(repo => repo.GetBuildingById(buildingId)).ReturnsAsync(mockBuilding);

            // Act
            var result = await _buildingService.GetBuildingById(buildingId);

            // Assert
            Assert.NotNull(result); // Check if the returned building is not null
            Assert.Equal(mockBuilding, result); // Check if the returned building matches the mocked building
            _buildingRepository.Verify(repo => repo.GetBuildingById(buildingId), Times.Once);
            // Verify that the repository method was called once with the correct parameter
        }

        [Fact]
        public async Task GetBuildingByName_ReturnsBuilding()
        {
            // Arrange
            string buildingName = "NGE";
            Building mockBuilding = new Building { Id = 1, BuildingName = buildingName };
            // A sample building with the given building name
            _buildingRepository.Setup(repo => repo.GetBuildingByName(buildingName)).ReturnsAsync(mockBuilding);

            // Act
            var result = await _buildingService.GetBuildingByName(buildingName);

            // Assert
            Assert.NotNull(result); // Check if the returned building is not null
            Assert.Equal(mockBuilding, result); // Check if the returned building matches the mocked building
            _buildingRepository.Verify(repo => repo.GetBuildingByName(buildingName), Times.Once);
            // Verify that the repository method was called once with the correct parameter
        }

        [Fact]
        public async Task UpdateBuilding_ValidId_ReturnsUpdatedBuildingId()
        {
            // Arrange
            int buildingId = 1; // A sample building ID
            byte[] updatedImage = new byte[] { 0x1, 0x2, 0x3 }; // A sample image byte array
            Building updatedBuilding = new Building
            {
                Id = buildingId,
                BuildingName = "Updated Name",
                BuildingCode = "Updated Code",
                Image = updatedImage // Assign the updated image byte array
            };

            // Mocking repository behavior
            _buildingRepository.Setup(repo => repo.UpdateBuilding(buildingId, It.IsAny<Building>())).ReturnsAsync(1);
            // Assuming 1 is the building ID returned upon successful update

            // Act
            int result = await _buildingService.UpdateBuilding(buildingId, updatedBuilding);

            // Assert
            Assert.Equal(1, result); // Check if the returned result matches the expected result
            _buildingRepository.Verify(repo => repo.UpdateBuilding(buildingId, It.IsAny<Building>()),Times.Once);
            // Verify that the repository method was called once with the correct ID and updated building object
        }
    }
}