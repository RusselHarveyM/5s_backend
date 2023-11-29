﻿using _5s.Model;
using _5s.Services;
using Microsoft.AspNetCore.Mvc;

namespace _5s.Controllers
{
    [Route("api/space")]
    [ApiController]
    public class SpaceController : Controller
    {
        private readonly ISpaceService _spaceService;
        public SpaceController(ISpaceService spaceService)
        {
            _spaceService = spaceService;
        }

        [HttpPost(Name = "CreateSpace")]
        public async Task<IActionResult> CreateSpace([FromBody] Space space)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var newSpace = await _spaceService.CreateSpace(space);
                return CreatedAtRoute("GetSpaceById", new { id = space.Id }, newSpace);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet(Name = "GetAllSpace")]
        public async Task<IActionResult> GetSpace()
        {
            try
            {
                var space = await _spaceService.GetAllSpace();
                if (space == null || !space.Any())
                {
                    return NotFound();
                }
                return Ok(space);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}/space", Name = "GetSpaceById")]
        public async Task<IActionResult> GetSpace(int id)
        {
            try
            {
                var space = await _spaceService.GetSpaceById(id);
                if (space == null)
                {
                    return NotFound();
                }
                return Ok(space);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}", Name = "UpdateSpace")]
        public async Task<IActionResult> UpdateSpace(int id, [FromBody] Space space)
        {
            try
            {
                var dbSpace = await _spaceService.GetSpaceById(id);
                if (dbSpace == null)
                    return NotFound();
                var updatedSpace = await _spaceService.UpdateSpace(id, space);
                return Ok(updatedSpace);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}", Name = "DeleteSpace")]
        public async Task<IActionResult> DeleteSpace(int id)
        {
            try
            {
                var dbSpace = await _spaceService.GetSpaceById(id);
                if (dbSpace == null)
                    return NotFound();
                await _spaceService.DeleteSpace(id);
                return Ok("Space successfully deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
