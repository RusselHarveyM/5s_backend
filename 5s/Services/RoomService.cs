using _5s.Model;
using _5s.Repositories;

namespace _5s.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<int> CreateRoom(Room room)
        {
            var roomModel = new Room
            {
                BuildingId = room.BuildingId,
                RoomNumber = room.RoomNumber,
                Image = room.Image,
                Status = room.Status
            };

            return await _roomRepository.CreateRoom(roomModel);
        }

        public async Task DeleteRoom(int id)
        {
            await _roomRepository.DeleteRoom(id);
        }

        public async Task<IEnumerable<Room>> GetAllRoom()
        {
            return await _roomRepository.GetAllRooms();
        }

        public async Task<Room> GetRoomById(int id)
        {
            return await _roomRepository.GetRoomById(id);
        }
        public Task<Room> GetRoomByRoomNumber(string roomNumber)
        {
            return _roomRepository.GetRoomByRoomNumber(roomNumber);
        }

        public async Task<int> UpdateRooms(int id, Room updatedRoom)
        {
            var UpdatedModel = new Room
            {
                RoomNumber = updatedRoom.RoomNumber,
                Image = updatedRoom.Image,
                Status = updatedRoom.Status
            };

            var update = await _roomRepository.UpdateRoom(id, UpdatedModel);

            return update;
        }
    }
}
