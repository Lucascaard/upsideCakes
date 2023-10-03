using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace upsideCakes.Models
{
    public class Pagamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int _id { get; set; }
        public float _valor { get; set; }
        public string? _formaDePagamento { get; set; }
        public DateOnly _data { get; set; }
        public Pedido? _pedido { get; set; }
    }
}