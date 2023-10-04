using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace upsideCakes.Models
{
    public class Pedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int _id { get; set; }
        public DateOnly _dataCriacao { get; set; }

        public int _funcionarioID { get; set; }

        public int _gerenteID { get; set; }

        public int _qtde {  get; set; }

        public virtual List<Produto>? _itens { get; set; }
    }
}