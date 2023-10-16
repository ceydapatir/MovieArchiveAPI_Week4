using MovieArchiveAPI.Data.Context;
using MovieArchiveAPI.Data.Entities;

namespace MovieArchiveApi.UnitTests.TestsSetup
{
    public static class Movies
    {
        public static void AddMovie(this MovieArchiveDBContext context){
            context.Movies.AddRange(
                new Movie{
                    DirectorId = 1,
                    GenreId = 1,
                    Name = "Elemental",
                    IMDB = 7.1,
                    PublishDate = new DateTime(2023, 06, 12),
                    ImageURL = "elemental.png"
                },
                new Movie{
                    DirectorId = 2,
                    GenreId = 2,
                    Name = "Murder Mystery",
                    IMDB = 6.7,
                    PublishDate = new DateTime(2022, 07, 21),
                    ImageURL = "murdermystery.png"
                },
                new Movie{
                    DirectorId = 1,
                    GenreId = 1,
                    Name = "Barbie",
                    IMDB = 6.7,
                    PublishDate = new DateTime(2023, 06, 12),
                    ImageURL = "barbie.png"
                }
            );
        }
    }
}