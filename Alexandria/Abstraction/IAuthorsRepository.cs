using AlexandriaEF.Models;

namespace AlexandriaEF.Abstraction
{
    public interface IAuthorsRepository
    {
        Task<string> AddAuthorAsync(Author newAuthor);
        Task<string> DeleteAuthorByIdAsync(Author author);
        Task<Author?> GetAuthorByIdAsync(Guid id);
        Task<List<Author>> GetAuthors();
        Task<string> UpdateAuthorByIdAsync(Author author);
    }
}