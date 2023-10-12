using _5s.Model;

namespace _5s.Repositories
{
    public interface ISpaceImageRepository
    {
        public Task<int> CreateSpaceImage(SpaceImage spaceImage);
        public Task<IEnumerable<SpaceImage>> GetAllSpaceImageBySpaceId(int id);
        public Task DeleteSpaceImage(int id);
    }
}
