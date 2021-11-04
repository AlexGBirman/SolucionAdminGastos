using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminGastos.Migrations
{
    public partial class SePuede : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Gastos",
                table: "Gastos");

            migrationBuilder.RenameTable(
                name: "Gastos",
                newName: "Operacion");

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "Operacion",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Operacion",
                table: "Operacion",
                column: "IdOperacion");

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    importe = table.Column<double>(type: "float", nullable: false),
                    concepto = table.Column<int>(type: "int", nullable: false),
                    OperacionIdOperacion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Productos_Operacion_OperacionIdOperacion",
                        column: x => x.OperacionIdOperacion,
                        principalTable: "Operacion",
                        principalColumn: "IdOperacion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_OperacionIdOperacion",
                table: "Productos",
                column: "OperacionIdOperacion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Operacion",
                table: "Operacion");

            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Operacion");

            migrationBuilder.RenameTable(
                name: "Operacion",
                newName: "Gastos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gastos",
                table: "Gastos",
                column: "IdOperacion");
        }
    }
}
