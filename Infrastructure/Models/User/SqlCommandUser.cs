namespace LibraryManagementSystemDb.Infrastructure.Models.User;

public class SqlCommandUser
{
    public const string GetUsers = "Select * from users";
    
    public const string GetUserById = "SELECT * FROM users WHERE id = @Id";
    
    public const string CreateUser = "INSERT INTO users (id,username, email, passwordHash, createdAt) VALUES (@id,@Username, @Email, @PasswordHash, @CreatedAt)";
    
    public const string UpdateUser = "UPDATE users SET id = @id, username = @Username, email = @Email, passwordHash = @PasswordHash,createdAt = @createdAt WHERE id = @Id";
    
    public const string DeleteUser = "DELETE FROM users WHERE id = @Id";
}