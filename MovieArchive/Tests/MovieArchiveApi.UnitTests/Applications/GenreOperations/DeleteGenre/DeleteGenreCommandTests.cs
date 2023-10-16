using FluentAssertions;
using MovieArchiveApi.UnitTests.TestsSetup;
using MovieArchiveAPI.Applications.GenreOperations.DeleteGenre;
using MovieArchiveAPI.Data.Context;
using Xunit;

namespace MovieArchiveApi.UnitTests.Applications.GenreOperations.DeleteGenre
{
    public class DeleteGenreCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieArchiveDBContext _context;

        public DeleteGenreCommandTests(CommonTestFixture testFixture){
            _context = testFixture.context;
        }

        [Fact]
        public void WhenUnexistMovieIdIsGiven_InvalidOperationException_ShouldBeReturn(){
            // arrange (hazırlık)
            foreach (var item in _context.Genres)
            {
                _context.Genres.Remove(item);
            }
            _context.SaveChanges();

            DeleteGenreCommand command = new DeleteGenreCommand(_context, 1);

            // act (çalıştırma)
            // assert (doğrulama)
            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("The genre doesn't exist.");
        }
    }
}