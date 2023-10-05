

namespace upsideCakes.Models
{
    public class Cliente : Pessoa
    {
        //PARA O JSON
        public Cliente()
        {

        }

        public Cliente(string? nome, string? cpf, DateOnly dataNasc, string? endereco, string? email, string? telefone) : base(nome, cpf, dataNasc, endereco, email, telefone)
        {
        }
    }
}