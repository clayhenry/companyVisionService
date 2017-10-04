using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StockVisionConsole.Migrations
{
    public partial class newcompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Countries_CountriesId",
                table: "Companies");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Companies_CountriesId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CountriesId",
                table: "Companies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountriesId",
                table: "Companies",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountriesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountriesId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CountriesId",
                table: "Companies",
                column: "CountriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Countries_CountriesId",
                table: "Companies",
                column: "CountriesId",
                principalTable: "Countries",
                principalColumn: "CountriesId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
