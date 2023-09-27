using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace upsideCakes.Models
{
    public class Pedido
    {
        private int _id { get; set; }
        private DateOnly _dataCriacao { get; set; }

        private List<Produto> _itens { get; set; }

        public Pedido()
        {

        }

        public Pedido(DateOnly dataCriacao, List<Produto> itens)
        {
            _dataCriacao = dataCriacao;
            _itens = itens;
        }
    }
}