using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Helniv_AccessControl.Models
{
    public class CreateRequestUserModel
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

        [Required]
        public string Role { get; set; }

    }
}
