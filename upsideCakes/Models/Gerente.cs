using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace upsideCakes.Models
{
    public class Gerente
    {
       private int _id { get; set; }
       private string _telefone { get; set; }
       private string _email { get; set; }

       public Gerente()
       {

       }

       public Gerente(string telefone, string email)
       {
            _email = email;
            _telefone = telefone;
       } 
    }
}