using System.ComponentModel.DataAnnotations;

namespace upsideCakes.Models
{
    public class Funcionario
    {
        [Key]
        public int _id { get; set; }
        public DateOnly _dataNasc { get; set; }
        public int _telefone { get; set; }
        public string? _email {get; set; }

        public Funcionario(DateOnly dataNasc, int telefone, string email)
        {
            _dataNasc = dataNasc;
            _telefone = telefone;
            _email = email;
        }
    }
}