using _5s.Model;
using _5s.Repositories;

namespace _5s.Services
{
    public class RedTagService : IRedTagService
    {
        private readonly IRedTagRepository _repository;
        public RedTagService(IRedTagRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> CreateRedTag(RedTag redtag)
        {
            var redTagModel = new RedTag
            {
                ItemName = redtag.ItemName,
                Quantity = redtag.Quantity,
            };

            return await _repository.CreateRedTag(redtag);
        }

        public async Task DeleteRedTag(int id)
        {
            await _repository.DeleteRedTag(id);
        }

        public async Task<IEnumerable<RedTag>> GetAllRedTag()
        {
            return await _repository.GetAllRedTags();
        }

        public async Task<RedTag> GetRedTagById(int id)
        {
            return await _repository.GetRedTagById(id);
        }

        public async Task<RedTag> GetRedTagByName(string name)
        {
            return await _repository.GetRedTagByName(name);
        }

        public async Task<int> UpdateRedTag(int id, RedTag updatedRedTag)
        {
            var updatedRedtag = new RedTag
            {
                Quantity = updatedRedTag.Quantity
            };

            return await _repository.UpdateRedTag(id, updatedRedtag);
        }
    }
}
