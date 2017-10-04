using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockVisionConsole.Migrations
{
    public partial class CreatenewComany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Countries_CountriesId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Companies");

            migrationBuilder.AlterColumn<int>(
                name: "CountriesId",
                table: "Companies",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Companies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Companies",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Countries_CountriesId",
                table: "Companies",
                column: "CountriesId",
                principalTable: "Countries",
                principalColumn: "CountriesId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Countries_CountriesId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Companies");

            migrationBuilder.AlterColumn<int>(
                name: "CountriesId",
                table: "Companies",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Companies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Countries_CountriesId",
                table: "Companies",
                column: "CountriesId",
                principalTable: "Countries",
                principalColumn: "CountriesId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
