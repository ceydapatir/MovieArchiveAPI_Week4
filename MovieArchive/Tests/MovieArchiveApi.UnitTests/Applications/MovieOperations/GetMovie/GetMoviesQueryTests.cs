
using AutoMapper;
using FluentAssertions;
using MovieArchiveApi.UnitTests.TestsSetup;
using MovieArchiveAPI.Applications.MovieOperations.GetMovie;
using MovieArchiveAPI.Applications.MovieOperations.GetMovieById;
using MovieArchiveAPI.Applications.MovieOperations.GetMovieByName;
using MovieArchiveAPI.Applications.MovieOperations.GetMoviesByYear;
using MovieArchiveAPI.Data.Context;
using Xunit;

namespace MovieArchiveApi.UnitTests.Applications.MovieOperations.GetMovie
{
    public class GetMoviesQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly IMapper _mapper;
        private readonly MovieArchiveDBContext _context;

        public GetMoviesQueryTests(CommonTestFixture testFixture){
            _context = testFixture.context;
            _mapper = testFixture.mapper;
        }

        // get all
        [Fact]
        public void WhenNoMovies_InvalidOperationException_ShouldBeReturn(){
            // arrange (hazırlık)
            foreach (var item in _context.Movies)
            {
                _context.Movies.Remove(item);
            }
            _context.SaveChanges();

            GetMoviesQuery query = new GetMoviesQuery(_context, _mapper);

            // act (çalıştırma)
            // assert (doğrulama)
            FluentActions.Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("There are no movies.");
        }

        // get by id
        [Fact]
        public void WhenUnexistMovieIdIsGiven_InvalidOperationException_ShouldBeReturn(){
            // arrange (hazırlık)
            foreach (var item in _context.Movies)
            {
                _context.Movies.Remove(item);
            }
            _context.SaveChanges();

            GetMovieByIdQuery query = new GetMovieByIdQuery(_context, _mapper, 1);

            // act (çalıştırma)
            // assert (doğrulama)
            FluentActions.Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("The movie doesn't exist.");
        }

        // get by name
        [Fact]
        public void WhenUnexistMovieNameIsGiven_InvalidOperationException_ShouldBeReturn(){
            // arrange (hazırlık)
            foreach (var item in _context.Movies)
            {
                _context.Movies.Remove(item);
            }
            _context.SaveChanges();

            GetMovieByNameQuery query = new GetMovieByNameQuery(_context, _mapper, "Barbie");

            // act (çalıştırma)
            // assert (doğrulama)
            FluentActions.Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("The movie doesn't exist.");
        }

        // get by year
        [Fact]
        public void WhenUnexistMovieYearIsGiven_InvalidOperationException_ShouldBeReturn(){
            // arrange (hazırlık)
            foreach (var item in _context.Movies)
            {
                _context.Movies.Remove(item);
            }
            _context.SaveChanges();

            GetMoviesByYearQuery query = new GetMoviesByYearQuery(_context, _mapper, 2002);

            // act (çalıştırma)
            // assert (doğrulama)
            FluentActions.Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("No movie found for this year.");
        }
    }
}