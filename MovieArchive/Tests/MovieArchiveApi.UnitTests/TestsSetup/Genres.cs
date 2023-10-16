using MovieArchiveAPI.Data.Context;
using MovieArchiveAPI.Data.Entities;

namespace MovieArchiveApi.UnitTests.TestsSetup
{
    public static class Genres
    {
        public static void AddGenre(this MovieArchiveDBContext context){
            context.Genres.AddRange(
                new Genre{
                    Name = "Comedy",
                    IsActive = true
                },
                new Genre{
                    Name = "Action",
                    IsActive = true
                }
            );
        }
    }
}