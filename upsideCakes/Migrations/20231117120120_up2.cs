﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace upsideCakes.Migrations
{
    /// <inheritdoc />
    public partial class up2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cardapio",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cardapio", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    cpf = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    dataNasc = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    endereco = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    telefone = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Filial",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    cep = table.Column<string>(type: "TEXT", nullable: true),
                    cidade = table.Column<string>(type: "TEXT", nullable: true),
                    rua = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filial", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    cpf = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    dataNasc = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    endereco = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    telefone = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    login = table.Column<string>(type: "TEXT", nullable: true),
                    senha = table.Column<string>(type: "TEXT", nullable: true),
                    cargo = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Gerente",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    cpf = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    dataNasc = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    endereco = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    telefone = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    login = table.Column<string>(type: "TEXT", nullable: true),
                    senha = table.Column<string>(type: "TEXT", nullable: true),
                    cargo = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gerente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    dataCriacao = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    funcionarioID = table.Column<int>(type: "INTEGER", nullable: false),
                    gerenteID = table.Column<int>(type: "INTEGER", nullable: false),
                    qtde = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", nullable: true),
                    preco = table.Column<double>(type: "REAL", nullable: false),
                    categoria = table.Column<string>(type: "TEXT", nullable: true),
                    Cardapioid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.id);
                    table.ForeignKey(
                        name: "FK_Produto_Cardapio_Cardapioid",
                        column: x => x.Cardapioid,
                        principalTable: "Cardapio",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Pagamento",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    data = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    idCliente = table.Column<int>(type: "INTEGER", nullable: false),
                    valor = table.Column<float>(type: "REAL", nullable: false),
                    formaDePagamento = table.Column<string>(type: "TEXT", nullable: true),
                    idPedido = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamento", x => x.id);
                    table.ForeignKey(
                        name: "FK_Pagamento_Cliente_idCliente",
                        column: x => x.idCliente,
                        principalTable: "Cliente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pagamento_Pedido_idPedido",
                        column: x => x.idPedido,
                        principalTable: "Pedido",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_idCliente",
                table: "Pagamento",
                column: "idCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_idPedido",
                table: "Pagamento",
                column: "idPedido");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_Cardapioid",
                table: "Produto",
                column: "Cardapioid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filial");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Gerente");

            migrationBuilder.DropTable(
                name: "Pagamento");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Cardapio");
        }
    }
}