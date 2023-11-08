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
        public List<Cliente> Clientes {get; set;} 
        public float valor { get; set; }
        public string? formaDePagamento { get; set; }

        [NotMapped]
        public List<Pedido> Pedidos { get; set; }

    }
}