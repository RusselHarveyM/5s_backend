using _5s.Model;
using _5s.Repositories;

namespace _5s.Services
{
    public class BuildingService : IBuildingService
    {
        private readonly IBuildingRepository _buildingRepository;
        public BuildingService(IBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }
        public async Task<int> CreateBuilding(Building building)
        {
            var buildingModel = new Building
            {
                BuildingName = building.BuildingName,
                BuildingCode = building.BuildingCode
            };

            return await _buildingRepository.CreateBuilding(buildingModel);
        }

        public async Task DeleteBuilding(int id)
        {
            await _buildingRepository.DeleteBuilding(id);
        }

        public Task<IEnumerable<Building>> GetAllBuilding()
        {
            return _buildingRepository.GetAllBuildings();
        }

        public async Task<Building> GetBuildingById(int id)
        {
            return await _buildingRepository.GetBuildingById(id);
        }
        public async Task<Building> GetBuildingByName(string name)
        {
            return await _buildingRepository.GetBuildingByName(name);
        }

        public async Task<int> UpdateBuilding(int id, Building updatedBuilding)
        {
            var updatedModel = new Building
            {
                BuildingCode = updatedBuilding.BuildingCode,
                BuildingName = updatedBuilding.BuildingName
            };

            var updated = await _buildingRepository.UpdateBuilding(id, updatedModel);

            return updated;
        }
    }
}
