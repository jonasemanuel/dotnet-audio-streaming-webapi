﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AudioStreaming.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Ispublic_Playlist_Column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "Playlist",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "Playlist");
        }
    }
}
