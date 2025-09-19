using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Models;
using Ascendix_Backend.Data;
using Ascendix_Backend.Dto.UserCourseProgressDto;

namespace Ascendix_Backend.Interfaces
{
    public interface IUserCourseProgressRepository
    {
        public Task<List<UserCourseProgress>> getAll(string userId);
        public Task<UserCourseProgress?> GetbyId(Guid id);
        public Task<UserCourseProgress?> create(string id, UserCourseProgress create);
        public Task<UserCourseProgress?> update(Guid id, string userId, UpdateUserCourseProgress update);
        public Task<UserCourseProgress?> delete(Guid id, string userId);
    }
}