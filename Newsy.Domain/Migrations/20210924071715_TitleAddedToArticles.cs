using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Newsy.Domain.Migrations
{
    public partial class TitleAddedToArticles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Articles",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Articles");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2de02010-b551-4362-adb3-a5bbcf25eebb"),
                column: "ConcurrencyStamp",
                value: "578ced65-9325-48da-ac5b-2f778e762dd0");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("49ec873f-76a1-4ba4-87cd-63ba1316438f"),
                column: "ConcurrencyStamp",
                value: "f4d67acb-475f-44b8-85a9-3d0492b80f00");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d83b41a7-1f4a-47ac-9834-ad18473c872a"),
                column: "ConcurrencyStamp",
                value: "14e288ec-1635-4d82-90ab-a8cce418ecdb");
        }
    }
}
