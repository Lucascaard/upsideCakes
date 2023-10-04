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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cardapio", x => x.Id);
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
                name: "Pedido",
                columns: table => new
                {
                    _id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    _dataCriacao = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    _funcionarioID = table.Column<int>(type: "INTEGER", nullable: false),
                    _gerenteID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x._id);
                });

            migrationBuilder.CreateTable(
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
                name: "Produto",
                columns: table => new
                {
                    _id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    _nome = table.Column<string>(type: "TEXT", nullable: false),
                    _preco = table.Column<double>(type: "REAL", nullable: false),
                    _categoria = table.Column<string>(type: "TEXT", nullable: false),
                    CardapioId = table.Column<int>(type: "INTEGER", nullable: true),
                    Pedido_id = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x._id);
                    table.ForeignKey(
                        name: "FK_Produto_Cardapio_CardapioId",
                        column: x => x.CardapioId,
                        principalTable: "Cardapio",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Produto_Pedido_Pedido_id",
                        column: x => x.Pedido_id,
                        principalTable: "Pedido",
                        principalColumn: "_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento__pedido_id",
                table: "Pagamento",
                column: "_pedido_id");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_CardapioId",
                table: "Produto",
                column: "CardapioId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_Pedido_id",
                table: "Produto",
                column: "Pedido_id");
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
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Cardapio");

            migrationBuilder.DropTable(
                name: "Pedido");
        }
    }
}
