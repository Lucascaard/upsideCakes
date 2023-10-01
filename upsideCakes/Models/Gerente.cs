using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace upsideCakes.Models
{
    public class Gerente : Pessoa  
        // Como � um extends de Pessoa n�o precisa de atributo nome e nem cpf, ser� herdado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int _id { get; set; }
    }
}