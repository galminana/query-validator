using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TableRelations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentTable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentTableColumn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChildTable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChildTableColumn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableRelations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TableRelations");
        }
    }
}
