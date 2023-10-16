using AutoMapper;
using FluentAssertions;
using MovieArchiveApi.UnitTests.TestsSetup;
using MovieArchiveAPI.Applications.DirectorOperations.UpdateDirector;
using MovieArchiveAPI.Data.Context;
using MovieArchiveAPI.Models.DTO;
using Xunit;

namespace MovieArchiveApi.UnitTests.Applications.DirectorOperations.UpdateDirector
{
    public class UpdateDirectorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly IMapper _mapper;
        private readonly MovieArchiveDBContext _context;

        public UpdateDirectorCommandTests(CommonTestFixture testFixture){
            _context = testFixture.context;
            _mapper = testFixture.mapper;
        }

        // get all
        [Fact]
        public void WhenUnexistDirectorIdIsGiven_InvalidOperationException_ShouldBeReturn(){
            // arrange (hazırlık)
            foreach (var item in _context.Directors)
            {
                _context.Directors.Remove(item);
            }
            _context.SaveChanges();

            var director = new DirectorDTO();
            UpdateDirectorCommand command = new UpdateDirectorCommand(_context, _mapper, director);

            // act (çalıştırma)
            // assert (doğrulama)
            FluentActions.Invoking(() => command.Handle(1)).Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("The director doesn't exist.");
        }
    }
}