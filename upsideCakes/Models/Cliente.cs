using System.ComponentModel.DataAnnotations;

namespace upsideCakes.Models
{
    public class Cliente
    {
        [Key]
        private int _id;
        private DateOnly _dataNasc;
        private string? _endereco;
        private string? _email;

        public Cliente(int id, DateOnly dataNasc, string? endereco, string? email)
        {
            _id = id;
            _dataNasc = dataNasc;
            _endereco = endereco;
            _email = email;
        }

        public int Id { get => _id; set => _id = value; }
        public DateOnly DataNasc { get => _dataNasc; set => _dataNasc = value; }
        public string? Endereco { get => _endereco; set => _endereco = value; }
        public string? Email { get => _email; set => _email = value; }
    }
}