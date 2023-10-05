using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace upsideCakes.Models
{ 
    
    public class Cardapio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int _id { get; set; }
        // [NotMapped]
        public List<Produto>? _itens { get; set; }
    }
}
