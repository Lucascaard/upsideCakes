using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace upsideCakes.Models
{
    public class Pagamento
    {
        private Pedido _pedido { get; set; }
        private float _valor {get; set; }
        private string _formaDePagamento { get; set; }
        private DateOnly _data { get; set; }
        // private string _notaFiscal { get; set; }          Nota Fiscal = toString() 

        public Pagamento ()
        {

        }

        public Pagamento(Pedido pedido, float valor, string formaDePagamento, DateOnly data)
        {
            _pedido = pedido;
            _valor = valor;
            _formaDePagamento = formaDePagamento;
            _data = data;
        }
    }
}