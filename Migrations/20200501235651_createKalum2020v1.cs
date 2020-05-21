using Microsoft.EntityFrameworkCore.Migrations;

namespace Kalum2020v1.Migrations
{
    public partial class createKalum2020v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clases_CarreraTecnica_CarreraTecnicaId",
                table: "Clases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarreraTecnica",
                table: "CarreraTecnica");

            migrationBuilder.RenameTable(
                name: "CarreraTecnica",
                newName: "CarreraTecnicas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarreraTecnicas",
                table: "CarreraTecnicas",
                column: "CarreraTecnicaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clases_CarreraTecnicas_CarreraTecnicaId",
                table: "Clases",
                column: "CarreraTecnicaId",
                principalTable: "CarreraTecnicas",
                principalColumn: "CarreraTecnicaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clases_CarreraTecnicas_CarreraTecnicaId",
                table: "Clases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarreraTecnicas",
                table: "CarreraTecnicas");

            migrationBuilder.RenameTable(
                name: "CarreraTecnicas",
                newName: "CarreraTecnica");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarreraTecnica",
                table: "CarreraTecnica",
                column: "CarreraTecnicaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clases_CarreraTecnica_CarreraTecnicaId",
                table: "Clases",
                column: "CarreraTecnicaId",
                principalTable: "CarreraTecnica",
                principalColumn: "CarreraTecnicaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
