using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KemiaBridge.Infra.Data.Migrations
{
    public partial class CreateBlower : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "blower",
                columns: table => new
                {
                    BlowerId = table.Column<int>(type: "integer", nullable: false),
                    Tag = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    StepId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blower", x => x.BlowerId);
                    table.ForeignKey(
                        name: "FK_blower_step_BlowerId",
                        column: x => x.BlowerId,
                        principalTable: "step",
                        principalColumn: "StepId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "blower");
        }
    }
}
