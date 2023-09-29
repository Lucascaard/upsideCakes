using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace upsideCakes.Models
{
    public class Pessoa
    {
        private string? _cpf { get; set; }
        private string? _nome { get; set; }

        public Pessoa(string cpf, string nome)
        {
            _cpf = cpf;
            _nome = nome;
        }
    }
}