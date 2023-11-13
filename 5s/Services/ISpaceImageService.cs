using _5s.Model;

namespace _5s.Services
{
    public interface ISpaceImageService
    {
        Task<int> CreateSpaceImage(SpaceImage spaceImage);
        Task DeleteSpaceImage(int id);
        Task<IEnumerable<SpaceImage>> GetAllSpaceImagesBySpaceId(int spaceId);
    }
}
