using AutoMapper;
using FluentAssertions;
using MovieArchiveApi.UnitTests.TestsSetup;
using MovieArchiveAPI.Applications.GenreOperations.CreateGenre;
using MovieArchiveAPI.Data.Context;
using MovieArchiveAPI.Models.DTO;
using Xunit;

namespace GenreArchiveApi.UnitTests.Applications.GenreOperations.CreateGenre
{
    public class CreateGenreValidatorTests : IClassFixture<CommonTestFixture>
    {
        private readonly IMapper _mapper;
        private readonly MovieArchiveDBContext _context;

        public CreateGenreValidatorTests(CommonTestFixture testFixture){
            _context = testFixture.context;
            _mapper = testFixture.mapper;
        }
    /*
        [Theory]
        [InlineData("comedy", null)]
        [InlineData(null, true)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldReturnErrors(string name, bool isActive){
            //arrange
            var genreDTO = new GenreDTO(){
                Name = name,
                IsActive = isActive
            };

            //act
            CreateGenreCommand command = new CreateGenreCommand(_context, _mapper, genreDTO);
            CreateGenreValidator validator = new CreateGenreValidator();
            var result = validator.Validate(command);

            //asset
            result.Errors.Count.Should().BeGreaterThan(0);
        }
    */
    }
}