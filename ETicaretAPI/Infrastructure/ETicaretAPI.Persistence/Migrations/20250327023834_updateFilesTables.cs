﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETicaretAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updateFilesTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StorageName",
                table: "Files",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StorageName",
                table: "Files");
        }
    }
}
