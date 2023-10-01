using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace upsideCakes.Models
{
    [Keyless]
    public class Pessoa
    {

        public string? _cpf { get; set; }
        public string? _nome { get; set; }

        // public Pessoa(string cpf, string nome)
        // {
        //     _cpf = cpf;
        //     _nome = nome;
        // }
    }
}