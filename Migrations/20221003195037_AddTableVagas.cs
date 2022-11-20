using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpregaSENAI.Migrations
{
    public partial class AddTableVagas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vaga",
                schema: "Identity",
                columns: table => new
                {                  

                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Setor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Requisitos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Infos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaga", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "Vaga",
               schema: "Identity");
        }
    }
}
