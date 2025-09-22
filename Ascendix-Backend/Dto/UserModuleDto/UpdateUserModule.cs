using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Models;

namespace Ascendix_Backend.Dto.UserModuleDto
{
    public class UpdateUserModule
    {
        public Guid? moduleId { get; set; }
        public Status? status { get; set; }
        public decimal? progressPercent { get; set; }
    }
}