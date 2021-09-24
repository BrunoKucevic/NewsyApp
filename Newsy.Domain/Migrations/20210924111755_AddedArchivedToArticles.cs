using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Newsy.Domain.Migrations
{
    public partial class AddedArchivedToArticles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Archived",
                table: "Articles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2de02010-b551-4362-adb3-a5bbcf25eebb"),
                column: "ConcurrencyStamp",
                value: "523b9042-85ad-4ef6-b4cb-f1c98e4b700c");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("49ec873f-76a1-4ba4-87cd-63ba1316438f"),
                column: "ConcurrencyStamp",
                value: "06768c0b-b664-4d05-8aba-530b279127c1");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d83b41a7-1f4a-47ac-9834-ad18473c872a"),
                column: "ConcurrencyStamp",
                value: "204eef6f-5b21-4e80-aacf-18365ea621f6");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Archived",
                table: "Articles");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2de02010-b551-4362-adb3-a5bbcf25eebb"),
                column: "ConcurrencyStamp",
                value: "b65744d0-393b-4981-abac-47c7af64ec76");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("49ec873f-76a1-4ba4-87cd-63ba1316438f"),
                column: "ConcurrencyStamp",
                value: "0b914f14-3b60-4b30-92bb-70966b2c5a63");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d83b41a7-1f4a-47ac-9834-ad18473c872a"),
                column: "ConcurrencyStamp",
                value: "8cdcc3f4-7f75-4d47-8eee-77c2204036fb");
        }
    }
}
