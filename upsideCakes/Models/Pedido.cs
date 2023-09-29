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

        private List<Product>? _itens { get; set; }

        public Pedido(DateOnly dataCriacao, List<Product> itens)
        {
            _dataCriacao = dataCriacao;
            _itens = itens;
        }
    }
}