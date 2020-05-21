using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kalum2020v1.Migrations
{
    public partial class CompleteModelKalum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarreraTecnica",
                columns: table => new
                {
                    CarreraTecnicaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCarrera = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarreraTecnica", x => x.CarreraTecnicaId);
                });

            migrationBuilder.CreateTable(
                name: "Horarios",
                columns: table => new
                {
                    HorarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HorarioInicio = table.Column<DateTime>(nullable: false),
                    HorarioFinal = table.Column<DateTime>(nullable: false),
                    HorarioId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horarios", x => x.HorarioId);
                    table.ForeignKey(
                        name: "FK_Horarios_Horarios_HorarioId1",
                        column: x => x.HorarioId1,
                        principalTable: "Horarios",
                        principalColumn: "HorarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Instructores",
                columns: table => new
                {
                    InstructorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Apellidos = table.Column<string>(nullable: true),
                    Nombres = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Comentario = table.Column<string>(nullable: true),
                    Estatus = table.Column<string>(nullable: true),
                    Foto = table.Column<string>(nullable: true),
                    InstructorId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructores", x => x.InstructorId);
                    table.ForeignKey(
                        name: "FK_Instructores_Instructores_InstructorId1",
                        column: x => x.InstructorId1,
                        principalTable: "Instructores",
                        principalColumn: "InstructorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Salones",
                columns: table => new
                {
                    SalonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreSalon = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Capacidad = table.Column<int>(nullable: false),
                    SalonId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salones", x => x.SalonId);
                    table.ForeignKey(
                        name: "FK_Salones_Salones_SalonId1",
                        column: x => x.SalonId1,
                        principalTable: "Salones",
                        principalColumn: "SalonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clase",
                columns: table => new
                {
                    ClaseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true),
                    Ciclo = table.Column<int>(nullable: false),
                    CarreraTecnicaId = table.Column<int>(nullable: false),
                    SalonID = table.Column<int>(nullable: false),
                    HorarioID = table.Column<int>(nullable: false),
                    IsntructorId = table.Column<string>(nullable: true),
                    CarreraId = table.Column<string>(nullable: true),
                    CupoMinimo = table.Column<int>(nullable: false),
                    CupoMaximo = table.Column<int>(nullable: false),
                    CantidadAsignaciones = table.Column<int>(nullable: false),
                    InstructorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clase", x => x.ClaseID);
                    table.ForeignKey(
                        name: "FK_Clase_CarreraTecnica_CarreraTecnicaId",
                        column: x => x.CarreraTecnicaId,
                        principalTable: "CarreraTecnica",
                        principalColumn: "CarreraTecnicaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clase_Horarios_HorarioID",
                        column: x => x.HorarioID,
                        principalTable: "Horarios",
                        principalColumn: "HorarioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clase_Instructores_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructores",
                        principalColumn: "InstructorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clase_Salones_SalonID",
                        column: x => x.SalonID,
                        principalTable: "Salones",
                        principalColumn: "SalonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AsignacionAlumnos_ClaseId",
                table: "AsignacionAlumnos",
                column: "ClaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Clase_CarreraTecnicaId",
                table: "Clase",
                column: "CarreraTecnicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Clase_HorarioID",
                table: "Clase",
                column: "HorarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Clase_InstructorId",
                table: "Clase",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Clase_SalonID",
                table: "Clase",
                column: "SalonID");

            migrationBuilder.CreateIndex(
                name: "IX_Horarios_HorarioId1",
                table: "Horarios",
                column: "HorarioId1");

            migrationBuilder.CreateIndex(
                name: "IX_Instructores_InstructorId1",
                table: "Instructores",
                column: "InstructorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Salones_SalonId1",
                table: "Salones",
                column: "SalonId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AsignacionAlumnos_Clase_ClaseId",
                table: "AsignacionAlumnos",
                column: "ClaseId",
                principalTable: "Clase",
                principalColumn: "ClaseID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AsignacionAlumnos_Clase_ClaseId",
                table: "AsignacionAlumnos");

            migrationBuilder.DropTable(
                name: "Clase");

            migrationBuilder.DropTable(
                name: "CarreraTecnica");

            migrationBuilder.DropTable(
                name: "Horarios");

            migrationBuilder.DropTable(
                name: "Instructores");

            migrationBuilder.DropTable(
                name: "Salones");

            migrationBuilder.DropIndex(
                name: "IX_AsignacionAlumnos_ClaseId",
                table: "AsignacionAlumnos");
        }
    }
}
