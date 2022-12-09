using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpregaSENAI.Migrations
{
    public partial class caralho : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                schema: "Identity",
                table: "Vaga",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserNome",
                schema: "Identity",
                table: "Vaga",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserEmail",
                schema: "Identity",
                table: "Vaga");

            migrationBuilder.DropColumn(
                name: "UserNome",
                schema: "Identity",
                table: "Vaga");
        }
    }
}
