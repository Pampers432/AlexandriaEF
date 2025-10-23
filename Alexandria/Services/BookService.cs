using AlexandriaEF.Contracts;
using AlexandriaEF.Data;
using AlexandriaEF.Models;
using AlexandriaEF.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AlexandriaEF.Services
{
    public class BookService
    {
        private readonly AlexandriaDbContext _db;
        private readonly BooksRepository _repository;
        private readonly AuthorsRepository _authorsRepository;

        public BookService(AlexandriaDbContext db, BooksRepository booksRepository, AuthorsRepository authorsRepository)
        {
            _db = db;
            _repository = booksRepository;
            _authorsRepository = authorsRepository;
        }

        public async Task<List<BookResponse>> GetBooksAsync()
        {
            var Books = await _repository.GetBooksAsync();
            var response = new List<BookResponse>();

            foreach (var book in Books)
            {
                var author = _authorsRepository.GetAuthorByIdAsync(book.AuthorId);
                response.Add(new BookResponse(book.Title, book.PublishedYear, author.Result.Name));
            }
            return response;
        }

        public async Task<BookResponse> GetBookByTitleAsync(BookByTitleRequest bookByTitleRequest)
        {
            var book = await _repository.GetBookByTitleAsync(bookByTitleRequest.title);

            if (book == null) throw new ArgumentNullException("Такой книги нет");

            return new BookResponse(book.Title, book.PublishedYear, _authorsRepository.GetAuthorByIdAsync(book.AuthorId).Result.Name);
        }

        public async Task<string> AddBookAsync(AddBookRequest addBookRequest)
        {
            var authorId = await _db.Authors
                .Where(a => a.Name == addBookRequest.authorsName)
                .Select(a => a.Id)
                .FirstOrDefaultAsync();

            if (authorId == Guid.Empty) throw new ArgumentException("Автор с таким ID не найден");

            var newBook = Book.CreateBook(addBookRequest.title, addBookRequest.publishedYear, authorId);

            return await _repository.AddBookAsync(newBook); ;
        }

        public async Task<string> UpdateBookByIdAsync(UpdateBookRequest updateBookRequest)
        {
            var book = await _repository.GetBookByIdAsync(updateBookRequest.id);

            if (book == null) throw new ArgumentNullException("Такой книги нет");

            book.Title = updateBookRequest.newTitle;
            book.PublishedYear = updateBookRequest.newPublishDate;

            return await _repository.UpdateBookByIdAsync(book);
        }

        public async Task<string> DeleteBookByIdAsync(BookByTitleRequest bookByTitleRequest)
        {
            var book = await _repository.GetBookByTitleAsync(bookByTitleRequest.title);

            if (book == null) throw new ArgumentNullException("Такой книги нет");            

            return await _repository.DeleteBookByIdAsync(book); ;
        }
    }
}
