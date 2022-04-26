using System.ComponentModel.DataAnnotations;

namespace Helniv_AccessControl.Models
{
    public class UpdateRequestUserModel
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
