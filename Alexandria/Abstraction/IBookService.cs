using AlexandriaEF.Contracts;

namespace AlexandriaEF.Abstraction
{
    public interface IBookService
    {
        Task<string> AddBookAsync(AddBookRequest addBookRequest);
        Task<string> DeleteBookByIdAsync(BookByTitleRequest bookByTitleRequest);
        Task<BookResponse> GetBookByTitleAsync(BookByTitleRequest bookByTitleRequest);
        Task<List<BookResponse>> GetBooksAsync();
        Task<string> UpdateBookByIdAsync(UpdateBookRequest updateBookRequest);
    }
}