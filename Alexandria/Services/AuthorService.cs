using AlexandriaEF.Contracts;
using AlexandriaEF.Data;
using AlexandriaEF.Models;
using AlexandriaEF.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AlexandriaEF.Services
{
    public class AuthorService
    {
        private readonly AlexandriaDbContext _db;
        private readonly AuthorsRepository _repository;

        public AuthorService(AlexandriaDbContext db, AuthorsRepository authorsRepository)
        {
            _db = db;
            _repository = authorsRepository;
        }

        public async Task<List<AuthorResponse>> GetAuthors()
        {
            var authors = await _repository.GetAuthors();

            return authors.Select(a => new AuthorResponse(
                a.Name,
                a.DateOfBirth,
                a.Books.Select(b => b.Title).ToList()))
                .ToList();
        }

        public async Task<AuthorResponse> GetAuthorByIdAsync(Guid id)
        {
            var author = await _repository.GetAuthorByIdAsync(id);

            if (author == null) throw new ArgumentNullException("Такого автора нет");

            return new AuthorResponse(
                author.Name,
                author.DateOfBirth,
                author.Books.Select(b => b.Title).ToList());
        }

        public async Task<string> AddAuthorAsync(string name, DateTime dateOfBirth)
        {
            var newAuthor = Author.CreateAuthor(name, dateOfBirth);            

            return await _repository.AddAuthorAsync(newAuthor); ;
        }

        public async Task<string> UpdateAuthorByIdAsync(Guid id, string newName, DateTime newDateOfBirth)
        {
            var author = await _repository.GetAuthorByIdAsync(id);

            if (author == null) throw new ArgumentNullException("Такого автора нет");

            author.Name = newName;
            author.DateOfBirth = newDateOfBirth;

            return await _repository.UpdateAuthorByIdAsync(author);
        }

        public async Task<string> DeleteAuthorByIdAsync(Guid id)
        {
            var author = await _db.Authors.FirstOrDefaultAsync(a => a.Id == id);

            if (author == null) throw new ArgumentNullException("Такого автора нет");

            return await _repository.DeleteAuthorByIdAsync(author);
        }
    }
}
