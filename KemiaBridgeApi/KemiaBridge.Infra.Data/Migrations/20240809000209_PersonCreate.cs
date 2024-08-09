using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace KemiaBridge.Infra.Data.Migrations
{
    public partial class PersonCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "person",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    AddressId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_person_address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "legal_person",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "integer", nullable: false),
                    FederalRegister = table.Column<string>(type: "character varying(18)", maxLength: 18, nullable: false),
                    CorporateReason = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_legal_person", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_legal_person_person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "physic_person",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "integer", nullable: false),
                    RegisterCode = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    SocialName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    BornAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_physic_person", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_physic_person_person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_person_AddressId",
                table: "person",
                column: "AddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "legal_person");

            migrationBuilder.DropTable(
                name: "physic_person");

            migrationBuilder.DropTable(
                name: "person");
        }
    }
}
