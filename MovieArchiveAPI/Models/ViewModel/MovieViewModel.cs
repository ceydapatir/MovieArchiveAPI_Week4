using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieArchiveAPI.Models.ViewModel
{
    public class MovieViewModel
    {
        public int MovieId { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public double IMDB { get; set; }
        public string Genre { get; set; }
        public string PublishDate { get; set; }
        public string ImageURL { get; set; }
    }
}