using _5s.Model;

namespace _5s.Services
{
    public interface IRoomService
    {
        /// <summary>
        /// Create a room
        /// </summary>
        /// <param name="room">Room Details</param>
        /// <returns>Returns id of the newly created Room</returns>
        public Task<int> CreateRoom(Room room);
        /// <summary>
        /// Get all room
        /// </summary>
        /// <returns>Returns a list of all room with details</returns>
        public Task<IEnumerable<Room>> GetAllRoom();
        /// <summary>
        /// Get Room By Id
        /// </summary>
        /// <param name="id">Id of an exising room</param>
        /// <returns>Returns room details</returns>
        public Task<Room> GetRoomById(int id);
        /// <summary>
        /// Get Room by roomnumber
        /// </summary>
        /// <param name="roomNumber">roomnumber of an existing room</param>
        /// <returns>Return room details</returns>
        public Task<Room> GetRoomByRoomNumber(string roomNumber);
        /// <summary>
        /// Update a room by Id
        /// </summary>
        /// <param name="id">Id of an existing room</param>
        /// <param name="updatedRoom">new Room details</param>
        /// <returns>Return id of the newly updated room</returns>
        public Task<int> UpdateRooms(int id, Room updatedRoom);
        /// <summary>
        /// Delete a room
        /// </summary>
        /// <param name="id">Id of an exising room</param>
        public Task DeleteRoom(int id);
    }
}
