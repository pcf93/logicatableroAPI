using Cordelia.LoginRegister.Application.DTO;
using Cordelia.LoginRegister.Application.Repository;
using Cordelia.LoginRegister.Application.Services.Abstraction;
using Cordelia.LoginRegister.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using OtpNet;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Cordelia.LoginRegister.Application.Services.Implementation;

public class UserService : IUserService
{
    //normalmente tendremos un servicio por cada funcionalidad
    //recomendable separar los archivos de service por funcionalidad

    //aquí metemos la funcionalidad del login y del register

    private readonly IUnitOfWork _unitOfWork;
    private readonly IGenericRepository<User> _userRepository;
    private readonly IConfiguration _configuration;

    public UserService(IUnitOfWork unitOfWork, IConfiguration configuration)
    {
        _unitOfWork = unitOfWork;
        _userRepository = unitOfWork.GetUserRepository();
        _configuration = configuration;
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
        return await _userRepository
            .GetQueryable(user => user.UserName == userName)
            .Select(user => user.UserId) //en caso de seleccionar más de una columna, se crearía un objeto anónimo
            .FirstOrDefaultAsync();
    }
    
    public async Task<string> UserLogin(UserLoginDto loginData)
    {

        //utilizando el ToList() estoy trayéndome todos los usuarios, en vez de escoger el que necesito. NO RECOMENDABLE

        //var x = users.Where(user => user.UserName == username && user.UserPassword == password).ToList(); -- este va bien si queremos conseguir varios resultados
        //var y = users.FirstOrDefault(user => user.UserName == username && user.UserPassword == password); -- este va bien si queremos conseguir un único resultado, nos devuelve el resultado
        //var z = users.Any(user => user.UserName == username && user.UserPassword == password); -- este nos interesa si queremos encontrar una coincidencia, porque devuelve true o false

        var user = _userRepository.GetEntityContext()
            .FirstOrDefault(user => user.UserName == loginData.UserName);

        var result = "";

        if (user == null)
        {

            result = null;


        }
        else
        {

            if (!VerifyPasswordHash(loginData.UserPassword, user.PasswordHash, user.PasswordSalt))
            {
                result = null;

            }
            else
            {

                result = CreateToken(user);

            }

        }

        return await Task.FromResult(result);

    }

    public async Task<string?> GenerateSecretKeyAsync(int usuarioId)
    {
        var user = _userRepository.GetEntityContext().FirstOrDefault(user => user.UserId == usuarioId);

        var secretKeyString = "";
        
        if (user != null)
        {
            var secretKey = KeyGeneration.GenerateRandomKey();
            secretKeyString = Convert.ToBase64String(secretKey);
            user.SecretKet = secretKeyString;

            await _unitOfWork.SaveAsync();

        }

        return await Task.FromResult(secretKeyString);
    }

    public async Task<User?> UserRegister(UserRegisterDto newUser)
    {

        var exists = _userRepository.GetEntityContext().Any(user => user.UserName == newUser.UserName);

        if (!exists)
        {

            CreatePasswordHash(newUser.UserPassword, out byte[] passwordHash, out byte[] passwordSalt);

            var userCreated = new User()
            {
                UserName = newUser.UserName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                UserEmail = newUser.UserEmail,
                UserPhone = newUser.UserPhone,
                UserBirthDate = newUser.UserBirthDate,
                UserCity = newUser.UserCity,
                //estos borrarlos en mi versión
                DarkMode = true,
                UserTypeId = 1,
                UserLanguageId = 1
            };

            await _userRepository.InsertAsync(userCreated);
            await _unitOfWork.SaveAsync();

            return await Task.FromResult(userCreated);


        }
        else { return null; }
    }

    private string CreateToken(User user)
    {
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, user.UserEmail),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Sid, user.UserId.ToString())
        };

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
            _configuration.GetSection("AppSettings:Token").Value));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: creds
            );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }


    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }

    private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512(passwordSalt))
        {
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }
    }
}



