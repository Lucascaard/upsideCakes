using System.ComponentModel.DataAnnotations;

namespace upsideCakes.Models
{
    public class Cliente
    {
        [Key]
        public int _id { get; set; }
        public DateOnly _dataNasc { get; set; }
        public string? _endereco { get; set; }
        public string? _email { get; set; }



        public Cliente(DateOnly dataNasc, string endereco, string email)
        {
            _dataNasc = dataNasc;
            _endereco = endereco;
            _email = email;
        }

    }
}