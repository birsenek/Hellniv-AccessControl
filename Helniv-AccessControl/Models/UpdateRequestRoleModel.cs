
using System.ComponentModel.DataAnnotations;

namespace Helniv_AccessControl.Models
{
    public class UpdateRequestRoleModel
    {
        [Required]
        public string RoleName { get; set; }
        [Required]
        public string RoleConst { get; set; }

        public string Active { get; set; }
    }
}
