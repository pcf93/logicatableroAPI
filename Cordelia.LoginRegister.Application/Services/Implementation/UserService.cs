using Cordelia.LoginRegister.Application.DTO;
using Cordelia.LoginRegister.Application.Repository;
using Cordelia.LoginRegister.Application.Services.Abstraction;
using Cordelia.LoginRegister.Domain.Model;
using Microsoft.Extensions.Logging;
using System.Reflection.Metadata;

namespace Cordelia.LoginRegister.Application.Services.Implementation;

public class UserService : IUserService
{
    //normalmente tendremos un servicio por cada funcionalidad
    //recomendable separar los archivos de service por funcionalidad

    //aquí metemos la funcionalidad del login y del register

    private readonly IUnitOfWork _unitOfWork;
    private readonly IGenericRepository<User> _userRepository;

    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _userRepository = unitOfWork.GetUserRepository();

    }

    public async Task<IEnumerable<User>> GetUsers()
    {
        return await _userRepository.GetAsync();
    }
    
    public async Task<User?> GetUserById(int id)
    {
        return await _userRepository.GetByIdAsync(id);
    }

    public async Task<int> GetIdByUsername(string userName)
    {
        var user = await _userRepository.GetAsync(user => user.UserName == userName);

        if (user.Count() == 0)

        {

            return 0;

        } else { 
            
            return user.First().UserId; 

        }

    }
    
    public async Task<User?> UserLogin(UserLoginDto loginData)
    {

        //utilizando el ToList() estoy trayéndome todos los usuarios, en vez de escoger el que necesito. NO RECOMENDABLE

        //var x = users.Where(user => user.UserName == username && user.UserPassword == password).ToList(); -- este va bien si queremos conseguir varios resultados
        //var y = users.FirstOrDefault(user => user.UserName == username && user.UserPassword == password); -- este va bien si queremos conseguir un único resultado, nos devuelve el resultado
        //var z = users.Any(user => user.UserName == username && user.UserPassword == password); -- este nos interesa si queremos encontrar una coincidencia, porque devuelve true o false

        var user =_userRepository.GetEntityContext().FirstOrDefault(user => user.UserName == loginData.UserName && user.UserPassword == loginData.UserPassword);

        return await Task.FromResult(user);

    }

    public async Task<User?> UserRegister(UserRegisterDto newUser)
    {

        var exists = _userRepository.GetEntityContext().Any(user => user.UserEmail == newUser.UserEmail);

        if ( !exists )
        {

                var userCreated = new User()
                {
                    UserName = newUser.UserName,
                    UserPassword = newUser.UserPassword,
                    UserEmail = newUser.UserEmail,
                    UserPhone = newUser.UserPhone,
                    UserBirthDate = newUser.UserBirthDate,
                    UserCity = newUser.UserCity
                };

            await _userRepository.InsertAsync(userCreated);
            await _unitOfWork.SaveAsync();

                return await Task.FromResult(userCreated);


        }
        else { return null; }
    }
    }



