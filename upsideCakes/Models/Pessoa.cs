using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace upsideCakes.Models
{
    public abstract class Pessoa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int _id { get; set; }

        [Required]
        [MaxLength(255)]
        public string? _nome { get; set; }

        [Required]
        [MaxLength(15)]
        public string? _cpf { get; set; }

        [Required]
        public DateOnly _dataNasc { get; set; }

        [Required]
        [MaxLength(255)]
        public string? _endereco { get; set; }

        [Required]
        [MaxLength(100)]
        public string? _email { get; set; }
        
        [Required]
        [MaxLength(15)]
        public string? _telefone { get; set; }

        protected Pessoa(string? nome, string? cpf, DateOnly dataNasc, string? endereco, string? email, string? telefone)
        {
            _nome = nome;
            _cpf = cpf;
            _dataNasc = dataNasc;
            _endereco = endereco;
            _email = email;
            _telefone = telefone;
        }
        //JSON
        public Pessoa()
        {

        }
    }
}