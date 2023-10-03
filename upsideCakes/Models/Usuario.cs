
namespace upsideCakes.Models;

public abstract class Usuario : Pessoa
{
    public string? _login { get; set; }
    public string? _senha { get; set; }
    public string? _cargo { get; set; } //Gerente e Funcionario
}