using _5s.Model;

namespace _5s.Services
{
    public interface ISpaceService
    {
        public Task<int> CreateSpace(Space space);
        public Task<IEnumerable<Space>> GetAllSpace();
        public Task<Space> GetSpaceById(int id);
        public Task<Space> GetSpaceByName(string name);
        public Task<int> UpdateSpace(int id, Space updatedSpace);
        public Task DeleteSpace(string name);
    }
}
