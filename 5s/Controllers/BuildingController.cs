using _5s.Model;
using _5s.Services;
using Microsoft.AspNetCore.Mvc;

namespace _5s.Controllers
{
    [Route("api/buildings")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingService _buildingService;
        public BuildingController(IBuildingService buildingService)
        {
            _buildingService = buildingService;
        }

        [HttpPost(Name = "CreateBuilding")]
        public async Task<IActionResult> CreateBuilding([FromBody] Building building)
        {
            try
            {
                var newBuilding = await _buildingService.CreateBuilding(building);
                return CreatedAtRoute("GetBuildingId", new { id = building.Id }, newBuilding);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet(Name = "GetAllBuilding")]
        public async Task<IActionResult> GetBuilding()
        {
            try
            {
                var building = await _buildingService.GetAllBuilding();
                return Ok(building);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}/building", Name = "GetBuildingById")]
        public async Task<IActionResult> GetBuilding(int id)
        {
            try
            {
                var building = await _buildingService.GetBuildingById(id);
                return Ok(building);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}", Name = "UpdateBuilding")]
        public async Task<IActionResult> UpdateBuilding(int id, [FromBody] Building building)
        {
            try
            {
                var dbbuilding = await _buildingService.GetBuildingById(id);
                if (dbbuilding == null)
                    return NotFound();
                var updatedBuilding = await _buildingService.UpdateBuilding(id, building);
                return Ok(updatedBuilding);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{name}", Name = "DeleteBuilding")]
        public async Task<IActionResult> DeleteBuilding(string name)
        {
            try
            {
                var dbRatings = await _buildingService.GetBuildingByName(name);
                if (dbRatings == null)
                    return NotFound();
                await _buildingService.DeleteBuilding(dbRatings.Id);
                return Ok("Barangay successfully deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
