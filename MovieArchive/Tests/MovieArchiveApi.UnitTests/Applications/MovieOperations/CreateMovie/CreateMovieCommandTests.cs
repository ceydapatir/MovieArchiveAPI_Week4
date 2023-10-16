using AutoMapper;
using FluentAssertions;
using MovieArchiveApi.UnitTests.TestsSetup;
using MovieArchiveAPI.Applications.MovieOperations.CreateMovie;
using MovieArchiveAPI.Data.Context;
using MovieArchiveAPI.Data.Entities;
using MovieArchiveAPI.Models.DTO;
using Xunit;

namespace MovieArchiveApi.UnitTests.Applications.MovieOperations.CreateMovie
{
    public class CreateMovieCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly IMapper _mapper;
        private readonly MovieArchiveDBContext _context;

        public CreateMovieCommandTests(CommonTestFixture testFixture){
            _context = testFixture.context;
            _mapper = testFixture.mapper;
        }

        [Fact]
        public void WhenAlreadyExistMovieNameIsGiven_InvalidOperationException_ShouldBeReturn(){
            // arrange (hazırlık)
            var movieDTO = new MovieDTO(){
                DirectorId = 1,
                GenreId = 1,
                Name = "Barbie",
                IMDB = 6.7,
                PublishDate = new DateTime(2023, 06, 12),
                ImageURL = "barbie.png"
            };
            var movie = _mapper.Map<Movie>(movieDTO);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            CreateMovieCommand command = new CreateMovieCommand(_context, _mapper, movieDTO);

            // act (çalıştırma)
            // assert (doğrulama)
            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("The movie already exists.");
        }
    }
}