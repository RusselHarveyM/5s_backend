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
    }
}