using _5s.Model;

namespace _5s.Services
{
    public interface IRoomService
    {
        public Task<int> CreateRoom(Room room);
        public Task<IEnumerable<Room>> GetAllRoom();
        public Task<Room> GetRoomById(int id);
        public Task<Room> GetRoomByRoomNumber(string roomNumber);
        public Task<int> UpdateRooms(int id, Room updatedRoom);
        public Task DeleteRoom(int id);
    }
}
