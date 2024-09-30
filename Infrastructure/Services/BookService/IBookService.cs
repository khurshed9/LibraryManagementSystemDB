using LibraryManagementSystemDb.Infrastructure.Models.Book;
using LibraryManagementSystemDb.Infrastructure.Models.Book.BookQueries;

namespace LibraryManagementSystemDb.Infrastructure.Services.BookService;

public interface IBookService
{
    Task<IEnumerable<Book>> GetBooks();
    
    Task<Book?> GetBookById(Guid id);
    
    Task<bool> CreateBook(Book book);
    
    Task<bool> UpdateBook(Book book);
    
    Task<bool> DeleteBook(Guid id);
    
}