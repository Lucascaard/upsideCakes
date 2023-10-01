using System.ComponentModel.DataAnnotations;

namespace upsideCakes.Models
{
    public class Pedido
    {
        [Key]
        public int _id { get; set; }
        public DateOnly _dataCriacao { get; set; }

        public List<Produto>? _itens { get; set; }

        public Pedido(DateOnly dataCriacao, List<Produto> itens)
        {
            _dataCriacao = dataCriacao;
            _itens = itens;
        }
    }
}