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
        public List<Cliente>? Clientes { get; set; }

        public int idCliente {get; set;}
        /*
        [NotMapped]
        public Cliente Cliente { get; set; } // Propriedade de navegação para Cliente
        public int idCliente { get; set; }*/
        public float valor { get; set; }
        public string? formaDePagamento { get; set; }

        [NotMapped]
        public List<Pedido>? Pedidos { get; set; }

        public int idPedido {get; set; }
/*
        [NotMapped]
        public Pedido Pedido { get; set; } // Propriedade de navegação para Pedido
        public int idPedido { get; set; }*/

    }
}