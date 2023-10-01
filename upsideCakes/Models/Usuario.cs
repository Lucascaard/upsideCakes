using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace upsideCakes.Models
{
    [Keyless]
    public  abstract class Usuario
    {
        public string? _login { get; set; }
        public string? _senha { get; set; }


        // public Usuario(string login, string senha)
        // {
        //     _login = login;
        //     _senha = senha;
        // }


    }
}