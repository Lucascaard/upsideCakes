using System.Collections.Generic;
using upsideCakes.Models;

namespace upsideCakes.Data
{
    public class DadosFicticios
    { 
        public List<Produto> ObterProdutosFicticios()
        {
            var produtosFicticios = new List<Produto>
            {
                new Produto("Bolo de Chocolate", 59.99, "Bolos"),
                new Produto("Bolo de Cenoura", 59.99, "Bolos"),
                new Produto("CupCake de Frutas Vermelhas", 19.99, "CupCakes"),
                new Produto("CupCake de Morango", 19.99, "CupCakes"),
                new Produto("Coca-Cola", 4.99, "Bebidas"),
                new Produto("Pepsi", 4.99, "Bebidas"),
            };
            return produtosFicticios;
        }

        public List<Gerente> CriarDadosFicticiosGerente()
        {
            var gerentesFicticios = new List<Gerente>
            {
                new Gerente("CR7", "senha123", "Gerente de Vendas", "Cristiano Ronaldo", "12345678901", new DateOnly(1980, 1, 15), "123 Main Street", "alice@example.com", "123-456-7890"),
                new Gerente("Leo", "senha456", "Gerente de Operações", "Leonel Messi", "23456789012", new DateOnly(1985, 5, 25), "456 Elm Avenue", "bob@example.com", "234-567-8901"),
                new Gerente("R9", "senha789", "Gerente de RH", "Ronaldo", "34567890123", new DateOnly(1990, 9, 5), "789 Oak Lane", "carol@example.com", "345-678-9012"),
                new Gerente("Pogpog", "senha101", "Gerente de Marketing", "Paul Pogba", "45678901234", new DateOnly(1982, 3, 10), "101 Pine Road", "david@example.com", "456-789-0123"),
                new Gerente("Caça Rato", "senha202", "Gerente de TI", "Everton", "56789012345", new DateOnly(1987, 7, 20), "202 Cedar Street", "eve@example.com", "567-890-1234")
            };

            return gerentesFicticios;
        }

        public List<Funcionario> CriarDadosFicticiosFuncionario()
        {
            var funcionariosFicticios = new List<Funcionario>
                {
                    new Funcionario("paulo123", "senha123", "Atendente", "Paulo", "12345678901", new DateOnly(1995, 2, 18), "123 Main Street", "alice@example.com", "123-456-7890"),
                    new Funcionario("Bobzera", "senha456", "Cozinheiro", "Bob Marley", "23456789012", new DateOnly(1990, 7, 12), "456 Elm Avenue", "bob@example.com", "234-567-8901"),
                    new Funcionario("Fiukinho", "senha789", "Garçom", "Fiuk", "34567890123", new DateOnly(1988, 10, 8), "789 Oak Lane", "carol@example.com", "345-678-9012"),
                    new Funcionario("en3jot4", "senha101", "Entregador", "Neymar Jr", "45678901234", new DateOnly(1993, 5, 5), "101 Pine Road", "david@example.com", "456-789-0123"),
                    new Funcionario("bobo", "senha202", "Limpeza", "Kevin Prince Boateng", "56789012345", new DateOnly(1997, 12, 3), "202 Cedar Street", "eve@example.com", "567-890-1234")
                };

            return funcionariosFicticios;
        }

        public List<Cliente> CriarDadosFicticiosCliente()
        {
            var clientesFicticios = new List<Cliente>
    {
        new Cliente("Joilson", "12345678901", new DateOnly(1980, 3, 15), "123 Oak Street", "ana@example.com", "123-456-7890"),
        new Cliente("Vandercleia", "23456789012", new DateOnly(1992, 6, 28), "456 Maple Avenue", "bruno@example.com", "234-567-8901"),
        new Cliente("Robervalson", "34567890123", new DateOnly(1985, 9, 12), "789 Elm Lane", "clara@example.com", "345-678-9012"),
        new Cliente("Geromel", "45678901234", new DateOnly(1998, 4, 7), "101 Cedar Road", "daniel@example.com", "456-789-0123"),
        new Cliente("Barack Obama", "56789012345", new DateOnly(1991, 11, 23), "202 Pine Street", "eva@example.com", "567-890-1234")
    };

            return clientesFicticios;
        }



    }
}
