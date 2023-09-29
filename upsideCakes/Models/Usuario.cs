using System.ComponentModel.DataAnnotations;

namespace upsideCakes.Models
{
    public class Usuario
    {
        [Key]
        private string? _login;
        private string? _senha;

        public Usuario(string? login, string? senha)
        {
            Login = login;
            Senha = senha;
        }
        public string? Login { get => _login; set => _login = value; }
        public string? Senha { get => _senha; set => _senha = value; }
    }
}