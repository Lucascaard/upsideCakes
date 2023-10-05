
namespace upsideCakes.Models
{
    public class Funcionario : Usuario
    {
        //JSON
        public Funcionario()
        {

        }

        public Funcionario(string login, string senha, string cargo, string nome, string cpf, DateOnly dataNasc, string endereco, string email, string telefone)
            : base(nome, cpf, dataNasc, endereco, email, telefone, login, senha, cargo)
                    {
                    }

    }
}