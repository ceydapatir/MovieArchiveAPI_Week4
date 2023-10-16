using AutoMapper;
using FluentAssertions;
using MovieArchiveApi.UnitTests.TestsSetup;
using MovieArchiveAPI.Applications.DirectorOperations.UpdateDirector;
using MovieArchiveAPI.Data.Context;
using MovieArchiveAPI.Models.DTO;
using Xunit;

namespace MovieArchiveApi.UnitTests.Applications.DirectorOperations.UpdateDirector
{
    public class UpdateDirectorValidatorTests : IClassFixture<CommonTestFixture>
    {
        private readonly IMapper _mapper;
        private readonly MovieArchiveDBContext _context;

        public UpdateDirectorValidatorTests(CommonTestFixture testFixture){
            _context = testFixture.context;
            _mapper = testFixture.mapper;
        }

        [Theory]
        [InlineData(null, "Brown")]
        [InlineData("Joseph", null)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldReturnErrors(string name, string surname){
            //arrange
            var directorDTO = new DirectorDTO(){
                Name = name,
                Surname = surname,
                BirthDate = new DateTime(1977, 02, 08)
            };

            //act
            UpdateDirectorCommand command = new UpdateDirectorCommand(_context, _mapper, directorDTO);
            UpdateDirectorValidator validator = new UpdateDirectorValidator();
            var result = validator.Validate(command);

            //asset
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenDirectAgeLessThanEigthteen_Validator_ShouldReturnErrors(){
            //arrange
            var directorDTO = new DirectorDTO(){
                Name = "Joseph",
                Surname = "Brown",
                BirthDate = DateTime.Now.Date.AddYears(-2)
            };

            //act
            UpdateDirectorCommand command = new UpdateDirectorCommand(_context, _mapper, directorDTO);
            UpdateDirectorValidator validator = new UpdateDirectorValidator();
            var result = validator.Validate(command);

            //asset
            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}