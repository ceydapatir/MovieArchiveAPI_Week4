using AutoMapper;
using MovieArchiveAPI.Data.Context;
using MovieArchiveAPI.Models.DTO;
using MovieArchiveAPI.Models.ViewModel;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieArchiveAPI.Applications.DirectorOperations.GetDirector;
using MovieArchiveAPI.Applications.DirectorOperations.CreateDirector;
using MovieArchiveAPI.Applications.DirectorOperations.GetDirectorById;
using MovieArchiveAPI.Applications.DirectorOperations.GetDirectorByName;
using MovieArchiveAPI.Applications.DirectorOperations.UpdateDirector;
using MovieArchiveAPI.Applications.DirectorOperations.DeleteDirector;

namespace MovieArchiveAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DirectorsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMovieArchiveDBContext _context;

        public DirectorsController(IMovieArchiveDBContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }
        
        // GET: api/Directors
        [HttpGet]
        public IActionResult GetDirectors() { 
            GetDirectorQuery query = new GetDirectorQuery(_context, _mapper);
            List<DirectorViewModel> DirectorList;
            try
            {
                DirectorList = query.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(DirectorList); 
        }

        // POST: api/Directors
        [HttpPost]
        public IActionResult CreateDirector([FromBody] DirectorDTO model) { 
            CreateDirectorCommand command = new CreateDirectorCommand(_context, _mapper, model);
            CreateDirectorValidator validator = new CreateDirectorValidator();
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

        // GET: api/Directors/{id}
        [HttpGet("{id}")]
        public IActionResult GetDirectorById(int id) { 
            GetDirectorByIdQuery query = new GetDirectorByIdQuery(_context, _mapper, id);
            DirectorViewModel Director;
            try
            {
                Director = query.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(Director); 
        }

        // GET: api/Directors/fullname
        [HttpGet("fullname")]
        public IActionResult GetDirectorByName([FromQuery] GetDirectorByNameDTO fullname) { 
            GetDirectorByNameQuery query = new GetDirectorByNameQuery(_context, _mapper, fullname);
            DirectorViewModel Director;
            try
            {
                Director = query.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(Director); 
        }

        // PUT: api/Directors/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateDirector(int id, [FromBody] DirectorDTO model) { 
            UpdateDirectorCommand command = new UpdateDirectorCommand(_context, _mapper, model);
            UpdateDirectorValidator validator = new UpdateDirectorValidator();
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

        // DELETE: api/Directors/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteDirector(int id) { 
            DeleteDirectorCommand command = new DeleteDirectorCommand(_context, id);
            DeleteDirectorValidator validator = new DeleteDirectorValidator();
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