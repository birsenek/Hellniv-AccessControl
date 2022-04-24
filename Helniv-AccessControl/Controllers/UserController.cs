using AutoMapper;
using Helniv_AccessControl.Interfaces;
using Helniv_AccessControl.Models;
using Microsoft.AspNetCore.Mvc;

namespace Helniv_AccessControl.Controllers
{
    [ApiController]

    [Route("/users")]
    public class UserController : Controller
    {
        private IUserService _userService;
        private IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
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
        public IActionResult CreateUser(CreateRequestModel userModel)
        {
             _userService.CreateUser(userModel);
            return Ok(new { message = "Usuário criado com sucesso!" });
        }

        [HttpPut("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateUser(string userLogin, UpdateRequestModel userModel)
        {
            _userService.UpdateUser(userLogin, userModel);
            return Ok(new { message = "Usuário atualizado com sucesso!" });
        }
    }    
}
