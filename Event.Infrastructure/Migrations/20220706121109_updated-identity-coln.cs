using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Event.Infrastructure.Migrations
{
    public partial class updatedidentitycoln : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "eventparticipationseq",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "eventseq",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EndTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    TotalCapacity = table.Column<int>(type: "int", nullable: false),
                    IsOnlineEvent = table.Column<bool>(type: "bit", maxLength: 10000, nullable: false),
                    OnlineEventUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoOfPeopleGoing = table.Column<int>(type: "int", maxLength: 1000, nullable: false),
                    IsCancelled = table.Column<bool>(type: "bit", nullable: false),
                    ThumbnailImagePath = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Location_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location_Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location_ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location_Latitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Location_Longitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    ModifiedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModifiedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParticipationStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipationStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventParticipants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    ParticipationStatusId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    ModifiedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModifiedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventParticipants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventParticipants_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventParticipants_ParticipationStatus_ParticipationStatusId",
                        column: x => x.ParticipationStatusId,
                        principalTable: "ParticipationStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventParticipants_EventId",
                table: "EventParticipants",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventParticipants_ParticipationStatusId",
                table: "EventParticipants",
                column: "ParticipationStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventParticipants");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "ParticipationStatus");

            migrationBuilder.DropSequence(
                name: "eventparticipationseq");

            migrationBuilder.DropSequence(
                name: "eventseq");
        }
    }
}
