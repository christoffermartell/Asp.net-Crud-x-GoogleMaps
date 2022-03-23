using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_Exercise___Consid.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    OrganizationNumber = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(512)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(512)", nullable: false),
                    Zip = table.Column<string>(type: "nvarchar(16)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    Latitude = table.Column<string>(type: "nvarchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stores_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Name", "Notes", "OrganizationNumber" },
                values: new object[] { new Guid("5989a286-ca8d-48a9-b1d5-d438a6862545"), "Ikea Company", "Ikea Group, av företaget skrivet IKEA Group, är ett multinationellt möbelföretag, som grundades i Sverige år 1943 av Ingvar Kamprad som ett postorderföretag. Företaget ägs av en stiftelse i Nederländerna, men styrs alltjämt av familjen Kamprad.", 111111332 });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Name", "Notes", "OrganizationNumber" },
                values: new object[] { new Guid("faa9e28f-ad20-498e-9da0-3e56da749c4d"), "Apple Company", "Apple Inc. är ett amerikanskt dator - och hemelektronikföretag grundat 1976 av Steve Jobs, Steve Wozniak och Ronald Wayne. Företaget har cirka 147 000 anställda och omsatte 2020 nästan 274.52 miljarder amerikanska dollar.", 123321456 });

            migrationBuilder.CreateIndex(
                name: "IX_Stores_CompanyId",
                table: "Stores",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
