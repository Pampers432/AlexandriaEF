using AlexandriaEF.Contracts;
using AlexandriaEF.Models;
using AlexandriaEF.Repositories;
using AlexandriaEF.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlexandriaEF.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorsRepository _repository;
        private readonly AuthorService _service;
        public AuthorsController(AuthorsRepository authorsRepository, AuthorService service)
        {
            _repository = authorsRepository;
            _service = service;
        }

        [HttpPost("AddAuthor")] 
        public async Task<ActionResult> AddAuthorAsync(string name, DateTime dateOfBirth)
        {            
            return Ok(await _service.AddAuthorAsync(name, dateOfBirth));
        } 

        [HttpGet("GetAuthors")]
        public async Task<List<AuthorResponse>> GetAuthorsAsync()
        {
            return await _service.GetAuthors();
        }

        [HttpGet("GetAuthor")]
        public async Task<AuthorResponse> GetAuthorByIdAsync(Guid id)
        {
            return await _service.GetAuthorByIdAsync(id);
        } 

        [HttpPut("UpdateAuthor")]
        public async Task<ActionResult> UpdateAuthorByIdAsync(Guid id, string newName, DateTime newDateOfBirth)
        {            
            return Ok(await _service.UpdateAuthorByIdAsync(id, newName, newDateOfBirth));
        }

        [HttpDelete("DeleteAuthor")]
        public async Task<ActionResult> DeleteAuthorByIdAsync(Guid id)
        {            
            return Ok(await _service.DeleteAuthorByIdAsync(id));
        }
    }
}
