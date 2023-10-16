using FluentAssertions;
using MovieArchiveApi.UnitTests.TestsSetup;
using MovieArchiveAPI.Applications.DirectorOperations.DeleteDirector;
using MovieArchiveAPI.Data.Context;
using Xunit;

namespace MovieArchiveApi.UnitTests.Applications.DirectorOperations.DeleteDirector
{
    public class DeleteDirectorValidatorTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieArchiveDBContext _context;

        public DeleteDirectorValidatorTests(CommonTestFixture testFixture){
            _context = testFixture.context;
        }

        [Theory]
        [InlineData(-1)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldReturnErrors(int id){
            //arrange
            //act
            DeleteDirectorCommand command = new DeleteDirectorCommand(_context, id);
            DeleteDirectorValidator validator = new DeleteDirectorValidator();
            var result = validator.Validate(command);

            //asset
            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}