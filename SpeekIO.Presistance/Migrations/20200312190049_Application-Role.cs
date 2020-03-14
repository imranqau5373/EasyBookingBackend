using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyBooking.Presistence.Migrations
{
    public partial class ApplicationRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "AspNetUserRoles",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUserRoles",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUserRoles",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ModifiedBy",
                table: "AspNetUserRoles",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "AspNetUserRoles",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RoleId1",
                table: "AspNetUserRoles",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserId1",
                table: "AspNetUserRoles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUserRoles",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "AspNetRoles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "RoleId1",
                table: "AspNetRoleClaims",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetRoleClaims",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId1",
                table: "AspNetUserRoles",
                column: "RoleId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId1",
                table: "AspNetUserRoles",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId1",
                table: "AspNetRoleClaims",
                column: "RoleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId1",
                table: "AspNetRoleClaims",
                column: "RoleId1",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId1",
                table: "AspNetUserRoles",
                column: "RoleId1",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_ApplicationUser_UserId1",
                table: "AspNetUserRoles",
                column: "UserId1",
                principalSchema: "User",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId1",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId1",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_ApplicationUser_UserId1",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_RoleId1",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId1",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoleClaims_RoleId1",
                table: "AspNetRoleClaims");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "RoleId1",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "RoleId1",
                table: "AspNetRoleClaims");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetRoleClaims");
        }
    }
}
