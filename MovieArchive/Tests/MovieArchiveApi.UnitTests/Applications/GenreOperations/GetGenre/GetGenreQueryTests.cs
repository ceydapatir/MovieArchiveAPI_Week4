using AutoMapper;
using FluentAssertions;
using MovieArchiveApi.UnitTests.TestsSetup;
using MovieArchiveAPI.Applications.GenreOperations.GetGenre;
using MovieArchiveAPI.Applications.GenreOperations.GetGenreById;
using MovieArchiveAPI.Applications.GenreOperations.GetGenreByName;
using MovieArchiveAPI.Data.Context;
using Xunit;

namespace MovieArchiveApi.UnitTests.Applications.GenreOperations.GetGenre
{
    public class GetGenreQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly IMapper _mapper;
        private readonly MovieArchiveDBContext _context;

        public GetGenreQueryTests(CommonTestFixture testFixture){
            _context = testFixture.context;
            _mapper = testFixture.mapper;
        }

        // get all
        [Fact]
        public void WhenNoGenres_InvalidOperationException_ShouldBeReturn(){
            // arrange (hazırlık)
            foreach (var item in _context.Genres)
            {
                _context.Genres.Remove(item);
            }
            _context.SaveChanges();

            GetGenreQuery query = new GetGenreQuery(_context, _mapper);

            // act (çalıştırma)
            // assert (doğrulama)
            FluentActions.Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("There are no genres.");
        }

        // get by id
        [Fact]
        public void WhenUnexistGenreIdIsGiven_InvalidOperationException_ShouldBeReturn(){
            // arrange (hazırlık)
            foreach (var item in _context.Genres)
            {
                _context.Genres.Remove(item);
            }
            _context.SaveChanges();

            GetGenreByIdQuery query = new GetGenreByIdQuery(_context, _mapper, 1);

            // act (çalıştırma)
            // assert (doğrulama)
            FluentActions.Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("The genre doesn't exist.");
        }

        // get by name
        [Fact]
        public void WhenUnexistGenreNameIsGiven_InvalidOperationException_ShouldBeReturn(){
            // arrange (hazırlık)
            foreach (var item in _context.Genres)
            {
                _context.Genres.Remove(item);
            }
            _context.SaveChanges();

            GetGenreByNameQuery query = new GetGenreByNameQuery(_context, _mapper, "Comedy");

            // act (çalıştırma)
            // assert (doğrulama)
            FluentActions.Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("The genre doesn't exist.");
        }
    }
}