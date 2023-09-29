using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace upsideCakes.Models
{
    public class Cardapio
    {
        private string? _produto { get; set; }
        private int _quantidade { get; set; }

        public Cardapio()
        {

        }

        public Cardapio(Product produto, int quantidade)
        {
            _produto = produto;
            _quantidade = quantidade;
        }
    }
}