using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.SignalR;

namespace upsideCakes.Models
{
    public class Pagamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public DateOnly data { get; set; }

        [NotMapped]
        public Cliente? cliente {get; set;} 
        public float valor { get; set; }
        public string? formaDePagamento { get; set; }

        [NotMapped]
        public Pedido? pedido { get; set; }

    }
}