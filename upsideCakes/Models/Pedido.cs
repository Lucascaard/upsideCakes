using System.ComponentModel.DataAnnotations;

namespace upsideCakes.Models
{
    public class Pedido
    {
        [Key]
        private int _id;
        private DateOnly _dataCriacao;
        private List<Produto>? _itens;

        public Pedido(int id, DateOnly dataCriacao, List<Produto>? itens)
        {
            Id = id;
            DataCriacao = dataCriacao;
            Itens = itens;
        }
        public int Id { get => _id; set => _id = value; }
        public DateOnly DataCriacao { get => _dataCriacao; set => _dataCriacao = value; }
        public List<Produto>? Itens { get => _itens; set => _itens = value; }
    }
}