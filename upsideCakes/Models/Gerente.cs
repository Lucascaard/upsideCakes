using System.ComponentModel.DataAnnotations;

namespace upsideCakes.Models
{
    public class Gerente
    {
        //public para funcionar a migration
       [Key] 
       public int _idGerente { get; set; }

       [Required]
       public string _nomeGerente {get; set; }

       [Required]
       [StringLength(11)]
       public string _cpfGerente {get; set; }

       [Required]
       public string _telefone { get; set; }

       [Required]
       public string _email { get; set; } 

       public Gerente()
       {
            _idGerente = 0;
            _nomeGerente = string.Empty;
            _cpfGerente = string.Empty;
            _telefone = string.Empty;
            _email = string.Empty;
       }

       public Gerente(int idGerente, string nomeGerente, string cpfGerente, string telefone, string email)
       {
            _idGerente = idGerente;
            _nomeGerente = nomeGerente;
            _cpfGerente = cpfGerente;
            _email = email;
            _telefone = telefone;
       } 
    }
}