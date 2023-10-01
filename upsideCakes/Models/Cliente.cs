using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace upsideCakes.Models
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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