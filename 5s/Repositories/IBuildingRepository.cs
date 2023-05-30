using _5s.Model;

namespace _5s.Repositories
{
    public interface IBuildingRepository
    {
        public Task<int> CreateBuilding(Building building);
        public Task<IEnumerable<Building>> GetAllBuildings();
        public Task<Building> GetBuildingById(int id);
        public Task<Building> GetBuildingByName(string name);
        public Task<int> UpdateBuilding(int id, Building updatedBuilding);
        public Task DeleteBuilding(int id);
    }
}
