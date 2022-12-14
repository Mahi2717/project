using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Airticket.Migrations
{
    public partial class FirstMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdminId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "Contactus",
                columns: table => new
                {
                    Cid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contactus", x => x.Cid);
                });

            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fname = table.Column<string>(nullable: true),
                    Fsource = table.Column<string>(nullable: true),
                    Fdestination = table.Column<string>(nullable: true),
                    Fdepttime = table.Column<DateTime>(nullable: false),
                    Farrtime = table.Column<DateTime>(nullable: false),
                    Totpass = table.Column<string>(nullable: true),
                    BusinessFare = table.Column<string>(nullable: true),
                    FirstclassFare = table.Column<string>(nullable: true),
                    EconomyFare = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fname = table.Column<string>(nullable: true),
                    Lname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    BookingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    BookingDate = table.Column<DateTime>(nullable: false),
                    PName = table.Column<string>(nullable: true),
                    PAge = table.Column<string>(nullable: true),
                    PGender = table.Column<string>(nullable: true),
                    Source = table.Column<string>(nullable: true),
                    Destination = table.Column<string>(nullable: true),
                    Class = table.Column<string>(nullable: true),
                    Fare = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Booking_Flight_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flight",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_FlightId",
                table: "Booking",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_UserId",
                table: "Booking",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Contactus");

            migrationBuilder.DropTable(
                name: "Flight");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
