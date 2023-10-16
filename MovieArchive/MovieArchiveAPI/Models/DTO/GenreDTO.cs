using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieArchiveAPI.Models.DTO
{
    public class GenreDTO
    {
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
    }
}