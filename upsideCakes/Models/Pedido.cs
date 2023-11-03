using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace upsideCakes.Models
{
    public class Pedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public DateOnly dataCriacao { get; set; }

        public int funcionarioID { get; set; }

        public int gerenteID { get; set; }

        public int qtde {  get; set; }

        [NotMapped]
        public List<Produto>? itens { get; set; }
    }
}