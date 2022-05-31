using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SixB_Api.Migrations
{
    public partial class V001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Flexibility = table.Column<int>(type: "int", nullable: false),
                    VehicleSize = table.Column<int>(type: "int", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Approved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Booking",
                columns: new[] { "Id", "Approved", "BookingDate", "ContactNumber", "CreatedOn", "EmailAddress", "Flexibility", "VehicleSize" },
                values: new object[,]
                {
                    { new Guid("0ac2a6ed-ab12-44cf-ab03-f64bf55b100b"), false, new DateTime(2022, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "913336296", new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "angelo@6bdigital.com", 2, 1 },
                    { new Guid("0ac2a6ed-fd98-44cf-ab03-f64bf55b100b"), false, new DateTime(2022, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "913336296", new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "josh@joshwalshaw.com", 3, 3 },
                    { new Guid("1a21a6ed-fd98-44cf-ab03-f64bf55b100a"), false, new DateTime(2022, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "913336296", new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "marcus.carreira@gmail.com", 1, 1 },
                    { new Guid("1a44a6ed-fd98-44cf-ab03-f64bf55b100b"), false, new DateTime(2022, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "913336296", new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "jack@javeloper.co.uk", 1, 1 },
                    { new Guid("1c11a6ed-fd98-44cf-ab03-f64bf55b100b"), false, new DateTime(2022, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "913336296", new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "fabricedomingues7@gmail.com", 1, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");
        }
    }
}
