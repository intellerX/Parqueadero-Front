﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ADN.Infrastructure.Migrations
{
    public partial class FiveMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                schema: "mySchema",
                table: "Vehicle",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                schema: "mySchema",
                table: "Vehicle");
        }
    }
}
