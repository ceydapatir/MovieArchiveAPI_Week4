using MovieArchiveAPI.Data.Context;
using MovieArchiveAPI.Data.Entities;

namespace MovieArchiveApi.UnitTests.TestsSetup
{
    public static class Directors
    {
        public static void AddDirector(this MovieArchiveDBContext context){
            context.Directors.AddRange(
                new Director{
                    Name = "Elemental",
                    Surname = "Director",
                    BirthDate = new DateTime(1980, 06, 24)
                },
                new Director{
                    Name = "Murder Mystery",
                    Surname = "Director",
                    BirthDate = new DateTime(1977, 02, 08)
                }
            );
        }
    }
}