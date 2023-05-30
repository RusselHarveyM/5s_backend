using _5s.Model;

namespace _5s.Services
{
    public interface IRedTagService
    {
        public Task<int> CreateRedTag(RedTag redtag);
        public Task<IEnumerable<RedTag>> GetAllRedTag();
        public Task<RedTag> GetRedTagById(int id);
        public Task<RedTag> GetRedTagByName(string name);
        public Task<int> UpdateRedTag(int id, RedTag updatedRedTag);
        public Task DeleteRedTag(int id);
    }
}
