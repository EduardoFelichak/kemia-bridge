using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KemiaBridge.Infra.Data.Migrations
{
    public partial class AddIconPropertyInStep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "step",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                table: "step");
        }
    }
}
