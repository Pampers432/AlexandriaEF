using Alexandria.Data;
using Alexandria.Models;
using Microsoft.EntityFrameworkCore;

namespace Alexandria.Repositories
{
    public class BooksRepository
    {
        private readonly AlexandriaDbContext _db;

        public BooksRepository(AlexandriaDbContext db)
        {
            _db = db;
        }

        public async Task<List<Book>> GetBooks()
        {
            return await _db.Books.ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(Guid id)
        {
            var book = await _db.Books.FirstOrDefaultAsync(b => b.Id == id);

            if (book == null) throw new ArgumentNullException("Такой книги нет");

            return book;
        }

        public async Task<string> AddBookAsync(string title, DateTime publishDate, Guid authorId)
        {
            var authorExists = await _db.Authors.AnyAsync(a => a.Id == authorId);

            if (!authorExists) throw new ArgumentException("Автор с таким ID не найден");

            var newBook = Book.CreateBook(title, publishDate, authorId);

            await _db.Books.AddAsync(newBook);
            await _db.SaveChangesAsync();

            return "Успех";
        }

        public async Task<string> UpdateBookByIdAsync(Guid id, string newTitle, DateTime newPublishDate)
        {
            var book = await _db.Books.FirstOrDefaultAsync(b => b.Id == id);

            if (book == null) throw new ArgumentNullException("Такой книги нет");

            book.Title = newTitle;
            book.PublishedYear = newPublishDate;

            await _db.SaveChangesAsync();

            return "Успех";
        }

        public async Task<string> DeleteBookByIdAsync(Guid id)
        {
            var book = await _db.Books.FirstOrDefaultAsync(b => b.Id == id);

            if (book == null) throw new ArgumentNullException("Такой книги нет");

            _db.Books.Remove(book);
            await _db.SaveChangesAsync();

            return "Успех";
        }
    }
}
