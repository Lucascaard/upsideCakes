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
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Pedido_Pedidoid",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Produto_Pedidoid",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "Pedidoid",
                table: "Produto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Pedidoid",
                table: "Produto",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produto_Pedidoid",
                table: "Produto",
                column: "Pedidoid");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Pedido_Pedidoid",
                table: "Produto",
                column: "Pedidoid",
                principalTable: "Pedido",
                principalColumn: "id");
        }
    }
}
