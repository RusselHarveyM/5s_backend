﻿using _5s.Model;
using _5s.Repositories;

namespace _5s.Services
{
    public class SpaceService : ISpaceService
    {
        private readonly ISpaceRepository _spaceRepository;
        public SpaceService(ISpaceRepository spaceRepository)
        {
            _spaceRepository = spaceRepository;
        }

        public async Task<int> CreateSpace(Space space)
        {
            var spaceModel = new Space
            {
                Name = space.Name,
                Pictures = space.Pictures,
                RoomId = space.RoomId
            };

            return await _spaceRepository.CreateSpace(spaceModel);
        }

        public async Task DeleteSpace(int id)
        {
            await _spaceRepository.DeleteSpace(id);
        }

        public Task<IEnumerable<Space>> GetAllSpace()
        {
            return _spaceRepository.GetAllSpace();
        }

        public async Task<Space> GetSpaceById(int id)
        {
            return await _spaceRepository.GetSpaceById(id);
        }
        public async Task<Space> GetSpaceByName(string name) 
        {
            return await _spaceRepository.GetSpaceByName(name); 
        }

        public async Task<int> UpdateSpace(int id, Space updatedSpace)
        {
            var updateSpace = new Space
            {
                Name = updatedSpace.Name,
                Pictures = updatedSpace.Pictures
            };

            var updated = await _spaceRepository.UpdateSpace(id, updatedSpace);

            return updated;
        }
    }
}
