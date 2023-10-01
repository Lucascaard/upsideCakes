using Microsoft.EntityFrameworkCore;

namespace upsideCakes.Models
{
    [Keyless] // Notação para entidade sem chave primária definida
    public class Cardapio
    {
        public List<Produto> _produtos { get; set; } 
        public int _quantidade { get; set; }

        public Cardapio(List<Produto> produtos, int quantidade)
        {
            _produtos = produtos;
            _quantidade = quantidade;
        }
    }
}
