
namespace upsideCakes.Models;

public abstract class Usuario : Pessoa
{
    public string? login { get; set; }
    public string? senha { get; set; }
    public string? cargo { get; set; } //Gerente e Funcionario

    protected Usuario()
    {

    }

    protected Usuario(string? nome, string? cpf, DateOnly dataNasc, string? endereco, string? email, string? telefone, string? login, string? senha, string? cargo) : base(nome, cpf, dataNasc, endereco, email, telefone)
    {
        this.login = login;
        this.senha = senha;
        this.cargo = cargo;
    }
}