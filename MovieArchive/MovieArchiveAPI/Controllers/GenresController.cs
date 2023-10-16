using AutoMapper;
using MovieArchiveAPI.Applications.GenreOperations.CreateGenre;
using MovieArchiveAPI.Applications.GenreOperations.DeleteGenre;
using MovieArchiveAPI.Applications.GenreOperations.GetGenre;
using MovieArchiveAPI.Applications.GenreOperations.GetGenreById;
using MovieArchiveAPI.Applications.GenreOperations.GetGenreByName;
using MovieArchiveAPI.Applications.GenreOperations.UpdateGenre;
using MovieArchiveAPI.Data.Context;
using MovieArchiveAPI.Models.DTO;
using MovieArchiveAPI.Models.ViewModel;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace MovieArchiveAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenresController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMovieArchiveDBContext _context;

        public GenresController(IMovieArchiveDBContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }
        
        // GET: api/Genres
        [HttpGet]
        public IActionResult GetGenres() { 
            GetGenreQuery query = new GetGenreQuery(_context, _mapper);
            List<GenreViewModel> GenreList;
            try
            {
                GenreList = query.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(GenreList); 
        }

        // POST: api/Genres
        [HttpPost]
        public IActionResult CreateGenre([FromBody] GenreDTO model) { 
            CreateGenreCommand command = new CreateGenreCommand(_context, _mapper, model);
            CreateGenreValidator validator = new CreateGenreValidator();
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

        // GET: api/Genres/{id}
        [HttpGet("{id}")]
        public IActionResult GetGenreById(int id) { 
            GetGenreByIdQuery query = new GetGenreByIdQuery(_context, _mapper, id);
            GenreViewModel Genre;
            try
            {
                Genre = query.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(Genre); 
        }

        // GET: api/Genres/name
        [HttpGet("name")]
        public IActionResult GetGenreByName([FromQuery] string name) { 
            GetGenreByNameQuery query = new GetGenreByNameQuery(_context, _mapper, name);
            GenreViewModel Genre;
            try
            {
                Genre = query.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(Genre); 
        }

        // PUT: api/Genres/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateGenre(int id, [FromBody] GenreDTO model) { 
            UpdateGenreCommand command = new UpdateGenreCommand(_context, _mapper, model);
            UpdateGenreValidator validator = new UpdateGenreValidator();
            try
            {
                validator.ValidateAndThrow(command); // Data check
                command.Handle(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(); 
        }

        // DELETE: api/Genres/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id) { 
            DeleteGenreCommand command = new DeleteGenreCommand(_context, id);
            DeleteGenreValidator validator = new DeleteGenreValidator();
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