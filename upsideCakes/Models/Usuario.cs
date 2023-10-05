
namespace upsideCakes.Models;

public abstract class Usuario : Pessoa
{
    public string? _login { get; set; }
    public string? _senha { get; set; }
    public string? _cargo { get; set; } //Gerente e Funcionario

    //JSON
    protected Usuario()
    {

    }

    protected Usuario(string? nome, string? cpf, DateOnly dataNasc, string? endereco, string? email, string? telefone, string? login, string? senha, string? cargo) : base(nome, cpf, dataNasc, endereco, email, telefone)
    {
        _login = login;
        _senha = senha;
        _cargo = cargo;
    }
}