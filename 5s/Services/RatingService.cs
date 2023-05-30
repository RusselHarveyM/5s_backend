using _5s.Model;
using _5s.Repositories;

namespace _5s.Services
{
    public class RatingService : IRatingService
    {
        private readonly IRatingsRepository _repository;
        public RatingService(IRatingsRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> CreateRatings(Ratings ratings)
        {
            var ratingModel = new Ratings
            {
                Sort = ratings.Sort,
                SetInOrder = ratings.SetInOrder,
                Shine = ratings.Shine,
                Standerize = ratings.Standerize,
                Sustain = ratings.Sustain,
                Security = ratings.Security,
            };

            return await _repository.CreateRatings(ratingModel);
        }

        public async Task DeleteRatings(int id)
        {
            await _repository.DeleteRatings(id);
        }

        public Task<IEnumerable<Ratings>> GetAllRatings()
        {
            return _repository.GetAllRatings();
        }

        public async Task<Ratings> GetRatingsById(int id)
        {
            return await _repository.GetRatingsById(id);
        }
        public async Task<Ratings> GetRatingsByName(string id)
        {
            return await _repository.GetRatingsByName(id);
        }

        public async Task<int> UpdateRatings(int id, Ratings updatedRatings)
        {
            var ratingModel = new Ratings
            {
                Sort = updatedRatings.Sort,
                SetInOrder = updatedRatings.SetInOrder,
                Shine = updatedRatings.Shine,
                Standerize = updatedRatings.Standerize,
                Sustain = updatedRatings.Sustain,
                Security = updatedRatings.Security,
            };

            return await _repository.UpdateRatings(id, ratingModel);
        }
    }
}
