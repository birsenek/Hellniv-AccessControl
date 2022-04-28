using Helniv_AccessControl.Interfaces;
using Helniv_AccessControl.Models;
using Helniv_AccessControl.Services;
using Microsoft.AspNetCore.Mvc;

namespace Helniv_AccessControl.Controllers
{
    [Route("api/role")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAllRoles()
        {
            var roles = _roleService.GetAllRoles();
            return Ok(roles);
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateRole(CreateRequestRoleModel roleModel)
        {
            _roleService.CreateRole(roleModel);
            return (Ok(new { message = "Perfil criado com sucesso!" }));

        }

        [HttpGet("constant")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetRoleByConst(string constant)
        {
            var role = _roleService.GetRoleByConst(constant);
            
            return Ok(role);
        }

        [HttpPut("constant")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateRole(string roleConst, UpdateRequestRoleModel roleModel)
        {
            _roleService.UpdateRole(roleConst, roleModel);
            return Ok(new { message = "Perfil atualizado com sucesso!" });

        }

        [HttpDelete("constant")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteRole(string roleConst)
        {
            _roleService.DeleteRole(roleConst);
            return Ok(new { message = "Perfil excluído com sucesso!"});
        }
    }
}
