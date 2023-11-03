using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace upsideCakes.Models
{
    public abstract class Pessoa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [MaxLength(255)]
        public string? nome { get; set; }

        [Required]
        [MaxLength(15)]
        public string? cpf { get; set; }

        [Required]
        public DateOnly dataNasc { get; set; }

        [Required]
        [MaxLength(255)]
        public string? endereco { get; set; }

        [Required]
        [MaxLength(100)]
        public string? email { get; set; }
        
        [Required]
        [MaxLength(15)]
        public string? telefone { get; set; }

        protected Pessoa(string? nome, string? cpf, DateOnly dataNasc, string? endereco, string? email, string? telefone)
        {
            this.nome = nome;
            this.cpf = cpf;
            this.dataNasc = dataNasc;
            this.endereco = endereco;
            this.email = email;
            this.telefone = telefone;
        }
        public Pessoa()
        {

        }
    }
}