using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using FluentValidation;
using MovieArchiveApi.UnitTests.TestsSetup;
using MovieArchiveAPI.Applications.DirectorOperations.CreateDirector;
using MovieArchiveAPI.Data.Context;
using MovieArchiveAPI.Models.DTO;
using Xunit;

namespace MovieArchiveApi.UnitTests.Applications.DirectorOperations.CreateDirector
{
    public class CreateDirectorValidatorTests : IClassFixture<CommonTestFixture>
    {
        private readonly IMapper _mapper;
        private readonly MovieArchiveDBContext _context;

        public CreateDirectorValidatorTests(CommonTestFixture testFixture){
            _context = testFixture.context;
            _mapper = testFixture.mapper;
        }

        [Theory]
        [InlineData(null, "Black")]
        [InlineData("Arthur", null)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldReturnErrors(string name, string surname){
            //arrange
            var directorDTO = new DirectorDTO(){
                Name = name,
                Surname = surname,
                BirthDate = new DateTime(1977, 02, 08)
            };

            //act
            CreateDirectorCommand command = new CreateDirectorCommand(_context, _mapper, directorDTO);
            CreateDirectorValidator validator = new CreateDirectorValidator();
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
            CreateDirectorCommand command = new CreateDirectorCommand(_context, _mapper, directorDTO);
            CreateDirectorValidator validator = new CreateDirectorValidator();
            var result = validator.Validate(command);

            //asset
            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}