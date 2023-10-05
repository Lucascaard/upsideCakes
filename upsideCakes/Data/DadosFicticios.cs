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
                new Produto("Coca-Cola", 4.99, "Bebidas"),
                new Produto("Pepsi", 4.99, "Bebidas"),
            };
            return produtosFicticios;
        }

        public List<Gerente> CriarDadosFicticiosGerente()
        {
            var gerentesFicticios = new List<Gerente>
            {
                new Gerente("gerenteAlice", "senha123", "Gerente de Vendas", "Alice Johnson", "12345678901", new DateOnly(1980, 1, 15), "123 Main Street", "alice@example.com", "123-456-7890"),
                new Gerente("gerenteBob", "senha456", "Gerente de Operações", "Bob Smith", "23456789012", new DateOnly(1985, 5, 25), "456 Elm Avenue", "bob@example.com", "234-567-8901"),
                new Gerente("gerenteCarol", "senha789", "Gerente de RH", "Carol Williams", "34567890123", new DateOnly(1990, 9, 5), "789 Oak Lane", "carol@example.com", "345-678-9012"),
                new Gerente("gerenteDavid", "senha101", "Gerente de Marketing", "David Davis", "45678901234", new DateOnly(1982, 3, 10), "101 Pine Road", "david@example.com", "456-789-0123"),
                new Gerente("gerenteEve", "senha202", "Gerente de TI", "Eve Wilson", "56789012345", new DateOnly(1987, 7, 20), "202 Cedar Street", "eve@example.com", "567-890-1234")
            };

            return gerentesFicticios;
        }

        public List<Funcionario> CriarDadosFicticiosFuncionario()
        {
            var funcionariosFicticios = new List<Funcionario>
                {
                    new Funcionario("funcionarioAlice", "senha123", "Atendente", "Alice Johnson", "12345678901", new DateOnly(1995, 2, 18), "123 Main Street", "alice@example.com", "123-456-7890"),
                    new Funcionario("funcionarioBob", "senha456", "Cozinheiro", "Bob Smith", "23456789012", new DateOnly(1990, 7, 12), "456 Elm Avenue", "bob@example.com", "234-567-8901"),
                    new Funcionario("funcionarioCarol", "senha789", "Garçom", "Carol Williams", "34567890123", new DateOnly(1988, 10, 8), "789 Oak Lane", "carol@example.com", "345-678-9012"),
                    new Funcionario("funcionarioDavid", "senha101", "Entregador", "David Davis", "45678901234", new DateOnly(1993, 5, 5), "101 Pine Road", "david@example.com", "456-789-0123"),
                    new Funcionario("funcionarioEve", "senha202", "Limpeza", "Eve Wilson", "56789012345", new DateOnly(1997, 12, 3), "202 Cedar Street", "eve@example.com", "567-890-1234")
                };

            return funcionariosFicticios;
        }

        public List<Cliente> CriarDadosFicticiosCliente()
        {
            var clientesFicticios = new List<Cliente>
    {
        new Cliente("Ana Silva", "12345678901", new DateOnly(1980, 3, 15), "123 Oak Street", "ana@example.com", "123-456-7890"),
        new Cliente("Bruno Oliveira", "23456789012", new DateOnly(1992, 6, 28), "456 Maple Avenue", "bruno@example.com", "234-567-8901"),
        new Cliente("Clara Santos", "34567890123", new DateOnly(1985, 9, 12), "789 Elm Lane", "clara@example.com", "345-678-9012"),
        new Cliente("Daniel Pereira", "45678901234", new DateOnly(1998, 4, 7), "101 Cedar Road", "daniel@example.com", "456-789-0123"),
        new Cliente("Eva Rodrigues", "56789012345", new DateOnly(1991, 11, 23), "202 Pine Street", "eva@example.com", "567-890-1234")
    };

            return clientesFicticios;
        }



    }
}
