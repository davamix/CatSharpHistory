using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CatSharp.Data.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cats",
                columns: table => new
                {
                    CatId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cats", x => x.CatId);
                });

            migrationBuilder.CreateTable(
                name: "weights",
                columns: table => new
                {
                    WeightId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(nullable: false),
                    Grams = table.Column<int>(nullable: false),
                    CatId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_weights", x => x.WeightId);
                    table.ForeignKey(
                        name: "FK_weights_cats_CatId",
                        column: x => x.CatId,
                        principalTable: "cats",
                        principalColumn: "CatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_weights_CatId",
                table: "weights",
                column: "CatId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "weights");

            migrationBuilder.DropTable(
                name: "cats");
        }
    }
}
