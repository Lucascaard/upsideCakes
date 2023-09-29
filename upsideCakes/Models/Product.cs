using System.ComponentModel.DataAnnotations;

namespace upsideCakes.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string _name { get; set; }
        public float _price { get; set; }
    }
}