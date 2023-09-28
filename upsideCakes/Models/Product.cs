using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace upsideCakes.Models
{
    public class Product
    {
        public int Id { get; set; }
        private string _nome { get; set; }
        public float _preco { get; set; }

        public Product()
        {

        }

        public Product(string nome, float preco)
        {
            _nome = nome;
            _preco = preco;
        }


    }
}