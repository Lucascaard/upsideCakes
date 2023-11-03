using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace upsideCakes.Models;

public class Filial
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    public string? cep { get; set; }
    public string? cidade { get; set; }
    public string? rua { get; set; }

    public Filial()
    {

    }

    public Filial(string cep, string cidade, string rua)
    {
        this.cep = cep;
        this.cidade = cidade;
        this.rua = rua;
    }
}