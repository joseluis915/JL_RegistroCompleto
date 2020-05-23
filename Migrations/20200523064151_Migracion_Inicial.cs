using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tarea2_RegistroCompleto.Migrations
{
    public partial class Migracion_Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DatosPersonales",
                columns: table => new
                {
                    DatosPersonalesId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreCompleto = table.Column<string>(nullable: true),
                    Telefono = table.Column<int>(nullable: false),
                    Cedula = table.Column<int>(nullable: false),
                    Direccion = table.Column<string>(nullable: true),
                    FechaNacimiento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatosPersonales", x => x.DatosPersonalesId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DatosPersonales");
        }
    }
}
