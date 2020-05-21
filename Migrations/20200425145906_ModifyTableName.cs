using Microsoft.EntityFrameworkCore.Migrations;

namespace Kalum2020v1.Migrations
{
    public partial class ModifyTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AsignacionAlumnos_Clase_ClaseId",
                table: "AsignacionAlumnos");

            migrationBuilder.DropForeignKey(
                name: "FK_Clase_CarreraTecnica_CarreraTecnicaId",
                table: "Clase");

            migrationBuilder.DropForeignKey(
                name: "FK_Clase_Horarios_HorarioID",
                table: "Clase");

            migrationBuilder.DropForeignKey(
                name: "FK_Clase_Instructores_InstructorId",
                table: "Clase");

            migrationBuilder.DropForeignKey(
                name: "FK_Clase_Salones_SalonID",
                table: "Clase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clase",
                table: "Clase");

            migrationBuilder.RenameTable(
                name: "Clase",
                newName: "Clases");

            migrationBuilder.RenameIndex(
                name: "IX_Clase_SalonID",
                table: "Clases",
                newName: "IX_Clases_SalonID");

            migrationBuilder.RenameIndex(
                name: "IX_Clase_InstructorId",
                table: "Clases",
                newName: "IX_Clases_InstructorId");

            migrationBuilder.RenameIndex(
                name: "IX_Clase_HorarioID",
                table: "Clases",
                newName: "IX_Clases_HorarioID");

            migrationBuilder.RenameIndex(
                name: "IX_Clase_CarreraTecnicaId",
                table: "Clases",
                newName: "IX_Clases_CarreraTecnicaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clases",
                table: "Clases",
                column: "ClaseID");

            migrationBuilder.AddForeignKey(
                name: "FK_AsignacionAlumnos_Clases_ClaseId",
                table: "AsignacionAlumnos",
                column: "ClaseId",
                principalTable: "Clases",
                principalColumn: "ClaseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clases_CarreraTecnica_CarreraTecnicaId",
                table: "Clases",
                column: "CarreraTecnicaId",
                principalTable: "CarreraTecnica",
                principalColumn: "CarreraTecnicaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clases_Horarios_HorarioID",
                table: "Clases",
                column: "HorarioID",
                principalTable: "Horarios",
                principalColumn: "HorarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clases_Instructores_InstructorId",
                table: "Clases",
                column: "InstructorId",
                principalTable: "Instructores",
                principalColumn: "InstructorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clases_Salones_SalonID",
                table: "Clases",
                column: "SalonID",
                principalTable: "Salones",
                principalColumn: "SalonId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AsignacionAlumnos_Clases_ClaseId",
                table: "AsignacionAlumnos");

            migrationBuilder.DropForeignKey(
                name: "FK_Clases_CarreraTecnica_CarreraTecnicaId",
                table: "Clases");

            migrationBuilder.DropForeignKey(
                name: "FK_Clases_Horarios_HorarioID",
                table: "Clases");

            migrationBuilder.DropForeignKey(
                name: "FK_Clases_Instructores_InstructorId",
                table: "Clases");

            migrationBuilder.DropForeignKey(
                name: "FK_Clases_Salones_SalonID",
                table: "Clases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clases",
                table: "Clases");

            migrationBuilder.RenameTable(
                name: "Clases",
                newName: "Clase");

            migrationBuilder.RenameIndex(
                name: "IX_Clases_SalonID",
                table: "Clase",
                newName: "IX_Clase_SalonID");

            migrationBuilder.RenameIndex(
                name: "IX_Clases_InstructorId",
                table: "Clase",
                newName: "IX_Clase_InstructorId");

            migrationBuilder.RenameIndex(
                name: "IX_Clases_HorarioID",
                table: "Clase",
                newName: "IX_Clase_HorarioID");

            migrationBuilder.RenameIndex(
                name: "IX_Clases_CarreraTecnicaId",
                table: "Clase",
                newName: "IX_Clase_CarreraTecnicaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clase",
                table: "Clase",
                column: "ClaseID");

            migrationBuilder.AddForeignKey(
                name: "FK_AsignacionAlumnos_Clase_ClaseId",
                table: "AsignacionAlumnos",
                column: "ClaseId",
                principalTable: "Clase",
                principalColumn: "ClaseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clase_CarreraTecnica_CarreraTecnicaId",
                table: "Clase",
                column: "CarreraTecnicaId",
                principalTable: "CarreraTecnica",
                principalColumn: "CarreraTecnicaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clase_Horarios_HorarioID",
                table: "Clase",
                column: "HorarioID",
                principalTable: "Horarios",
                principalColumn: "HorarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clase_Instructores_InstructorId",
                table: "Clase",
                column: "InstructorId",
                principalTable: "Instructores",
                principalColumn: "InstructorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clase_Salones_SalonID",
                table: "Clase",
                column: "SalonID",
                principalTable: "Salones",
                principalColumn: "SalonId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
