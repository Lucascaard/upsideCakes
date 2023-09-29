using System.ComponentModel.DataAnnotations;

namespace upsideCakes.Models
{
    public class Cardapio
    {
        [Key]
        private Produto _produto;
        private int _quantidade;

        public Cardapio(Produto produto, int quantidade)
        {
            _produto = produto;
            _quantidade = quantidade;
        }

        public Produto Produto { get => _produto; set => _produto = value; }
        public int Quantidade { get => _quantidade; set => _quantidade = value; }
    }
}