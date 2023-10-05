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
                name: "FK_Pagamento_Pedido__pedido_id",
                table: "Pagamento");

            migrationBuilder.DropIndex(
                name: "IX_Pagamento__pedido_id",
                table: "Pagamento");

            migrationBuilder.DropColumn(
                name: "_pedido_id",
                table: "Pagamento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "_pedido_id",
                table: "Pagamento",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento__pedido_id",
                table: "Pagamento",
                column: "_pedido_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pagamento_Pedido__pedido_id",
                table: "Pagamento",
                column: "_pedido_id",
                principalTable: "Pedido",
                principalColumn: "_id");
        }
    }
}
