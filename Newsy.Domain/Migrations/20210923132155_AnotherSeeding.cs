using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Newsy.Domain.Migrations
{
    public partial class AnotherSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_Roles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_Roles_RoleId1",
                table: "AspNetRoleClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoleClaims_RoleId1",
                table: "AspNetRoleClaims");

            migrationBuilder.DropColumn(
                name: "RoleId1",
                table: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "RoleClaims");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "RoleClaims",
                newName: "IX_RoleClaims_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleClaims",
                table: "RoleClaims",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_RoleClaims_Roles_RoleId",
                table: "RoleClaims",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleClaims_Roles_RoleId",
                table: "RoleClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleClaims",
                table: "RoleClaims");

            migrationBuilder.RenameTable(
                name: "RoleClaims",
                newName: "AspNetRoleClaims");

            migrationBuilder.RenameIndex(
                name: "IX_RoleClaims_RoleId",
                table: "AspNetRoleClaims",
                newName: "IX_AspNetRoleClaims_RoleId");

            migrationBuilder.AddColumn<Guid>(
                name: "RoleId1",
                table: "AspNetRoleClaims",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2de02010-b551-4362-adb3-a5bbcf25eebb"),
                column: "ConcurrencyStamp",
                value: "a083ed53-2fbe-4189-ab49-845097981b07");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("49ec873f-76a1-4ba4-87cd-63ba1316438f"),
                column: "ConcurrencyStamp",
                value: "683b5d1a-5646-430c-9e2f-3db999d65d77");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d83b41a7-1f4a-47ac-9834-ad18473c872a"),
                column: "ConcurrencyStamp",
                value: "36eeca89-6c15-420c-b099-91449069b0d5");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId1",
                table: "AspNetRoleClaims",
                column: "RoleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_Roles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_Roles_RoleId1",
                table: "AspNetRoleClaims",
                column: "RoleId1",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
