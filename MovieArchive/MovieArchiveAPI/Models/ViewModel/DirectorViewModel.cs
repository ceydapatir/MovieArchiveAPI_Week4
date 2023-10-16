using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieArchiveAPI.Models.ViewModel
{
    public class DirectorViewModel
    {
        public int DirectorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BirthDate { get; set; }
    }
}