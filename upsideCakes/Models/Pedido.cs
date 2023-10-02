using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace upsideCakes.Models
{
    public class Pedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int _id { get; set; }
        public DateOnly _dataCriacao { get; set; }

        public Funcionario? Funcionario { get; set; }

        public Gerente? Gerente { get; set; }

        public List<Produto>? _itens { get; set; }
    }
}