using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ascendix_Backend.Dto.LibraryDto
{
    public class UpdateLibrary
    {
        public  string? libraryName { get; set; }
        public  string? slug { get; set; }
    }
}