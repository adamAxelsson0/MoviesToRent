using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FilmStudios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmStudios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    ImageURL = table.Column<string>(nullable: true),
                    Rating = table.Column<double>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Rating = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    MovieId = table.Column<int>(nullable: false),
                    FilmStudioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RentLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MovieId = table.Column<int>(nullable: false),
                    FilmStudioId = table.Column<int>(nullable: false),
                    ExpireDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentLogs_FilmStudios_FilmStudioId",
                        column: x => x.FilmStudioId,
                        principalTable: "FilmStudios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentLogs_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trivias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MovieId = table.Column<int>(nullable: false),
                    FilmStudioId = table.Column<int>(nullable: false),
                    TriviaInfo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trivias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trivias_FilmStudios_FilmStudioId",
                        column: x => x.FilmStudioId,
                        principalTable: "FilmStudios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trivias_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentLogs_FilmStudioId",
                table: "RentLogs",
                column: "FilmStudioId");

            migrationBuilder.CreateIndex(
                name: "IX_RentLogs_MovieId",
                table: "RentLogs",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Trivias_FilmStudioId",
                table: "Trivias",
                column: "FilmStudioId");

            migrationBuilder.CreateIndex(
                name: "IX_Trivias_MovieId",
                table: "Trivias",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentLogs");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Trivias");

            migrationBuilder.DropTable(
                name: "FilmStudios");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
