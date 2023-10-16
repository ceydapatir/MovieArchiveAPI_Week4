using AutoMapper;
using FluentAssertions;
using MovieArchiveApi.UnitTests.TestsSetup;
using MovieArchiveAPI.Applications.MovieOperations.GetMovieById;
using MovieArchiveAPI.Applications.MovieOperations.GetMovieByName;
using MovieArchiveAPI.Applications.MovieOperations.GetMoviesByYear;
using MovieArchiveAPI.Data.Context;
using Xunit;

namespace MovieArchiveApi.UnitTests.Applications.MovieOperations.GetMovie
{
    public class GetMovieValidatorTests : IClassFixture<CommonTestFixture>
    {
        private readonly IMapper _mapper;
        private readonly MovieArchiveDBContext _context;

        public GetMovieValidatorTests(CommonTestFixture testFixture){
            _context = testFixture.context;
            _mapper = testFixture.mapper;
        }

        [Theory]
        [InlineData(-1)]
        public void WhenInvalidInputsAreGivenMovieId_Validator_ShouldReturnErrors(int id){
            //arrange
            //act
            GetMovieByIdQuery query = new GetMovieByIdQuery(_context, _mapper, id);
            GetMovieByIdValidator validator = new GetMovieByIdValidator();
            var result = validator.Validate(query);

            //asset
            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Theory]
        [InlineData(null)]
        public void WhenInvalidInputsAreGivenMovieName_Validator_ShouldReturnErrors(string name){
            //arrange
            //act
            GetMovieByNameQuery query = new GetMovieByNameQuery(_context, _mapper, name);
            GetMovieByNameValidator validator = new GetMovieByNameValidator();
            var result = validator.Validate(query);

            //asset
            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Theory]
        [InlineData(-1)]
        public void WhenInvalidInputsAreGivenMovieYear_Validator_ShouldReturnErrors(int year){
            //arrange
            //act
            GetMoviesByYearQuery query = new GetMoviesByYearQuery(_context, _mapper, year);
            GetMoviesByYearValidator validator = new GetMoviesByYearValidator();
            var result = validator.Validate(query);

            //asset
            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}