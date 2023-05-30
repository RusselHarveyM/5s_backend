using _5s.Model;

namespace _5s.Repositories
{
    public interface IRedTagRepository
    {
        public Task<int> CreateRedTag(RedTag redtag);
        public Task<IEnumerable<RedTag>> GetAllRedTags();
        public Task<RedTag> GetRedTagById(int id);
        public Task<RedTag> GetRedTagByName(string Name);
        public Task<int> UpdateRedTag(int id, RedTag updatedRedTag);
        public Task DeleteRedTag(int id);
    }
}
