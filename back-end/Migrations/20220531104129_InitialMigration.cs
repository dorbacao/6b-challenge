using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SixB_Api.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Login", "Name", "Password" },
                values: new object[,]
                {
                    { new Guid("0a41a6ab-fd98-44cf-ab03-f64bf55b100a"), "angelo@6bdigital.com", "Angelo", "$2a$11$GO38rMrQhRQM0czSRZm2Oe.7J2JWe75a9.iuDiinGuWdaECA1G1Wy" },
                    { new Guid("1a40a6ed-fd98-44cf-ab03-f64bf55b100a"), "jack@javeloper.co.uk", "Jack", "$2a$11$GO38rMrQhRQM0czSRZm2Oe.7J2JWe75a9.iuDiinGuWdaECA1G1Wy" },
                    { new Guid("1a60a6ed-fd98-44cf-ab03-f64bf55b210a"), "fabricedomingues7@gmail.com", "Fabrice Domingues", "$2a$11$GO38rMrQhRQM0czSRZm2Oe.7J2JWe75a9.iuDiinGuWdaECA1G1Wy" },
                    { new Guid("1b41a6ed-fd98-44cf-ab03-f64bf55b100a"), "josh@joshwalshaw.com", "Josh", "$2a$11$GO38rMrQhRQM0czSRZm2Oe.7J2JWe75a9.iuDiinGuWdaECA1G1Wy" },
                    { new Guid("4e60a6ed-fd98-44cf-ab03-f64bf55b210a"), "marcus.carreira@gmail.com", "Marcus Vinícius Carreira Dorbação", "$2a$11$GO38rMrQhRQM0czSRZm2Oe.7J2JWe75a9.iuDiinGuWdaECA1G1Wy" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
