using Microsoft.EntityFrameworkCore.Migrations;

namespace TestTemp1.Migrations
{
    public partial class AddPBWGagingStToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PBWGagingSt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CellTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SandBlasting = table.Column<int>(type: "int", nullable: false),
                    GageApplying = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PBWGagingSt", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PBWGagingSt");
        }
    }
}
