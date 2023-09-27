using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace upsideCakes.Models
{
    public class Cliente
    {
        private int _id { get; set; }
        private DateOnly _dataNasc { get; set; }
        private string _endereco { get; set; }
        private string _email { get; set; }

        public Cliente()
        {

        }

        public Cliente(DateOnly dataNasc, string endereco, string email)
        {
            _dataNasc = dataNasc;
            _endereco = endereco;
            _email = email;
        }

    }
}