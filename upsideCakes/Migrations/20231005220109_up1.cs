using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace upsideCakes.Migrations
{
    /// <inheritdoc />
    public partial class up1 : Migration
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
                name: "Produto",
                columns: table => new
                {
                    _id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    _nome = table.Column<string>(type: "TEXT", nullable: true),
                    _preco = table.Column<double>(type: "REAL", nullable: false),
                    _categoria = table.Column<string>(type: "TEXT", nullable: true),
                    Cardapio_id = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x._id);
                    table.ForeignKey(
                        name: "FK_Produto_Cardapio_Cardapio_id",
                        column: x => x.Cardapio_id,
                        principalTable: "Cardapio",
                        principalColumn: "_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produto_Cardapio_id",
                table: "Produto",
                column: "Cardapio_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Gerente");

            migrationBuilder.DropTable(
                name: "Pagamento");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Cardapio");
        }
    }
}
