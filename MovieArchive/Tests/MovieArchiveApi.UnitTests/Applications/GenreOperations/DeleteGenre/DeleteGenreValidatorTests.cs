using FluentAssertions;
using MovieArchiveApi.UnitTests.TestsSetup;
using MovieArchiveAPI.Applications.GenreOperations.DeleteGenre;
using MovieArchiveAPI.Data.Context;
using Xunit;

namespace MovieArchiveApi.UnitTests.Applications.GenreOperations.DeleteGenre
{
    public class DeleteGenreValidatorTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieArchiveDBContext _context;

        public DeleteGenreValidatorTests(CommonTestFixture testFixture){
            _context = testFixture.context;
        }

        [Theory]
        [InlineData(-1)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldReturnErrors(int id){
            //arrange
            //act
            DeleteGenreCommand command = new DeleteGenreCommand(_context, id);
            DeleteGenreValidator validator = new DeleteGenreValidator();
            var result = validator.Validate(command);

            //asset
            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}