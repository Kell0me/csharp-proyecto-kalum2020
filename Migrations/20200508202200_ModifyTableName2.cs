using Microsoft.EntityFrameworkCore.Migrations;

namespace Kalum2020v1.Migrations
{
    public partial class ModifyTableName2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alumnos_Religion_ReligionId",
                table: "Alumnos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Religion",
                table: "Religion");

            migrationBuilder.RenameTable(
                name: "Religion",
                newName: "Religiones");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Religiones",
                table: "Religiones",
                column: "ReligionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alumnos_Religiones_ReligionId",
                table: "Alumnos",
                column: "ReligionId",
                principalTable: "Religiones",
                principalColumn: "ReligionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alumnos_Religiones_ReligionId",
                table: "Alumnos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Religiones",
                table: "Religiones");

            migrationBuilder.RenameTable(
                name: "Religiones",
                newName: "Religion");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Religion",
                table: "Religion",
                column: "ReligionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alumnos_Religion_ReligionId",
                table: "Alumnos",
                column: "ReligionId",
                principalTable: "Religion",
                principalColumn: "ReligionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
