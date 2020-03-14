using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyBooking.Presistence.Migrations
{
    public partial class UserRolesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetRoleClaims");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUserRoles",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUserRoles",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "AspNetUserRoles",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUserRoles",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUserRoles",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "AspNetUserRoles",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUserRoles",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetRoleClaims",
                nullable: false,
                defaultValue: "");
        }
    }
}
