using AutoMapper;
using FluentAssertions;
using MovieArchiveApi.UnitTests.TestsSetup;
using MovieArchiveAPI.Applications.DirectorOperations.GetDirectorById;
using MovieArchiveAPI.Applications.DirectorOperations.GetDirectorByName;
using MovieArchiveAPI.Data.Context;
using MovieArchiveAPI.Models.DTO;
using Xunit;

namespace MovieArchiveApi.UnitTests.Applications.DirectorOperations.GetDirectorById
{
    public class GetDirectorByIdValidatorTests : IClassFixture<CommonTestFixture>
    {
        private readonly IMapper _mapper;
        private readonly MovieArchiveDBContext _context;

        public GetDirectorByIdValidatorTests(CommonTestFixture testFixture){
            _context = testFixture.context;
            _mapper = testFixture.mapper;
        }

        [Theory]
        [InlineData(-1)]
        public void WhenInvalidInputsAreGivenDirectorId_Validator_ShouldReturnErrors(int id){
            //arrange
            //act
            GetDirectorByIdQuery query = new GetDirectorByIdQuery(_context, _mapper, id);
            GetDirectorByIdValidator validator = new GetDirectorByIdValidator();
            var result = validator.Validate(query);

            //asset
            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Theory]
        [InlineData(null, "Brown")]
        [InlineData("Joseph", null)]
        public void WhenInvalidInputsAreGivenDirectorName_Validator_ShouldReturnErrors(string name, string surname){
            //arrange
            var directorDTO = new GetDirectorByNameDTO(){
                Name = name,
                Surname = surname
            };
            //act
            GetDirectorByNameQuery query = new GetDirectorByNameQuery(_context, _mapper, directorDTO);
            GetDirectorByNameValidator validator = new GetDirectorByNameValidator();
            var result = validator.Validate(query);

            //asset
            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}