using LibraryManagementSystemDb.Infrastructure.Models.Author;

namespace LibraryManagementSystemDb.Infrastructure.Services.AuthorService;

public interface IAuthorService
{
    Task<IEnumerable<Author>> GetAuthors();
    
    Task<Author?> GetAuthorById(Guid authorId);
    
    Task<bool> CreateAuthor(Author author);
    
    Task<bool> UpdateAuthor(Author author);
    
    Task<bool> DeleteAuthor(Guid authorId);
}