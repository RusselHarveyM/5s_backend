﻿using _5s.Model;
using _5s.Repositories;

namespace _5s.Services
{
    public class SpaceImageService : ISpaceImageService
    {
        private readonly ISpaceImageRepository _spaceImageRepository;

        public SpaceImageService(ISpaceImageRepository spaceImageRepository)
        {
            _spaceImageRepository = spaceImageRepository;
        }

        public async Task<int> CreateSpaceImage(SpaceImage spaceImage)
        {
            if (spaceImage == null)
            {
                throw new ArgumentNullException(nameof(spaceImage));
            }

            // You can add validation or business logic here before saving the image.
            var spaceImageModel = new SpaceImage
            {
                SpaceId = spaceImage.SpaceId,
                Image = spaceImage.Image,
                UploadedDate = DateTime.Now
            };

            return await _spaceImageRepository.CreateSpaceImage(spaceImageModel);
        }

        public async Task DeleteSpaceImage(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid ID value.", nameof(id));
            }

            await _spaceImageRepository.DeleteSpaceImage(id);
        }

        public async Task<IEnumerable<SpaceImage>> GetAllSpaceImagesBySpaceId(int spaceId)
        {
            if (spaceId <= 0)
            {
                throw new ArgumentException("Invalid SpaceID value.", nameof(spaceId));
            }

            return await _spaceImageRepository.GetAllSpaceImageBySpaceId(spaceId);
        }
    }
}
