using System.ComponentModel.DataAnnotations;

namespace upsideCakes.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        public string? _nome { get; set; }
        public float _preco { get; set; }
    }
}