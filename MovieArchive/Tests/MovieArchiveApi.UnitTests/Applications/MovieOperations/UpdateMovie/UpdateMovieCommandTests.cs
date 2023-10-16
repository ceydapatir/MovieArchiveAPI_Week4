using AutoMapper;
using FluentAssertions;
using MovieArchiveApi.UnitTests.TestsSetup;
using MovieArchiveAPI.Applications.MovieOperations.UpdateMovie;
using MovieArchiveAPI.Data.Context;
using MovieArchiveAPI.Models.DTO;
using Xunit;

namespace MovieArchiveApi.UnitTests.Applications.MovieOperations.UpdateMovie
{
    public class UpdateMovieCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly IMapper _mapper;
        private readonly MovieArchiveDBContext _context;

        public UpdateMovieCommandTests(CommonTestFixture testFixture){
            _context = testFixture.context;
            _mapper = testFixture.mapper;
        }

        // get all
        [Fact]
        public void WhenUnexistMovieIdIsGiven_InvalidOperationException_ShouldBeReturn(){
            // arrange (hazırlık)
            foreach (var item in _context.Movies)
            {
                _context.Movies.Remove(item);
            }
            _context.SaveChanges();

            var movie = new MovieDTO();
            UpdateMovieCommand command = new UpdateMovieCommand(_context, _mapper, movie);

            // act (çalıştırma)
            // assert (doğrulama)
            FluentActions.Invoking(() => command.Handle(1)).Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("The movie doesn't exist.");
        }
    }
}