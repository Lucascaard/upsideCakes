using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace upsideCakes.Models
{
    public abstract class Pessoa
    {
        public string? _nome { get; set; }

        public string? _cpf { get; set; }

        public DateOnly _dataNasc { get; set; }

        public string? _endereco { get; set; }

        public string? _email { get; set; }
        public int _telefone { get; set; }
    }
}