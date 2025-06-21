using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS_Backend.Migrations
{
    /// <inheritdoc />
    public partial class Request_Status_Change : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "SystemConfigs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 8, 37, 18, 181, DateTimeKind.Utc).AddTicks(9810));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 8, 37, 18, 181, DateTimeKind.Utc).AddTicks(9814));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 8, 37, 18, 181, DateTimeKind.Utc).AddTicks(9816));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 8, 37, 18, 181, DateTimeKind.Utc).AddTicks(9818));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 8, 37, 18, 181, DateTimeKind.Utc).AddTicks(9820));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 8, 37, 18, 181, DateTimeKind.Utc).AddTicks(9825));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 8, 37, 18, 181, DateTimeKind.Utc).AddTicks(9963));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 8, 37, 18, 181, DateTimeKind.Utc).AddTicks(9966));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 8, 37, 18, 181, DateTimeKind.Utc).AddTicks(9969));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 8, 37, 18, 181, DateTimeKind.Utc).AddTicks(9971));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 8, 37, 18, 181, DateTimeKind.Utc).AddTicks(9973));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 8, 37, 18, 181, DateTimeKind.Utc).AddTicks(9295));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 8, 37, 18, 181, DateTimeKind.Utc).AddTicks(9301));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 8, 37, 18, 181, DateTimeKind.Utc).AddTicks(9306));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "ConfigId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 8, 37, 18, 182, DateTimeKind.Utc).AddTicks(99));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "ConfigId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 8, 37, 18, 182, DateTimeKind.Utc).AddTicks(105));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "ConfigId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 8, 37, 18, 182, DateTimeKind.Utc).AddTicks(110));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "SystemConfigs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 12, 8, 40, 18, 279, DateTimeKind.Utc).AddTicks(5987));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 12, 8, 40, 18, 279, DateTimeKind.Utc).AddTicks(5990));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 12, 8, 40, 18, 279, DateTimeKind.Utc).AddTicks(5992));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 12, 8, 40, 18, 279, DateTimeKind.Utc).AddTicks(5994));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 12, 8, 40, 18, 279, DateTimeKind.Utc).AddTicks(5996));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 12, 8, 40, 18, 279, DateTimeKind.Utc).AddTicks(5998));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 12, 8, 40, 18, 279, DateTimeKind.Utc).AddTicks(5999));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 12, 8, 40, 18, 279, DateTimeKind.Utc).AddTicks(6001));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 12, 8, 40, 18, 279, DateTimeKind.Utc).AddTicks(6005));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 12, 8, 40, 18, 279, DateTimeKind.Utc).AddTicks(6007));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 12, 8, 40, 18, 279, DateTimeKind.Utc).AddTicks(6009));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 12, 8, 40, 18, 279, DateTimeKind.Utc).AddTicks(5348));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 12, 8, 40, 18, 279, DateTimeKind.Utc).AddTicks(5352));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 12, 8, 40, 18, 279, DateTimeKind.Utc).AddTicks(5354));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "ConfigId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 12, 8, 40, 18, 279, DateTimeKind.Utc).AddTicks(6091));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "ConfigId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 12, 8, 40, 18, 279, DateTimeKind.Utc).AddTicks(6094));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "ConfigId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 12, 8, 40, 18, 279, DateTimeKind.Utc).AddTicks(6096));
        }
    }
}
