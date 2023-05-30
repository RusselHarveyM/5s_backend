using _5s.Model;

namespace _5s.Repositories
{
    public interface IRatingsRepository
    {
        public Task<int> CreateRatings(Ratings ratings);
        public Task<IEnumerable<Ratings>> GetAllRatings();
        public Task<Ratings> GetRatingsById(int id);
        public Task<Ratings> GetRatingsByName(string name);
        public Task<int> UpdateRatings(int id,Ratings updatedRatings);
        public Task DeleteRatings(int id);
    }
}
