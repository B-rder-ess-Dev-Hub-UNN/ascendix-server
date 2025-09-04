using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.TagDto;
using Ascendix_Backend.Models;

namespace Ascendix_Backend.Mappers
{
    public static class TagMapper
    {
        public static Tag toTag(this CreateTag create)
        {
            return new Tag
            {
                name = create.name,
                slug = create.slug
            };
        }

        public static ViewTag fromTag(this Tag tag)
        {
            return new ViewTag
            { 
                id = tag.id,
                name = tag.name,
                slug = tag.slug
            };
        }
    }
}