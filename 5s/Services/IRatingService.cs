using _5s.Model;

namespace _5s.Services
{
    public interface IRatingService
    {
        public Task<int> CreateRatings(Ratings ratings);
        public Task<IEnumerable<Ratings>> GetAllRatings();
        public Task<Ratings> GetRatingsById(int id);
        public Task<Ratings> GetRatingsByName(string id);
        public Task<int> UpdateRatings(int id, Ratings updatedRatings);
        public Task DeleteRatings(int id);
    }
}
