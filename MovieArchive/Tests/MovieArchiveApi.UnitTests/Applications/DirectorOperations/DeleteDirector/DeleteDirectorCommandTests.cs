using FluentAssertions;
using MovieArchiveApi.UnitTests.TestsSetup;
using MovieArchiveAPI.Applications.DirectorOperations.DeleteDirector;
using MovieArchiveAPI.Data.Context;
using Xunit;

namespace MovieArchiveApi.UnitTests.Applications.DirectorOperations.DeleteDirector
{
    public class DeleteDirectorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieArchiveDBContext _context;

        public DeleteDirectorCommandTests(CommonTestFixture testFixture){
            _context = testFixture.context;
        }

        [Fact]
        public void WhenUnexistMovieIdIsGiven_InvalidOperationException_ShouldBeReturn(){
            // arrange (hazırlık)
            foreach (var item in _context.Directors)
            {
                _context.Directors.Remove(item);
            }
            _context.SaveChanges();

            DeleteDirectorCommand command = new DeleteDirectorCommand(_context, 1);

            // act (çalıştırma)
            // assert (doğrulama)
            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("The director doesn't exist.");
        }
    }
}