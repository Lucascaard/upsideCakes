using System.ComponentModel.DataAnnotations;

namespace upsideCakes.Models
{
    public class Produto
    {
        [Key]
        private int _id;
        private string? _nome;
        private float _preco;

        public Produto(int id, string? nome, float preco)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
        }
        public int Id { get => _id; set => _id = value; }
        public string? Nome { get => _nome; set => _nome = value; }
        public float Preco { get => _preco; set => _preco = value; }
    }
}