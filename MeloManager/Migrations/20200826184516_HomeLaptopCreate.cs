using Microsoft.EntityFrameworkCore.Migrations;

namespace MeloManager.Migrations
{
    public partial class HomeLaptopCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Department = table.Column<int>(nullable: false),
                    PhotoPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Department", "Email", "Name", "PhotoPath" },
                values: new object[,]
                {
                    { 1, 3, "32L@YJO0.com", "VWLCN", null },
                    { 2, 3, "OSG@OO7B.com", "ARYRY", null },
                    { 3, 3, "UJC@XUV2.com", "ZTV9F", null },
                    { 4, 3, "U83@EU7V.com", "48Z8J", null },
                    { 5, 3, "YVG@YKM4.com", "N7COT", null },
                    { 6, 3, "LCP@65X0.com", "H3GD9", null },
                    { 7, 3, "E6F@W9VH.com", "ZT73Q", null },
                    { 8, 3, "ODT@V50P.com", "S4T98", null },
                    { 9, 3, "RZR@KLZ9.com", "N433R", null },
                    { 10, 3, "GHH@I9UE.com", "110UN", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
