using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace upsideCakes.Models;

public class Filial
{
    [Key]
    public string? _cep { get; set; }
    public string? _cidade { get; set; }
    public string? _rua { get; set; }

    public Filial()
    {

    }

    public Filial(string cep, string cidade, string rua)
    {
        _cep = cep;
        _cidade = cidade;
        _rua = rua;
    }
}