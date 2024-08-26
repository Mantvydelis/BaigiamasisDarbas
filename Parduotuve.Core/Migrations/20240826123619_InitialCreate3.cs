﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parduotuve.Core.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipas",
                table: "Pirkejai");

            migrationBuilder.DropColumn(
                name: "Tipas",
                table: "Pardavejai");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tipas",
                table: "Pirkejai",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tipas",
                table: "Pardavejai",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}