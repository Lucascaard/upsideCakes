using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace upsideCakes.Models
{
    public class Cardapio
    {
        private Produto _produto { get; set; }
        private int _quantidade { get; set; }

        public Cardapio()
        {

        }

        public Cardapio(Produto produto, int quantidade)
        {
            _produto = produto;
            _quantidade = quantidade;
        }
    }
}