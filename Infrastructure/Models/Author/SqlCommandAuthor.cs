namespace LibraryManagementSystemDb.Infrastructure.Models.Author;

public class SqlCommandAuthor
{
    public const string GetAuthors = "select * from authors";
    
    public const string GetAuthorById = "select * from authors where id = @Id";
    
    public const string CreateAuthor = "insert into authors (id, firstName, lastName, dateOfBirth, biography, createdAt) values (@Id, @FirstName, @LastName, @DateOfBirth, @Biography, @CreatedAt)";
    
    public const string UpdateAuthor = "update authors set id = @id, firstName = @FirstName, lastName = @LastName, dateOfBirth = @DateOfBirth, biography = @Biography, createdAt = @createdAt where id = @Id";
    
    public const string DeleteAuthor = "delete from authors where id = @Id";
}