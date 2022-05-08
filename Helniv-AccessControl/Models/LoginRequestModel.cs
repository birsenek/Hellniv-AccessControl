using System.ComponentModel.DataAnnotations;

namespace Helniv_AccessControl.Models
{
    public class LoginRequestModel
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
