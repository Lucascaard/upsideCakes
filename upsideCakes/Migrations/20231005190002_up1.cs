using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace upsideCakes.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cardapio",
                columns: table => new
                {
                    _id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cardapio", x => x._id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    _id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    _nome = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    _cpf = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    _dataNasc = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    _endereco = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    _email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    _telefone = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x._id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    _id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    _nome = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    _cpf = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    _dataNasc = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    _endereco = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    _email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    _telefone = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    _login = table.Column<string>(type: "TEXT", nullable: true),
                    _senha = table.Column<string>(type: "TEXT", nullable: true),
                    _cargo = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x._id);
                });

            migrationBuilder.CreateTable(
                name: "Gerente",
                columns: table => new
                {
                    _id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    _nome = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    _cpf = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    _dataNasc = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    _endereco = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    _email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    _telefone = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    _login = table.Column<string>(type: "TEXT", nullable: true),
                    _senha = table.Column<string>(type: "TEXT", nullable: true),
                    _cargo = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gerente", x => x._id);
                });

            migrationBuilder.CreateTable(
<<<<<<<< HEAD:upsideCakes/Migrations/20231005001031_FirstMigration.cs
                name: "ItemCardapio",
                columns: table => new
                {
                    _nome = table.Column<string>(type: "TEXT", nullable: false),
                    _preco = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCardapio", x => x._nome);
========
                name: "Pagamento",
                columns: table => new
                {
                    _id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    _data = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    _valor = table.Column<float>(type: "REAL", nullable: false),
                    _formaDePagamento = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamento", x => x._id);
>>>>>>>> main:upsideCakes/Migrations/20231005190002_up1.cs
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    _id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    _dataCriacao = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    _funcionarioID = table.Column<int>(type: "INTEGER", nullable: false),
                    _gerenteID = table.Column<int>(type: "INTEGER", nullable: false),
                    _qtde = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x._id);
                });

            migrationBuilder.CreateTable(
<<<<<<<< HEAD:upsideCakes/Migrations/20231005001031_FirstMigration.cs
                name: "Pagamento",
                columns: table => new
                {
                    _id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    _valor = table.Column<float>(type: "REAL", nullable: false),
                    _formaDePagamento = table.Column<string>(type: "TEXT", nullable: true),
                    _data = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    _pedido_id = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamento", x => x._id);
                    table.ForeignKey(
                        name: "FK_Pagamento_Pedido__pedido_id",
                        column: x => x._pedido_id,
                        principalTable: "Pedido",
                        principalColumn: "_id");
                });

            migrationBuilder.CreateTable(
========
>>>>>>>> main:upsideCakes/Migrations/20231005190002_up1.cs
                name: "Produto",
                columns: table => new
                {
                    _id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
<<<<<<<< HEAD:upsideCakes/Migrations/20231005001031_FirstMigration.cs
                    _nome = table.Column<string>(type: "TEXT", nullable: false),
                    _preco = table.Column<double>(type: "REAL", nullable: false),
                    _categoria = table.Column<string>(type: "TEXT", nullable: false),
                    Pedido_id = table.Column<int>(type: "INTEGER", nullable: true)
========
                    _nome = table.Column<string>(type: "TEXT", nullable: true),
                    _preco = table.Column<double>(type: "REAL", nullable: false),
                    _categoria = table.Column<string>(type: "TEXT", nullable: true),
                    CardapioId = table.Column<int>(type: "INTEGER", nullable: true)
>>>>>>>> main:upsideCakes/Migrations/20231005190002_up1.cs
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x._id);
                    table.ForeignKey(
<<<<<<<< HEAD:upsideCakes/Migrations/20231005001031_FirstMigration.cs
                        name: "FK_Produto_Pedido_Pedido_id",
                        column: x => x.Pedido_id,
                        principalTable: "Pedido",
                        principalColumn: "_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento__pedido_id",
                table: "Pagamento",
                column: "_pedido_id");

========
                        name: "FK_Produto_Cardapio_CardapioId",
                        column: x => x.CardapioId,
                        principalTable: "Cardapio",
                        principalColumn: "Id");
                });

>>>>>>>> main:upsideCakes/Migrations/20231005190002_up1.cs
            migrationBuilder.CreateIndex(
                name: "IX_Produto_Pedido_id",
                table: "Produto",
                column: "Pedido_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cardapio");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Gerente");

            migrationBuilder.DropTable(
                name: "ItemCardapio");

            migrationBuilder.DropTable(
                name: "Pagamento");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
<<<<<<<< HEAD:upsideCakes/Migrations/20231005001031_FirstMigration.cs
                name: "Pedido");
========
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Cardapio");
>>>>>>>> main:upsideCakes/Migrations/20231005190002_up1.cs
        }
    }
}
