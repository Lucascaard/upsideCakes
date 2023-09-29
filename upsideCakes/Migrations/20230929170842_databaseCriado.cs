using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace upsideCakes.Migrations
{
    /// <inheritdoc />
    public partial class databaseCriado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gerente",
                columns: table => new
                {
                    _idGerente = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    _nomeGerente = table.Column<string>(type: "TEXT", nullable: false),
                    _cpfGerente = table.Column<string>(type: "TEXT", maxLength: 11, nullable: false),
                    _telefone = table.Column<string>(type: "TEXT", nullable: false),
                    _email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gerente", x => x._idGerente);
                });

            migrationBuilder.CreateTable(
                name: "Pagamento",
                columns: table => new
                {
                    _idPedido = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    _valor = table.Column<float>(type: "REAL", nullable: false),
                    _formaDePagamento = table.Column<string>(type: "TEXT", nullable: false),
                    _data = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamento", x => x._idPedido);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    _name = table.Column<string>(type: "TEXT", nullable: false),
                    _price = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gerente__cpfGerente",
                table: "Gerente",
                column: "_cpfGerente",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gerente");

            migrationBuilder.DropTable(
                name: "Pagamento");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
