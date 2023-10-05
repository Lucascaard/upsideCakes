using System.ComponentModel.DataAnnotations;

namespace upsideCakes.Models;

public class ItemCardapio
{
    [Key]
    public string? _nome { get; set; }
    public double _preco { get; set; }

}