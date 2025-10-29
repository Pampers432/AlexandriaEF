using AlexandriaEF.Contracts;

namespace AlexandriaEF.Abstraction
{
    public interface IAuthorService
    {
        Task<string> AddAuthorAsync(string name, DateTime dateOfBirth);
        Task<string> DeleteAuthorByIdAsync(Guid id);
        Task<AuthorResponse> GetAuthorByIdAsync(Guid id);
        Task<List<AuthorResponse>> GetAuthors();
        Task<string> UpdateAuthorByIdAsync(Guid id, string newName, DateTime newDateOfBirth);
    }
}