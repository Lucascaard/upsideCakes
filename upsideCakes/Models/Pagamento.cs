using System.ComponentModel.DataAnnotations;

namespace upsideCakes.Models
{
    public class Pagamento
    {
        [Key]
        private int _id;
        [Required]
        private float _valor;
        [Required]
        private string? _formaDePagamento;
        [Required]
        private DateOnly _data;

        public Pagamento(int id, float valor, string? formaDePagamento, DateOnly data)
        {
            Id = id;
            Valor = valor;
            FormaDePagamento = formaDePagamento;
            Data = data;
        }
        public int Id { get => _id; set => _id = value; }
        public float Valor { get => _valor; set => _valor = value; }
        public string? FormaDePagamento { get => _formaDePagamento; set => _formaDePagamento = value; }
        public DateOnly Data { get => _data; set => _data = value; }
    }
}