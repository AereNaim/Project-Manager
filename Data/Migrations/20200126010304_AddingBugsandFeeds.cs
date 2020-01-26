using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace P1.Data.Migrations
{
    public partial class AddingBugsandFeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bug",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Priority = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Project = table.Column<string>(nullable: true),
                    SubmiteDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    User = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bug", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Author = table.Column<int>(nullable: false),
                    Category = table.Column<string>(nullable: true),
                    Project = table.Column<string>(nullable: true),
                    SubmiteDate = table.Column<DateTime>(nullable: false),
                    User = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bug");

            migrationBuilder.DropTable(
                name: "Feedback");
        }
    }
}
