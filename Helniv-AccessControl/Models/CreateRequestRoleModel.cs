using System.ComponentModel.DataAnnotations;

namespace Helniv_AccessControl.Services
{
    public class CreateRequestRoleModel
    {
        [Required]
        public string RoleName { get; set; }
        [Required]
        public string RoleConst { get; set; }
    }
}