using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kalum2020v1.Migrations
{
    public partial class CreateKalumAsignacionAlumno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AsignacionAlumnos",
                columns: table => new
                {
                    AsignacionAlumnoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaseId = table.Column<int>(nullable: false),
                    AsAlumnoID = table.Column<int>(nullable: false),
                    FechaAsignacion = table.Column<DateTime>(nullable: false),
                    Observaciones = table.Column<string>(nullable: true),
                    AlumnoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsignacionAlumnos", x => x.AsignacionAlumnoId);
                    table.ForeignKey(
                        name: "FK_AsignacionAlumnos_Alumnos_AlumnoID",
                        column: x => x.AlumnoID,
                        principalTable: "Alumnos",
                        principalColumn: "AlumnoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AsignacionAlumnos_AlumnoID",
                table: "AsignacionAlumnos",
                column: "AlumnoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AsignacionAlumnos");
        }
    }
}
