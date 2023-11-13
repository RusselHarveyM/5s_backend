﻿using _5s.Model;

namespace _5s.Repositories
{
    public interface ISpaceImageRepository
    {
        /// <summary>
        /// Create SpaceImage
        /// </summary>
        /// <param name="spaceImage">Image</param>
        /// <returns>Returns Id of Space Image</returns>
        public Task<int> CreateSpaceImage(SpaceImage spaceImage);
        /// <summary>
        /// Gets all SpaceImage by SpaceId
        /// </summary>
        /// <param name="id">Space Id</param>
        /// <returns>Returns All SpaceImage by Id</returns>
        public Task<IEnumerable<SpaceImage>> GetAllSpaceImageBySpaceId(int id);
        /// <summary>
        /// Delete SpaceImage by Id
        /// </summary>
        /// <param name="id">Id of SpaceImage</param>
        public Task DeleteSpaceImage(int id);
    }
}
