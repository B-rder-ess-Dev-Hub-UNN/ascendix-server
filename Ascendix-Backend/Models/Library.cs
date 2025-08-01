using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ascendix_Backend.Models
{
    public class Library
    {
        [Key]
        public Guid libraryId { get; set; }
        public string libraryName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public ICollection<Course> courses { get; set; } = new List<Course>();
    }
}