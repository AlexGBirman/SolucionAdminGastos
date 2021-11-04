using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminGastos.Migrations
{
    public partial class PORFIS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Operacion_OperacionIdOperacion",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_OperacionIdOperacion",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "OperacionIdOperacion",
                table: "Productos");

            migrationBuilder.AddColumn<string>(
                name: "Producto",
                table: "Operacion",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Producto",
                table: "Operacion");

            migrationBuilder.AddColumn<int>(
                name: "OperacionIdOperacion",
                table: "Productos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_OperacionIdOperacion",
                table: "Productos",
                column: "OperacionIdOperacion");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Operacion_OperacionIdOperacion",
                table: "Productos",
                column: "OperacionIdOperacion",
                principalTable: "Operacion",
                principalColumn: "IdOperacion",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
