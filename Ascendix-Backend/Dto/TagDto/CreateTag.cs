using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ascendix_Backend.Dto.TagDto
{
    public class CreateTag
    {
        public required string name { get; set; }
        public required string slug { get; set; }
    }
}