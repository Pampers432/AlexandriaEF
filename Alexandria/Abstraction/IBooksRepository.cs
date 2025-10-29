using AlexandriaEF.Models;

namespace AlexandriaEF.Abstraction
{
    public interface IBooksRepository
    {
        Task<string> AddBookAsync(Book book);
        Task<string> DeleteBookByIdAsync(Book book);
        Task<Book?> GetBookByIdAsync(Guid id);
        Task<Book?> GetBookByTitleAsync(string title);
        Task<List<Book>> GetBooksAsync();
        Task<string> UpdateBookByIdAsync(Book book);
    }
}