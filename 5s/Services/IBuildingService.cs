using _5s.Model;

namespace _5s.Services
{
    public interface IBuildingService
    {
        public Task<int> CreateBuilding(Building building);
        public Task<IEnumerable<Building>> GetAllBuilding();
        public Task<Building> GetBuildingById(int id);
        public Task<Building> GetBuildingByName(string name);
        public Task<int> UpdateBuilding(int id, Building updatedBuilding);
        public Task DeleteBuilding(int id);
    }
}
