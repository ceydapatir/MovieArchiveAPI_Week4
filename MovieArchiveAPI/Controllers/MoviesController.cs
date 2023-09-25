using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MovieArchiveAPI.Data.Context;
using MovieArchiveAPI.Applications.MovieOperations.CreateMovie;
using MovieArchiveAPI.Applications.MovieOperations.DeleteMovie;
using MovieArchiveAPI.Applications.MovieOperations.GetMovie;
using MovieArchiveAPI.Applications.MovieOperations.UpdateMovie;
using MovieArchiveAPI.Applications.MovieOperations.GetMovieById;
using MovieArchiveAPI.Applications.MovieOperations.GetMovieByName;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieArchiveAPI.Models.ViewModel;
using MovieArchiveAPI.Models.DTO;
using MovieArchiveAPI.Applications.MovieOperations.GetMoviesByYear;

namespace MovieArchiveAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly MovieArchiveDBContext _context;

        public MoviesController(MovieArchiveDBContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }
        
        // GET: api/Movies
        [HttpGet]
        public IActionResult GetMovies() { 
            GetMoviesQuery query = new GetMoviesQuery(_context, _mapper);
            List<MovieViewModel> MovieList;
            try
            {
                MovieList = query.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(MovieList); 
        }

        // POST: api/Movies
        [HttpPost]
        public IActionResult CreateMovie([FromBody] MovieDTO model) { 
            CreateMovieCommand command = new CreateMovieCommand(_context, _mapper, model);
            CreateMovieValidator validator = new CreateMovieValidator(_context);
            try
            {
                validator.ValidateAndThrow(command); // Data check
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(); 
        }

        // GET: api/Movies/{id}
        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id) { 
            GetMovieByIdQuery query = new GetMovieByIdQuery(_context, _mapper, id);
            MovieViewModel Movie;
            try
            {
                Movie = query.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(Movie); 
        }

        // GET: api/Movies/name
        [HttpGet("name")]
        public IActionResult GetMovieByName([FromQuery] string name) { 
            GetMovieByNameQuery query = new GetMovieByNameQuery(_context, _mapper, name);
            MovieViewModel Movie;
            try
            {
                Movie = query.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(Movie); 
        }

        // GET: api/Movies/year
        [HttpGet("year")]
        public IActionResult GetMoviesByYear([FromQuery] int year) { 
            GetMoviesByYearQuery query = new GetMoviesByYearQuery(_context, _mapper, year);
            List<MovieViewModel> MovieList;
            try
            {
                MovieList = query.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(MovieList); 
        }

        // PUT: api/Movies/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] MovieDTO model) { 
            UpdateMovieCommand command = new UpdateMovieCommand(_context, _mapper, id, model);
            UpdateMovieValidator validator = new UpdateMovieValidator(_context);
            try
            {
                validator.ValidateAndThrow(command); // Data check
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(); 
        }

        // DELETE: api/Movies/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id) { 
            DeleteMovieCommand command = new DeleteMovieCommand(_context, id);
            DeleteMovieValidator validator = new DeleteMovieValidator();
            try
            {
                validator.ValidateAndThrow(command); // Data check
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(); 
        }
    }
}