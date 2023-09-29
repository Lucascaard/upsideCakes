using System.ComponentModel.DataAnnotations;

namespace upsideCakes.Models
{
    public class Usuario
    {
        [Key]
        public string? Login { get; set; }
        public string? Senha { get; set; }

        // public Usuario()
        // {

        // }

        // public Usuario(string login, string senha)
        // {
        //     _login = login;
        //     _senha = senha;
        // }


    }
}