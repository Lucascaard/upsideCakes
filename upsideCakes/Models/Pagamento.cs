using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace upsideCakes.Models
{
    public class Pagamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        
        public DateOnly data { get; set; }
        public float valor { get; set; }
        public string? formaDePagamento { get; set; }
        public string? nomeCliente { get; set; }

/*
        [ForeignKey("idCliente")]
        public Cliente? cliente { get; set; } // Propriedade de navegação para Cliente
        public int idCliente { get; set; }    

        [ForeignKey("idPedido")]
        public Pedido? pedido { get; set; } // Propriedade de navegação para Pedido
        public int idPedido { get; set; }*/
    }
}
