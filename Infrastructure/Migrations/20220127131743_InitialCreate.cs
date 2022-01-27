using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Popularity = table.Column<double>(nullable: false),
                    Vote_Average = table.Column<double>(nullable: false),
                    Adult = table.Column<bool>(nullable: false),
                    Video = table.Column<bool>(nullable: false),
                    Orginal_Title = table.Column<string>(nullable: true),
                    Release_Date = table.Column<DateTime>(nullable: true),
                    Original_Language = table.Column<string>(nullable: true),
                    Overview = table.Column<string>(nullable: true),
                    Poster_Path = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
