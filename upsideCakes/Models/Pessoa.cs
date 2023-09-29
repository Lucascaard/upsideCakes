using System.ComponentModel.DataAnnotations;

namespace upsideCakes.Models
{
    public class Pessoa
    {
        [Key]
        public string? Cpf { get; set; }
        public string? Nome { get; set; }

        // public Pessoa()
        // {

        // }   

        // public Pessoa(string cpf, string nome)
        // {
        //     _cpf = cpf;
        //     _nome = nome;
        // }
    }
}