using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.SignalR;

namespace upsideCakes.Models
{
    public class Pagamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int _id { get; set; }
        public DateOnly _data { get; set; }

        [NotMapped]
        public Cliente? _cliente {get; set;}
        public float _valor { get; set; }
        public string? _formaDePagamento { get; set; }

        [NotMapped]
        public Pedido? _pedido { get; set; }

    }
}