using AutoMapper;
using FluentAssertions;
using MovieArchiveApi.UnitTests.TestsSetup;
using MovieArchiveAPI.Applications.GenreOperations.GetGenreById;
using MovieArchiveAPI.Applications.GenreOperations.GetGenreByName;
using MovieArchiveAPI.Data.Context;
using Xunit;

namespace MovieArchiveApi.UnitTests.Applications.GenreOperations.GetGenreById
{
    public class GetGenreByIdValidatorTests : IClassFixture<CommonTestFixture>
    {
        private readonly IMapper _mapper;
        private readonly MovieArchiveDBContext _context;

        public GetGenreByIdValidatorTests(CommonTestFixture testFixture){
            _context = testFixture.context;
            _mapper = testFixture.mapper;
        }

        [Theory]
        [InlineData(-1)]
        public void WhenInvalidInputsAreGivenGenreId_Validator_ShouldReturnErrors(int id){
            //arrange
            //act
            GetGenreByIdQuery query = new GetGenreByIdQuery(_context, _mapper, id);
            GetGenreByIdValidator validator = new GetGenreByIdValidator();
            var result = validator.Validate(query);

            //asset
            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Theory]
        [InlineData(null)]
        public void WhenInvalidInputsAreGivenGenreName_Validator_ShouldReturnErrors(string name){
            //arrange
            //act
            GetGenreByNameQuery query = new GetGenreByNameQuery(_context, _mapper, name);
            GetGenreByNameValidator validator = new GetGenreByNameValidator();
            var result = validator.Validate(query);

            //asset
            result.Errors.Count.Should().BeGreaterThan(0);
        }

    }
}