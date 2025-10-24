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
            return await _db.Authors.Include(a => a.Books).ToListAsync();
        }

        public async Task<Author?> GetAuthorByIdAsync(Guid id)
        {
            return await _db.Authors.Include(a => a.Books).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<string> AddAuthorAsync(Author newAuthor)
        {
            await _db.Authors.AddAsync(newAuthor);
            await _db.SaveChangesAsync();

            return "Успех";
        }

        public async Task<string> UpdateAuthorByIdAsync(Author author)
        {
            _db.Update(author);
            await _db.SaveChangesAsync();

            return "Успех";
        }

        public async Task<string> DeleteAuthorByIdAsync(Author author)
        {
            _db.Authors.Remove(author);
            await _db.SaveChangesAsync();

            return "Успех";
        }
    }
}
