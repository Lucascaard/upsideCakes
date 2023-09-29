using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace upsideCakes.Models
{
    public class Pagamento
    {

        //public Pedido _pedido { get; set; } descomentar quando o sql estiver conectado

        [Key]
        public int _idPedido { get; set; }
        [Required]
        public float _valor { get; set; }
        [Required]
        public string? _formaDePagamento { get; set; }
        [Required]
        public DateOnly _data { get; set; }


//descomentar quando o sql estiver conectado
        // private string _notaFiscal { get; set; }          
        // Nota Fiscal = toString() ver cm funfa no swagger

/*
        public Pagamento()
        {

        }

        public Pagamento(Pedido pedido, float valor, string formaDePagamento, DateOnly data)
        {
            _pedido = pedido;
            _valor = valor;
            _formaDePagamento = formaDePagamento;
            _data = data;
        }*/
    }
}