using Cordelia.LoginRegister.Application.DTO;
using Cordelia.LoginRegister.Application.Services.Abstraction;
using Cordelia.LoginRegister.Domain.Model;
using Cordelia.LoginRegister.Infraestructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cordelia.LoginRegister.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("users/{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var result = await _service.GetUserById(id);

            if (result is null) return BadRequest();

            return Ok(result);
        }

        [HttpGet]
        [Route("users/userName/{userName}")]
        public async Task<ActionResult<User>> GetUserByUserName(string userName)
        {
            var result = await _service.GetIdByUsername(userName);

            if (result == 0) return BadRequest();

            return Ok(result);
        }


        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<string>> Login(UserLoginDto loginData)
        {
            var result = await _service.UserLogin(loginData);

            if (result is null) return BadRequest();

            return Ok(result);
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<User?>> Register(UserRegisterDto newUser)
        {
            var result = await _service.UserRegister(newUser);

            if (result is null) return BadRequest();

            return Ok(result);
        }

        [HttpPut, Authorize]
        [Route("update/{id}")]

        public async Task<ActionResult<User?>> UpdateUser(UserUpdateDto updateUser, int id)
        {
            var result = await _service.UserUpdate(updateUser, id);

            if (result is null) return BadRequest();

            return Ok(result);

        }

        [HttpDelete, Authorize]
        [Route("delete/{id}")]

        public async Task<ActionResult<User?>> DeleteUser(int id)
        {
            var result = await _service.UserDelete(id);

            if (result is null) return BadRequest();

            return Ok(result);
        }

    }
}
