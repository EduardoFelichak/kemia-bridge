﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace KemiaBridge.Infra.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ZipCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Street = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Complement = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Neighborhood = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    State = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.UserId);
                });

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
                name: "station",
                columns: table => new
                {
                    StationId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    OperationDate = table.Column<DateOnly>(type: "date", nullable: false),
                    AddressId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_station", x => x.StationId);
                    table.ForeignKey(
                        name: "FK_station_address_AddressId",
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

            migrationBuilder.CreateTable(
                name: "activity",
                columns: table => new
                {
                    ActivityId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    LimitDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    StationId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_activity", x => x.ActivityId);
                    table.ForeignKey(
                        name: "FK_activity_station_StationId",
                        column: x => x.StationId,
                        principalTable: "station",
                        principalColumn: "StationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_activity_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "person_station",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "integer", nullable: false),
                    StationId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person_station", x => new { x.PersonId, x.StationId });
                    table.ForeignKey(
                        name: "FK_person_station_person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_person_station_station_StationId",
                        column: x => x.StationId,
                        principalTable: "station",
                        principalColumn: "StationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "step",
                columns: table => new
                {
                    StepId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Icon = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    StationId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_step", x => x.StepId);
                    table.ForeignKey(
                        name: "FK_step_station_StationId",
                        column: x => x.StationId,
                        principalTable: "station",
                        principalColumn: "StationId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "sensor",
                columns: table => new
                {
                    SensorId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Tag = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    StepId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sensor", x => x.SensorId);
                    table.ForeignKey(
                        name: "FK_sensor_step_StepId",
                        column: x => x.StepId,
                        principalTable: "step",
                        principalColumn: "StepId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "squeezer",
                columns: table => new
                {
                    SqueezerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tag = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    StepId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_squeezer", x => x.SqueezerId);
                    table.ForeignKey(
                        name: "FK_squeezer_step_StepId",
                        column: x => x.StepId,
                        principalTable: "step",
                        principalColumn: "StepId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tank",
                columns: table => new
                {
                    TankId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Tag = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    StepId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tank", x => x.TankId);
                    table.ForeignKey(
                        name: "FK_tank_step_StepId",
                        column: x => x.StepId,
                        principalTable: "step",
                        principalColumn: "StepId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sensor_reading",
                columns: table => new
                {
                    SensorReadingId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReadingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Data = table.Column<double>(type: "double precision", nullable: false),
                    SensorId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sensor_reading", x => x.SensorReadingId);
                    table.ForeignKey(
                        name: "FK_sensor_reading_sensor_SensorId",
                        column: x => x.SensorId,
                        principalTable: "sensor",
                        principalColumn: "SensorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sensor_reading_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_activity_StationId",
                table: "activity",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_activity_UserId",
                table: "activity",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_person_AddressId",
                table: "person",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_person_station_StationId",
                table: "person_station",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_sensor_StepId",
                table: "sensor",
                column: "StepId");

            migrationBuilder.CreateIndex(
                name: "IX_sensor_reading_SensorId",
                table: "sensor_reading",
                column: "SensorId");

            migrationBuilder.CreateIndex(
                name: "IX_sensor_reading_UserId",
                table: "sensor_reading",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_squeezer_StepId",
                table: "squeezer",
                column: "StepId");

            migrationBuilder.CreateIndex(
                name: "IX_station_AddressId",
                table: "station",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_step_StationId",
                table: "step",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_tank_StepId",
                table: "tank",
                column: "StepId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "user",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Name",
                table: "user",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Phone",
                table: "user",
                column: "Phone",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "activity");

            migrationBuilder.DropTable(
                name: "blower");

            migrationBuilder.DropTable(
                name: "legal_person");

            migrationBuilder.DropTable(
                name: "person_station");

            migrationBuilder.DropTable(
                name: "physic_person");

            migrationBuilder.DropTable(
                name: "sensor_reading");

            migrationBuilder.DropTable(
                name: "squeezer");

            migrationBuilder.DropTable(
                name: "tank");

            migrationBuilder.DropTable(
                name: "person");

            migrationBuilder.DropTable(
                name: "sensor");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "step");

            migrationBuilder.DropTable(
                name: "station");

            migrationBuilder.DropTable(
                name: "address");
        }
    }
}
