using AutoMapper;
using FluentAssertions;
using MovieArchiveApi.UnitTests.TestsSetup;
using MovieArchiveAPI.Applications.GenreOperations.UpdateGenre;
using MovieArchiveAPI.Data.Context;
using MovieArchiveAPI.Models.DTO;
using Xunit;

namespace MovieArchiveApi.UnitTests.Applications.GenreOperations.UpdateGenre
{
    public class UpdateGenreCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly IMapper _mapper;
        private readonly MovieArchiveDBContext _context;

        public UpdateGenreCommandTests(CommonTestFixture testFixture){
            _context = testFixture.context;
            _mapper = testFixture.mapper;
        }

        // get all
        [Fact]
        public void WhenUnexistGenreIdIsGiven_InvalidOperationException_ShouldBeReturn(){
            // arrange (hazırlık)
            foreach (var item in _context.Genres)
            {
                _context.Genres.Remove(item);
            }
            _context.SaveChanges();

            var genre = new GenreDTO();
            UpdateGenreCommand command = new UpdateGenreCommand(_context, _mapper, genre);

            // act (çalıştırma)
            // assert (doğrulama)
            FluentActions.Invoking(() => command.Handle(1)).Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("The genre doesn't exist.");
        }
    }
}