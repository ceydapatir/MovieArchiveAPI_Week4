using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieArchiveAPI.Models.ViewModel
{
    public class GenreViewModel
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
    }
}