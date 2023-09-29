using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace upsideCakes.Models
{
    public class Usuario
    {
        private string? _login { get; set; }
        private string? _senha { get; set; }


        public Usuario(string login, string senha)
        {
            _login = login;
            _senha = senha;
        }


    }
}