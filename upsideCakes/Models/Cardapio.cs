using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace upsideCakes.Models
{ 
    
    public class Cardapio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string nome {get; set;}
        public List<Produto>? itens { get; set; }

        public Cardapio(string nome)
        {
            this.nome = nome;
            itens = new List<Produto>();
        }
        
    }
}
