using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovieArchiveAPI.Data.Entities
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieId { get; set; }
        public int DirectorId { get; set; }
        public int GenreId { get; set; }
        public string Name { get; set; }
        public double IMDB { get; set; }
        public DateTime PublishDate { get; set; }
        public string ImageURL { get; set; }

        public Genre Genre { get; set; }
        public Director Director { get; set; }
    }
}