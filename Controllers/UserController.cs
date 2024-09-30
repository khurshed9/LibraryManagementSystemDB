/*using LibraryManagementSystemDb.Infrastructure.Models.User;
using LibraryManagementSystemDb.Infrastructure.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystemDb.Controllers;

[Route("User")]
[ApiController]

public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IEnumerable<User>> GetUsers()
    {
        return await _userService.GetUsers();
    }

    [HttpGet("{id}")]
    public async Task<User?> GetUserById([FromRoute]Guid id)
    {
        return await _userService.GetUserById(id);
    }

    [HttpPost]
    public async Task<bool> CreateUser([FromBody]User user)
    {
        return await _userService.CreateUser(user);
    }

    [HttpPut]
    public async Task<bool> UpdateUser([FromBody]User user)
    {
        return await _userService.UpdateUser(user);
    }

    [HttpDelete("{id}")]
    public async Task<bool> DeleteUser([FromRoute]Guid id)
    {
        return await _userService.DeleteUser(id);
    }

}*/