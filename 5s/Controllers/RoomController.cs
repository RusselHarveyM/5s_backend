using _5s.Model;
using _5s.Services;
using Microsoft.AspNetCore.Mvc;

namespace _5s.Controllers
{
    [Route("api/rooms")]
    [ApiController]
    public class RoomController : Controller
    {
        private readonly IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpPost(Name = "CreateRoom")]
        public async Task<IActionResult> CreateRoom([FromBody] Room room)
        {
            try
            {
                var newRoom = await _roomService.CreateRoom(room);
                return CreatedAtRoute("GetSpaceId", new { id = room.Id }, newRoom);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet(Name = "GetAllRoom")]
        public async Task<IActionResult> GetRoom()
        {
            try
            {
                var room = await _roomService.GetAllRoom();
                return Ok(room);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}/room", Name = "GetRoomById")]
        public async Task<IActionResult> GetRoom(int id)
        {
            try
            {
                var room = await _roomService.GetRoomById(id);
                return Ok(room);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}", Name = "UpdateRoom")]
        public async Task<IActionResult> UpdateRoom(int id, [FromBody] Room room)
        {
            try
            {
                var dbRoom = await _roomService.GetRoomById(id);
                if (dbRoom == null)
                    return NotFound();
                var updatedRoom = await _roomService.UpdateRooms(id, room);
                return Ok(updatedRoom);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{name}", Name = "DeleteRoom")]
        public async Task<IActionResult> DeleteRoom(string roomNumber)
        {
            try
            {
                var dbRoom = await _roomService.GetRoomByRoomNumber(roomNumber);
                if (dbRoom == null)
                    return NotFound();
                await _roomService.DeleteRoom(dbRoom.Id);
                return Ok("Barangay successfully deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
