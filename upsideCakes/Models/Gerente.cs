
namespace upsideCakes.Models
{
    public class Gerente : Usuario
    {
        public Gerente()
        {

        }

        public Gerente(string login, string senha, string cargo, string nome, string cpf, DateOnly dataNasc, string endereco, string email, string telefone)
     : base(nome, cpf, dataNasc, endereco, email, telefone, login, senha, cargo)
        {
        }
    }
}