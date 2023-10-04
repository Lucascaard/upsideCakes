using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace upsideCakes.Models
{
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int _id { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatorio.")]
        public string? _nome { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "O campo Preço deve ser maior ou igual a zero.")]
        public double _preco { get; set; }

        [Required(ErrorMessage = "O campo categoria é obrigatorio.")]
        public string? _categoria { get; set; } // possivelmente trocar pra int
    }
}