using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Models;

namespace Ascendix_Backend.Dto.UserModuleDto
{
    public class ViewUserModule
    {
        public Guid id { get; set; }
        public Guid moduleId { get; set; }
        public string? userId { get; set; }
        public Status status { get; set; }
        public int progressPercent { get; set; }
    }
}