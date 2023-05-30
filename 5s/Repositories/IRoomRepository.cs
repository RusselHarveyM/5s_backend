using _5s.Model;

namespace _5s.Repositories
{
    public interface IRoomRepository
    {
        public Task<int> CreateRoom(Room room);
        public Task<IEnumerable<Room>> GetAllRooms();
        public Task<Room> GetRoomById(int id);
        public Task<Room> GetRoomByRoomNumber(string roomNumber);
        public Task<int> UpdateRoom(int id, Room updatedRoom);
        public Task DeleteRoom(int id);
    }
}
