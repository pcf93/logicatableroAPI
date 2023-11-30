using Cordelia.LoginRegister.Application.DTO;
using Cordelia.LoginRegister.Domain.Model;

namespace Cordelia.LoginRegister.Application.Services.Abstraction;

public interface IUserService
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<User>> GetUsers();

    Task<User?> GetUserById(int id);

    Task<int> GetIdByUsername(string email);

    /// <summary>
    /// Logs a user using mail and password
    /// </summary>
    /// <param name="loginData"></param>
    /// <returns></returns>
    Task<string> UserLogin(UserLoginDto loginData);


    /// <summary>
    /// Registers a new user
    /// </summary>
    /// <param name="newUser"></param>
    /// <returns></returns>
    Task<User?> UserRegister(UserRegisterDto newUser);
    Task<User> UserUpdate(UserUpdateDto updateUser, int userId);
    Task<User> UserDelete(int id);
}
