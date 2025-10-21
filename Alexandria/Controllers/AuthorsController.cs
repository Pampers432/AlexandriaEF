using Alexandria.Models;
using Alexandria.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Alexandria.Controllers
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
        public async Task<string> AddAuthorAsync(string name, DateTime dateOfBirth)
        {            
            return await _repository.AddAuthorAsync(name, dateOfBirth);
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
        public async Task<string> UpdateAuthorByIdAsync(Guid id, string newName, DateTime newDateOfBirth)
        {            
            return await _repository.UpdateAuthorByIdAsync(id, newName, newDateOfBirth);
        }

        [HttpDelete("DeleteAuthor")]
        public async Task<string> DeleteAuthorByIdAsync(Guid id)
        {            
            return await _repository.DeleteAuthorByIdAsync(id);
        }
    }
}
