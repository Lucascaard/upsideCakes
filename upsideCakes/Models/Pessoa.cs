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
        public string? _nome { get; set; }

        [Required]
        public string _cpf { get; set; }

        [Required]
        public DateOnly _dataNasc { get; set; }

        [Required]
        public string? _endereco { get; set; }

        [Required]
        public string? _email { get; set; }

        [Required]
        public int _telefone { get; set; }
    }
}