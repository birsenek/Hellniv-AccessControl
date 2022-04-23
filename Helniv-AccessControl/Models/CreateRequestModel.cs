using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Helniv_AccessControl.Models
{
    public class CreateRequestModel
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
