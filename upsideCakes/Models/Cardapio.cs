namespace upsideCakes.Models
{
    public class Cardapio
    {
        public Produto _produto { get; set; }
        public int _quantidade { get; set; }

        public Cardapio(Produto produto, int quantidade)
        {
            _produto = produto;
            _quantidade = quantidade;
        }
    }
}