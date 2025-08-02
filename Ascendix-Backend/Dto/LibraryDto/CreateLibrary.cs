using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ascendix_Backend.Dto.LibraryDto
{
    public class CreateLibrary
    {
        public string libraryName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}