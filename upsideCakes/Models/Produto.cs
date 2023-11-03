using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace upsideCakes.Models
{
    public class Produto
    {
        public Produto(string? nome, double preco, string? categoria)
        {
            this.nome = nome;
            this.preco = preco;
            this.categoria = categoria;
        }

        public Produto()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string? nome { get; set; }
        public double preco { get; set; }
        public string? categoria { get; set; }
    }
}