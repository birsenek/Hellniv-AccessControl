using Helniv_AccessControl.Interfaces;
using Helniv_AccessControl.Models;
using Microsoft.AspNetCore.Mvc;

namespace Helniv_AccessControl.Controllers
{
    [ApiController]

    [Route("api/user")]
    public class UserController : Controller
    {
        private IUserService _userService;
        

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetUserByLogin(string userLogin)
        {
            var user = _userService.GetUserByLogin(userLogin);
            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateUser(CreateRequestUserModel userModel)
        {
             _userService.CreateUser(userModel);
            return Ok(new { message = "Usuário criado com sucesso!" });
        }

        [HttpPut("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateUser(string userLogin, UpdateRequestUserModel userModel)
        {
            _userService.UpdateUser(userLogin, userModel);
            return Ok(new { message = "Usuário atualizado com sucesso!" });
        }

        [HttpDelete("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteUser(string userLogin)
        {
            _userService.DeleteUser(userLogin);
            return Ok(new { message = "Usuário excluído com sucesso!" });
        }


        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UserLogin(LoginRequestModel userLogin)
        {
            var user = _userService.UserLogin(userLogin);
            return Ok(user);
        }

    }    
}
