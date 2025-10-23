using AlexandriaEF.Data;
using AlexandriaEF.Models;
using Microsoft.EntityFrameworkCore;

namespace AlexandriaEF.Repositories
{
    public class AuthorsRepository
    {
        private readonly AlexandriaDbContext _db;

        public AuthorsRepository(AlexandriaDbContext db)
        {
            _db = db;
        }

        public async Task<List<Author>> GetAuthors()
        {
            return await _db.Authors.ToListAsync();
        }

        public async Task<Author> GetAuthorByIdAsync(Guid id)
        {
            var author = await _db.Authors.FirstOrDefaultAsync(a => a.Id == id);

            if (author == null) throw new ArgumentNullException("Такого автора нет");

            return author;
        }

        public async Task<string> AddAuthorAsync(string name, DateTime dateOfBirth)
        {
            var newAuthor = Author.CreateAuthor(name, dateOfBirth);

            await _db.Authors.AddAsync(newAuthor);
            await _db.SaveChangesAsync();

            return "Успех";
        }

        public async Task<string> UpdateAuthorByIdAsync(Guid id, string newName, DateTime newDateOfBirth)
        {
            var author = await _db.Authors.FirstOrDefaultAsync(a => a.Id == id);

            if (author == null) throw new ArgumentNullException("Такого автора нет");

            author.Name = newName;
            author.DateOfBirth = newDateOfBirth;

            await _db.SaveChangesAsync();

            return "Успех";
        }

        public async Task<string> DeleteAuthorByIdAsync(Guid id)
        {
            var author = await _db.Authors.FirstOrDefaultAsync(a => a.Id == id);

            if (author == null) throw new ArgumentNullException("Такого автора нет");

            _db.Authors.Remove(author);
            await _db.SaveChangesAsync();

            return "Успех";
        }
    }
}
