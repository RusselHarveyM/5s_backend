﻿using _5s.Model;
using _5s.Services;
using Microsoft.AspNetCore.Mvc;

namespace _5s.Controllers
{
    [Route("api/redtag")]
    [ApiController]
    public class RedTagController : Controller
    {
        private readonly IRedTagService _redTagService;
        public RedTagController(IRedTagService redTagService)
        {
            _redTagService = redTagService;
        }

        [HttpPost(Name = "CreateRedTag")]
        public async Task<IActionResult> CreateRoom([FromBody] RedTag redtag)
        {
            try
            {
                var newRedTag = await _redTagService.CreateRedTag(redtag);
                return CreatedAtRoute("GetSpaceId", new { id = redtag.Id }, newRedTag);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet(Name = "GetAllRedTag")]
        public async Task<IActionResult> GetRedTag()
        {
            try
            {
                var redtag = await _redTagService.GetAllRedTag();
                return Ok(redtag);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}/redtag", Name = "GetRedTagById")]
        public async Task<IActionResult> GetRedTag(int id)
        {
            try
            {
                var redtag = await _redTagService.GetRedTagById(id);
                return Ok(redtag);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}", Name = "UpdateRedTag")]
        public async Task<IActionResult> UpdateRedTag(int id, [FromBody] RedTag redtag)
        {
            try
            {
                var dbRedTag = await _redTagService.GetRedTagById(id);
                if (dbRedTag == null)
                    return NotFound();
                var updatedRedTag = await _redTagService.UpdateRedTag(id, redtag);
                return Ok(updatedRedTag);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{name}", Name = "DeleteRedTag")]
        public async Task<IActionResult> DeleteRedTag(string name)
        {
            try
            {
                var dbRoom = await _redTagService.GetRedTagByName(name);
                if (dbRoom == null)
                    return NotFound();
                await _redTagService.DeleteRedTag(dbRoom.Id);
                return Ok("Barangay successfully deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}