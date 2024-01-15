using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework2.Migrations
{
    /// <inheritdoc />
    public partial class nuevaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facturas_Clientes_ClientesId_Cliente",
                table: "Facturas");

            migrationBuilder.DropIndex(
                name: "IX_Facturas_ClientesId_Cliente",
                table: "Facturas");

            migrationBuilder.DropColumn(
                name: "ClientesId_Cliente",
                table: "Facturas");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_Id_Cliente",
                table: "Facturas",
                column: "Id_Cliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Facturas_Clientes_Id_Cliente",
                table: "Facturas",
                column: "Id_Cliente",
                principalTable: "Clientes",
                principalColumn: "Id_Cliente",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facturas_Clientes_Id_Cliente",
                table: "Facturas");

            migrationBuilder.DropIndex(
                name: "IX_Facturas_Id_Cliente",
                table: "Facturas");

            migrationBuilder.AddColumn<int>(
                name: "ClientesId_Cliente",
                table: "Facturas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_ClientesId_Cliente",
                table: "Facturas",
                column: "ClientesId_Cliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Facturas_Clientes_ClientesId_Cliente",
                table: "Facturas",
                column: "ClientesId_Cliente",
                principalTable: "Clientes",
                principalColumn: "Id_Cliente");
        }
    }
}
