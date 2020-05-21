using Microsoft.EntityFrameworkCore.Migrations;

namespace Kalum2020v1.Migrations
{
    public partial class CreateKalumReligion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReligionId",
                table: "Alumnos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Religion",
                columns: table => new
                {
                    ReligionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Religion", x => x.ReligionId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alumnos_ReligionId",
                table: "Alumnos",
                column: "ReligionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alumnos_Religion_ReligionId",
                table: "Alumnos",
                column: "ReligionId",
                principalTable: "Religion",
                principalColumn: "ReligionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alumnos_Religion_ReligionId",
                table: "Alumnos");

            migrationBuilder.DropTable(
                name: "Religion");

            migrationBuilder.DropIndex(
                name: "IX_Alumnos_ReligionId",
                table: "Alumnos");

            migrationBuilder.DropColumn(
                name: "ReligionId",
                table: "Alumnos");
        }
    }
}
