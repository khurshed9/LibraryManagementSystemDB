using LibraryManagementSystemDb.Infrastructure.Models.User;

namespace LibraryManagementSystemDb.Infrastructure.Services.UserService;

public interface IUserService
{
    Task<IEnumerable<User>> GetUsers();
    
    Task<User?> GetUserById(Guid id);
    
    Task<bool> CreateUser(User user);
    
    Task<bool> UpdateUser(User user);
    
    Task<bool> DeleteUser(Guid id);
}