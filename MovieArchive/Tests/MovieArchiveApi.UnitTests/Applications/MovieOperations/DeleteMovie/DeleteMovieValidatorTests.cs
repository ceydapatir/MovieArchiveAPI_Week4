using AutoMapper;
using FluentAssertions;
using MovieArchiveApi.UnitTests.TestsSetup;
using MovieArchiveAPI.Applications.MovieOperations.DeleteMovie;
using MovieArchiveAPI.Data.Context;
using Xunit;

namespace MovieArchiveApi.UnitTests.Applications.MovieOperations.DeleteMovie
{
    public class DeleteMovieValidatorTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieArchiveDBContext _context;

        public DeleteMovieValidatorTests(CommonTestFixture testFixture){
            _context = testFixture.context;
        }

        [Theory]
        [InlineData(-1)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldReturnErrors(int id){
            //arrange
            //act
            DeleteMovieCommand command = new DeleteMovieCommand(_context, id);
            DeleteMovieValidator validator = new DeleteMovieValidator();
            var result = validator.Validate(command);

            //asset
            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}