using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace upsideCakes.Models
{
    public class Funcionario
    {
        private int _id { get; set; }
        private DateOnly _dataNasc { get; set; }
        private int _telefone { get; set; }
        private string? _email {get; set; }



        public Funcionario(DateOnly dataNasc, int telefone, string email)
        {
            _dataNasc = dataNasc;
            _telefone = telefone;
            _email = email;
        }
    }
}