using AlexandriaEF.Data;
using AlexandriaEF.Models;
using Microsoft.EntityFrameworkCore;

namespace AlexandriaEF.Repositories
{
    public class BooksRepository
    {
        private readonly AlexandriaDbContext _db;

        public BooksRepository(AlexandriaDbContext db)
        {
            _db = db;
        }

        public async Task<List<Book>> GetBooksAsync()
        {
            return await _db.Books.Include(b => b.Author).ToListAsync();
        }

        public async Task<Book?> GetBookByIdAsync(Guid id)
        {
            return await _db.Books.Include(b => b.Author).FirstOrDefaultAsync(b => b.Id == id); ;
        }

        public async Task<Book?> GetBookByTitleAsync(string title)
        {
            return await _db.Books.FirstOrDefaultAsync(b => b.Title == title);
        }

        public async Task<string> AddBookAsync(Book book)
        {
            await _db.Books.AddAsync(book);
            await _db.SaveChangesAsync();

            return "Успех";
        }

        public async Task<string> UpdateBookByIdAsync(Book book)
        {
            _db.Books.Update(book);
            await _db.SaveChangesAsync();

            return "Успех";
        }

        public async Task<string> DeleteBookByIdAsync(Book book)
        {
            _db.Books.Remove(book);
            await _db.SaveChangesAsync();

            return "Успех";
        }
    }
}
