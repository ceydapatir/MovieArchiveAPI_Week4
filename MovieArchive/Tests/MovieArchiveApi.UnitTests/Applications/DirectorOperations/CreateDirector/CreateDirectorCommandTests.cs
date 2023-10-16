using AutoMapper;
using FluentAssertions;
using MovieArchiveApi.UnitTests.TestsSetup;
using MovieArchiveAPI.Applications.DirectorOperations.CreateDirector;
using MovieArchiveAPI.Data.Context;
using MovieArchiveAPI.Data.Entities;
using MovieArchiveAPI.Models.DTO;
using Xunit;

namespace MovieArchiveApi.UnitTests.Applications.DirectorOperations.CreateDirector
{
    public class CreateDirectorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly IMapper _mapper;
        private readonly MovieArchiveDBContext _context;

        public CreateDirectorCommandTests(CommonTestFixture testFixture){
            _context = testFixture.context;
            _mapper = testFixture.mapper;
        }

        [Fact]
        public void WhenAlreadyExistDirectorNameIsGiven_InvalidOperationException_ShouldBeReturn(){
            // arrange (hazırlık)
            var directorDTO = new DirectorDTO(){
                Name = "Murder Mystery",
                Surname = "Director",
                BirthDate = new DateTime(1977, 02, 08)
            };
            var director = _mapper.Map<Director>(directorDTO);
            _context.Directors.Add(director);
            _context.SaveChanges();

            CreateDirectorCommand command = new CreateDirectorCommand(_context, _mapper, directorDTO);

            // act (çalıştırma)
            // assert (doğrulama)
            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("The director already exists.");
        }
    }
}