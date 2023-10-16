using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieArchiveAPI.Models.DTO
{
    public class MovieDTO
    {
        public string Name { get; set; }
        public int DirectorId { get; set; }
        public int GenreId { get; set; }
        public double IMDB { get; set; }
        public DateTime PublishDate { get; set; }
        public string ImageURL { get; set; }
    }
}