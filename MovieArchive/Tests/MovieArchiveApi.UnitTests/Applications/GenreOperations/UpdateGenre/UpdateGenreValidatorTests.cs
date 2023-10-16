using AutoMapper;
using FluentAssertions;
using MovieArchiveApi.UnitTests.TestsSetup;
using MovieArchiveAPI.Applications.GenreOperations.UpdateGenre;
using MovieArchiveAPI.Data.Context;
using MovieArchiveAPI.Models.DTO;
using Xunit;

namespace MovieArchiveApi.UnitTests.Applications.GenreOperations.UpdateGenre
{
    public class UpdateGenreValidatorTests : IClassFixture<CommonTestFixture>
    {
        private readonly IMapper _mapper;
        private readonly MovieArchiveDBContext _context;

        public UpdateGenreValidatorTests(CommonTestFixture testFixture){
            _context = testFixture.context;
            _mapper = testFixture.mapper;
        }

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
            UpdateGenreCommand command = new UpdateGenreCommand(_context, _mapper, genreDTO);
            UpdateGenreValidator validator = new UpdateGenreValidator();
            var result = validator.Validate(command);

            //asset
            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}