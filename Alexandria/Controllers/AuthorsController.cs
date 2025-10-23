using AlexandriaEF.Models;
using AlexandriaEF.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AlexandriaEF.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorsRepository _repository;
        public AuthorsController(AuthorsRepository authorsRepository)
        {
            _repository = authorsRepository;
        }

        [HttpPost("AddAuthor")] 
        public async Task<ActionResult> AddAuthorAsync(string name, DateTime dateOfBirth)
        {            
            return Ok(await _repository.AddAuthorAsync(name, dateOfBirth));
        } 

        [HttpGet("GetAuthors")]
        public async Task<List<Author>> GetAuthorsAsync()
        {
            return await _repository.GetAuthors();
        }

        [HttpGet("GetAuthor")]
        public async Task<Author> GetAuthorByIdAsync(Guid id)
        {
            return await _repository.GetAuthorByIdAsync(id);
        } 

        [HttpPut("UpdateAuthor")]
        public async Task<ActionResult> UpdateAuthorByIdAsync(Guid id, string newName, DateTime newDateOfBirth)
        {            
            return Ok(await _repository.UpdateAuthorByIdAsync(id, newName, newDateOfBirth));
        }

        [HttpDelete("DeleteAuthor")]
        public async Task<ActionResult> DeleteAuthorByIdAsync(Guid id)
        {            
            return Ok(await _repository.DeleteAuthorByIdAsync(id));
        }
    }
}
