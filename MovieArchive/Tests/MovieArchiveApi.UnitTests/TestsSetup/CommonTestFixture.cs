using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieArchiveAPI.Common;
using MovieArchiveAPI.Data.Context;

namespace MovieArchiveApi.UnitTests.TestsSetup
{
    public class CommonTestFixture
    {
        public MovieArchiveDBContext context { get; set; }

        public IMapper mapper { get; set; }


        public CommonTestFixture()
        {
            // Projedeki esas veri tabanını etkilememesi adında test için yeni bir db oluşturulur
            var options = new DbContextOptionsBuilder<MovieArchiveDBContext>().UseInMemoryDatabase(databaseName: "MovieArchiveTestDB").Options;
            context = new MovieArchiveDBContext(options);
            context.Database.EnsureCreated();
            
            // context.AddDirector();
            // context.AddGenre();
            // context.AddMovie();

            mapper = new MapperConfiguration(cfg => {cfg.AddProfile<MapperProfile>();}).CreateMapper();
        }
        
    }
}