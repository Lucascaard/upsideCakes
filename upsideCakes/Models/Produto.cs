using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace upsideCakes.Models
{
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int _id { get; set; }
        public string? _nome { get; set; }
        public double _preco { get; set; }
        public string? _categoria { get; set; } // possivelmente trocar pra int
    }
}