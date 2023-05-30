using _5s.Model;
using _5s.Services;
using Microsoft.AspNetCore.Mvc;

namespace _5s.Controllers
{
    [Route("api/ratings")]
    [ApiController]
    public class RatingsController : Controller
    {
        private readonly IRatingService _ratingsService;
        public RatingsController(IRatingService ratingsService)
        {
            _ratingsService = ratingsService;
        }

        [HttpPost(Name = "CreateRating")]
        public async Task<IActionResult> CreateRatings([FromBody] Ratings ratings)
        {
            try
            {
                var newRating = await _ratingsService.CreateRatings(ratings);
                return CreatedAtRoute("GetRatingsId", new { id = ratings.Id }, newRating);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet(Name = "GetAllRatings")]
        public async Task<IActionResult> GetRatings()
        {
            try
            {
                var ratings = await _ratingsService.GetAllRatings();
                return Ok(ratings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}/ratings", Name = "GetRatingsById")]
        public async Task<IActionResult> GetRatings(int id)
        {
            try
            {
                var rating = await _ratingsService.GetRatingsById(id);
                return Ok(rating);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}", Name = "UpdateRatings")]
        public async Task<IActionResult> UpdateRedTag(int id, [FromBody] Ratings ratings)
        {
            try
            {
                var dbRatings = await _ratingsService.GetRatingsById(id);
                if (dbRatings == null)
                    return NotFound();
                var updatedRatings = await _ratingsService.UpdateRatings(id, ratings);
                return Ok(updatedRatings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{name}", Name = "DeleteRatings")]
        public async Task<IActionResult> DeleteRatings(string name)
        {
            try
            {
                var dbRatings = await _ratingsService.GetRatingsByName(name);
                if (dbRatings == null)
                    return NotFound();
                await _ratingsService.DeleteRatings(dbRatings.Id);
                return Ok("Barangay successfully deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
