using System.Text.Json.Serialization;

namespace Helniv_AccessControl.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Login { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public DateTime DataCriacao { get; set; }

        public bool Ativo { get; set; } 

        public DateTime? DataInativacao { get; set; }
    }
}
