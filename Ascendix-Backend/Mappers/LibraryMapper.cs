using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.LibraryDto;
using Ascendix_Backend.Models;

namespace Ascendix_Backend.Mappers
{
    public static class LibraryMapper
    {
        public static Library toLibrary(this CreateLibrary create)
        {
            return new Library
            {
                libraryName = create.libraryName,
                Description = create.Description,
            };
        }

        public static ViewLibrary viewLibrary(this Library library)
        {
            return new ViewLibrary
            {
                libraryName = library.libraryName,
            };
        }
    }
}