﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace TheKaleCartelWebApi.Migrations
{
    public partial class AddedNicknameToProfiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nickname",
                table: "KaleProfiles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nickname",
                table: "KaleProfiles");
        }
    }
}
