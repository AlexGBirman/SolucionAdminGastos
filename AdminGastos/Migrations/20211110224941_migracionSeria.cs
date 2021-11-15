using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminGastos.Migrations
{
    public partial class migracionSeria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Operacion",
                columns: table => new
                {
                    IdOperacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    importe = table.Column<double>(type: "float", nullable: false),
                    Producto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Concepto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operacion", x => x.IdOperacion);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    importe = table.Column<double>(type: "float", nullable: false),
                    concepto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Operacion");

            migrationBuilder.DropTable(
                name: "Productos");
        }
    }
}
