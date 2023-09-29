
using System.ComponentModel.DataAnnotations;

namespace upsideCakes.Models
{
    public class Funcionario
    {
        [Key]
        private int _id;
        private DateOnly _dataNasc;
        private int _telefone;
        private string? _email;

        public Funcionario(int id, DateOnly dataNasc, int telefone, string? email)
        {
            Id = id;
            DataNasc = dataNasc;
            Telefone = telefone;
            Email = email;
        }
        public int Id { get => _id; set => _id = value; }
        public DateOnly DataNasc { get => _dataNasc; set => _dataNasc = value; }
        public int Telefone { get => _telefone; set => _telefone = value; }
        public string? Email { get => _email; set => _email = value; }
    }
}