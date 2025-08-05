using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.UserCourseProgressDto;
using Ascendix_Backend.Models;

namespace Ascendix_Backend.Mappers
{
    public static class UserProgressMapper
    {
        public static UserCourseProgress toUserCourseProgress(this CreateUserCourseProgress create)
        {
            return new UserCourseProgress
            {
                userId = create.userId,
                courseId = create.courseId,
                progressPercent = create.progressPercent,
                status = Status.OnGoing,
            };
        }

        public static ViewUserCourseProgress fromUserCourseProgress(this UserCourseProgress user)
        {
            return new ViewUserCourseProgress
            {
                progressId = user.progressId,
                userId = user.userId,
                courseId = user.courseId,
                progressPercent = user.progressPercent,
                status = user.status,
                grade = user.grade,
                certificateURL = user.certificateURL,
                completedAt = user.completedAt
            };
        }
    }
}