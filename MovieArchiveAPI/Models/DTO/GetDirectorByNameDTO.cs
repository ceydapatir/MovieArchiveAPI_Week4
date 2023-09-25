using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieArchiveAPI.Models.DTO
{
    public class GetDirectorByNameDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}