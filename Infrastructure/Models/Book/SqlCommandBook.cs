namespace LibraryManagementSystemDb.Infrastructure.Models.Book;

public class SqlCommandBook
{
    public const string GetBooks = "select * from books";
    
    public const string GetBookById = "select * from books where id = @Id";
    
    public const string CreateBook = "insert into books (id, title, description, isbn, publishedDate, authorId, categoryId, createdAt) values (@Id, @Title, @Description, @ISBN, @PublishedDate, @AuthorId, @CategoryId, @CreatedAt)";
    
    public const string UpdateBook = "update books set id = @id, title = @Title, description = @Description, isbn = @ISBN, publishedDate = @PublishedDate, authorId = @AuthorId, categoryId = @CategoryId, createdAt = @createdAt where id = @Id";
    
    public const string DeleteBook = "delete from books where id = @Id";
}