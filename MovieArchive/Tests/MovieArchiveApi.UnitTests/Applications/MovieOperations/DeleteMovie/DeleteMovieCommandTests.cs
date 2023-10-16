using FluentAssertions;
using MovieArchiveApi.UnitTests.TestsSetup;
using MovieArchiveAPI.Applications.MovieOperations.DeleteMovie;
using MovieArchiveAPI.Data.Context;
using MovieArchiveAPI.Data.Entities;
using Xunit;

namespace MovieArchiveApi.UnitTests.Applications.MovieOperations.DeleteMovie
{
    public class DeleteMovieCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieArchiveDBContext _context;

        public DeleteMovieCommandTests(CommonTestFixture testFixture){
            _context = testFixture.context;
        }

        [Fact]
        public void WhenUnexistMovieIdIsGiven_InvalidOperationException_ShouldBeReturn(){
            // arrange (hazırlık)
            foreach (var item in _context.Movies)
            {
                _context.Movies.Remove(item);
            }
            _context.SaveChanges();

            DeleteMovieCommand command = new DeleteMovieCommand(_context, 1);

            // act (çalıştırma)
            // assert (doğrulama)
            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("The movie doesn't exist.");
        }
    }
}