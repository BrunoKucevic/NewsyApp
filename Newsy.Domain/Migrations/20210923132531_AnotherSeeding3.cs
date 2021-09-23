using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Newsy.Domain.Migrations
{
    public partial class AnotherSeeding3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "RoleId",
                value: new Guid("d83b41a7-1f4a-47ac-9834-ad18473c872a"));

            migrationBuilder.UpdateData(
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 2,
                column: "RoleId",
                value: new Guid("49ec873f-76a1-4ba4-87cd-63ba1316438f"));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2de02010-b551-4362-adb3-a5bbcf25eebb"),
                column: "ConcurrencyStamp",
                value: "c47293e9-d09a-43c4-9f2a-0b9255c25acf");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("49ec873f-76a1-4ba4-87cd-63ba1316438f"),
                column: "ConcurrencyStamp",
                value: "394b9a8e-363f-4179-b101-9adfe841f67a");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d83b41a7-1f4a-47ac-9834-ad18473c872a"),
                column: "ConcurrencyStamp",
                value: "3654a52d-780d-40b0-81b5-78bf3cfe6483");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "RoleId",
                value: new Guid("1e969ee3-395c-4d71-8100-a1dd955431e7"));

            migrationBuilder.UpdateData(
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 2,
                column: "RoleId",
                value: new Guid("8c037fe7-7633-4e2f-b3e0-00a313e7d2e1"));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2de02010-b551-4362-adb3-a5bbcf25eebb"),
                column: "ConcurrencyStamp",
                value: "427a8c31-7ca0-4b2c-9dd9-01bead65c62a");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("49ec873f-76a1-4ba4-87cd-63ba1316438f"),
                column: "ConcurrencyStamp",
                value: "8f2c1754-ce64-4ad9-a1bd-c687c458a6b4");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d83b41a7-1f4a-47ac-9834-ad18473c872a"),
                column: "ConcurrencyStamp",
                value: "e86c8756-3015-48e9-9cd0-73d4d15b2273");
        }
    }
}
