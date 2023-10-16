using AutoMapper;
using FluentAssertions;
using MovieArchiveApi.UnitTests.TestsSetup;
using MovieArchiveAPI.Applications.DirectorOperations.GetDirector;
using MovieArchiveAPI.Applications.DirectorOperations.GetDirectorById;
using MovieArchiveAPI.Applications.DirectorOperations.GetDirectorByName;
using MovieArchiveAPI.Data.Context;
using MovieArchiveAPI.Models.DTO;
using Xunit;

namespace MovieArchiveApi.UnitTests.Applications.DirectorOperations.GetDirector
{
    public class GetDirectorQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly IMapper _mapper;
        private readonly MovieArchiveDBContext _context;

        public GetDirectorQueryTests(CommonTestFixture testFixture){
            _context = testFixture.context;
            _mapper = testFixture.mapper;
        }

        // get all
        [Fact]
        public void WhenNoDirectors_InvalidOperationException_ShouldBeReturn(){
            // arrange (hazırlık)
            foreach (var item in _context.Directors)
            {
                _context.Directors.Remove(item);
            }
            _context.SaveChanges();

            GetDirectorQuery query = new GetDirectorQuery(_context, _mapper);

            // act (çalıştırma)
            // assert (doğrulama)
            FluentActions.Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("There are no directors.");
        }

        // get by id
        [Fact]
        public void WhenUnexistDirectorIdIsGiven_InvalidOperationException_ShouldBeReturn(){
            // arrange (hazırlık)
            foreach (var item in _context.Directors)
            {
                _context.Directors.Remove(item);
            }
            _context.SaveChanges();

            GetDirectorByIdQuery query = new GetDirectorByIdQuery(_context, _mapper, 1);

            // act (çalıştırma)
            // assert (doğrulama)
            FluentActions.Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("The director doesn't exist.");
        }

        // get by name
        [Fact]
        public void WhenUnexistDirectorNameIsGiven_InvalidOperationException_ShouldBeReturn(){
            // arrange (hazırlık)
            foreach (var item in _context.Directors)
            {
                _context.Directors.Remove(item);
            }
            _context.SaveChanges();

            var directorDTO = new GetDirectorByNameDTO(){
                Name = "Joseph",
                Surname = "Brown"
            };

            GetDirectorByNameQuery query = new GetDirectorByNameQuery(_context, _mapper, directorDTO);

            // act (çalıştırma)
            // assert (doğrulama)
            FluentActions.Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("The director doesn't exist.");
        }
    }
}