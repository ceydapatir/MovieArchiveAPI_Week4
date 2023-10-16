using AutoMapper;
using FluentAssertions;
using MovieArchiveApi.UnitTests.TestsSetup;
using MovieArchiveAPI.Applications.MovieOperations.CreateMovie;
using MovieArchiveAPI.Data.Context;
using MovieArchiveAPI.Models.DTO;
using Xunit;

namespace MovieArchiveApi.UnitTests.Applications.MovieOperations.CreateMovie
{
    public class CreateMovieValidatorTests : IClassFixture<CommonTestFixture>
    {
        private readonly IMapper _mapper;
        private readonly MovieArchiveDBContext _context;

        public CreateMovieValidatorTests(CommonTestFixture testFixture){
            _context = testFixture.context;
            _mapper = testFixture.mapper;
        }

        [Theory]
        [InlineData(-1, 1, "Barbie", 6.7, "barbie.png")]
        [InlineData(1, -1, "Barbie", 6.7, "barbie.png")]
        [InlineData(1, 1, null, 6.7, "barbie.png")]
        [InlineData(1, 1, "Barbie", -1, "barbie.png")]
        [InlineData(1, 1, "Barbie", 6.7, null)]
        [InlineData(1, 1, "Barbie", -1, null)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldReturnErrors(int directorId, int genreId, string name, double imdb, string imgUrl){
            //arrange
            var movieDTO = new MovieDTO(){
                DirectorId = directorId,
                GenreId = genreId,
                Name = name,
                IMDB = imdb,
                PublishDate = new DateTime(2023, 06, 12),
                ImageURL = imgUrl
            };

            //act
            CreateMovieCommand command = new CreateMovieCommand(_context, _mapper, movieDTO);
            CreateMovieValidator validator = new CreateMovieValidator(_context);
            var result = validator.Validate(command);

            //asset
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenPublishDateEqualOrGreaterThanNow_Validator_ShouldReturnErrors(){
            //arrange
            var movieDTO = new MovieDTO(){
                DirectorId = 1,
                GenreId = 1,
                Name = "Lord Of The Rings",
                IMDB = 8.9,
                PublishDate = DateTime.Now,
                ImageURL = "lotr.png"
            };
            //act
            CreateMovieCommand command = new CreateMovieCommand(_context, _mapper, movieDTO);
            CreateMovieValidator validator = new CreateMovieValidator(_context);
            var result = validator.Validate(command);

            //asset
            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}