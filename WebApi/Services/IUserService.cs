using LoginFuncProject.Dtos;
using LoginFuncProject.Models;

namespace WebApi.Services;

public interface IUserService
{
    Task<User> Create(UserCreationDto dto);
    Task<IEnumerable<User>> GetUsers(string? usernameContains = null);
}