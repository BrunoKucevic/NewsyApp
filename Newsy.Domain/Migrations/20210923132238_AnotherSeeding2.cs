using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Newsy.Domain.Migrations
{
    public partial class AnotherSeeding2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 1, "Admin", "true", new Guid("1e969ee3-395c-4d71-8100-a1dd955431e7") },
                    { 2, "Author", "true", new Guid("8c037fe7-7633-4e2f-b3e0-00a313e7d2e1") }
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2de02010-b551-4362-adb3-a5bbcf25eebb"),
                column: "ConcurrencyStamp",
                value: "39b1dadf-e716-4ba3-83c7-37f05edf4062");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("49ec873f-76a1-4ba4-87cd-63ba1316438f"),
                column: "ConcurrencyStamp",
                value: "54eaad3f-3e47-48d9-9cca-0778f2137baa");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d83b41a7-1f4a-47ac-9834-ad18473c872a"),
                column: "ConcurrencyStamp",
                value: "81eaba8e-d664-4f75-9ccf-ee7d2ea93cfc");
        }
    }
}
