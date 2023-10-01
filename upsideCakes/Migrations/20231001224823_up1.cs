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
                name: "Funcionario",
                columns: table => new
                {
                    _id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    _nome = table.Column<string>(type: "TEXT", nullable: true),
                    _cpf = table.Column<string>(type: "TEXT", nullable: true),
                    _dataNasc = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    _endereco = table.Column<string>(type: "TEXT", nullable: true),
                    _email = table.Column<string>(type: "TEXT", nullable: true),
                    _telefone = table.Column<int>(type: "INTEGER", nullable: false)
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
                    _nome = table.Column<string>(type: "TEXT", nullable: true),
                    _cpf = table.Column<string>(type: "TEXT", nullable: true),
                    _dataNasc = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    _endereco = table.Column<string>(type: "TEXT", nullable: true),
                    _email = table.Column<string>(type: "TEXT", nullable: true),
                    _telefone = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gerente", x => x._id);
                });

            migrationBuilder.CreateTable(
                name: "Pagamento",
                columns: table => new
                {
                    _idPedido = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    _valor = table.Column<float>(type: "REAL", nullable: false),
                    _formaDePagamento = table.Column<string>(type: "TEXT", nullable: true),
                    _data = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamento", x => x._idPedido);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    _id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    _nome = table.Column<string>(type: "TEXT", nullable: true),
                    _preco = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x._id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Gerente");

            migrationBuilder.DropTable(
                name: "Pagamento");

            migrationBuilder.DropTable(
                name: "Produto");
        }
    }
}
