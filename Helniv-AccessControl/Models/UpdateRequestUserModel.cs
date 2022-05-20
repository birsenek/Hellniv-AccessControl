using System.ComponentModel.DataAnnotations;

namespace Helniv_AccessControl.Models
{
    public class UpdateRequestUserModel
    {
        public string? Nome { get; set; }

        [Required]
        public string Login { get; set; }

        public string? Password { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        public string? Ativo { get; set; }

        public string? Role { get; set; }   
    }
}
