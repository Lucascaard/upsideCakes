using System.ComponentModel.DataAnnotations;

namespace upsideCakes.Models
{
    public class Pessoa
    {
        [Key]
        private string? _cpf;
        private string? _nome;

        public Pessoa(string? cpf, string? nome)
        {
            Cpf = cpf;
            Nome = nome;
        }
        public string? Cpf { get => _cpf; set => _cpf = value; }
        public string? Nome { get => _nome; set => _nome = value; }
    }
}