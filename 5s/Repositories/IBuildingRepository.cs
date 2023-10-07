using _5s.Model;

namespace _5s.Repositories
{
    public interface IBuildingRepository
    {
        /// <summary>
        /// Create a building
        /// </summary>
        /// <param name="building"></param>
        /// <returns>Returns a building model</returns>
        public Task<int> CreateBuilding(Building building);
        /// <summary>
        /// Gets all buidling
        /// </summary>
        /// <returns>Returns a list of all building with details</returns>
        public Task<IEnumerable<Building>> GetAllBuildings();
        /// <summary>
        /// Get building by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns building details</returns>
        public Task<Building> GetBuildingById(int id);
        /// <summary>
        /// Get building by Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Returns building details</returns>
        public Task<Building> GetBuildingByName(string name);
        /// <summary>
        /// Updates an existing Building
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatedBuilding"></param>
        /// <returns>Returns the Id of the updated building</returns>
        public Task<int> UpdateBuilding(int id, Building updatedBuilding);
        /// <summary>
        /// Delete a building
        /// </summary>
        /// <param name="id"></param>
        public Task DeleteBuilding(int id);
    }
}
