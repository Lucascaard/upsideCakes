using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace upsideCakes.Models
{
    public class Produto
    {
        private string _nome { get; set; }
        private float _preco { get; set; }

        public Produto()
        {

        }

        public Produto(string nome, float preco)
        {
            _nome = nome;
            _preco = preco;
        }
    }
}