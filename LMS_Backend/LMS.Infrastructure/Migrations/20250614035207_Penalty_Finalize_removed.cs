using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS_Backend.Migrations
{
    /// <inheritdoc />
    public partial class Penalty_Finalize_removed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PenaltyFinlized",
                table: "ReturnRequests");

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 14, 3, 52, 6, 207, DateTimeKind.Utc).AddTicks(5411));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 14, 3, 52, 6, 207, DateTimeKind.Utc).AddTicks(5413));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 14, 3, 52, 6, 207, DateTimeKind.Utc).AddTicks(5415));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 14, 3, 52, 6, 207, DateTimeKind.Utc).AddTicks(5417));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 14, 3, 52, 6, 207, DateTimeKind.Utc).AddTicks(5418));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 14, 3, 52, 6, 207, DateTimeKind.Utc).AddTicks(5420));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 14, 3, 52, 6, 207, DateTimeKind.Utc).AddTicks(5422));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 14, 3, 52, 6, 207, DateTimeKind.Utc).AddTicks(5423));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 14, 3, 52, 6, 207, DateTimeKind.Utc).AddTicks(5425));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 14, 3, 52, 6, 207, DateTimeKind.Utc).AddTicks(5426));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 14, 3, 52, 6, 207, DateTimeKind.Utc).AddTicks(5428));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 14, 3, 52, 6, 207, DateTimeKind.Utc).AddTicks(4968));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 14, 3, 52, 6, 207, DateTimeKind.Utc).AddTicks(4973));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 14, 3, 52, 6, 207, DateTimeKind.Utc).AddTicks(4975));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "ConfigId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 14, 3, 52, 6, 207, DateTimeKind.Utc).AddTicks(5476));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "ConfigId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 14, 3, 52, 6, 207, DateTimeKind.Utc).AddTicks(5478));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "ConfigId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 14, 3, 52, 6, 207, DateTimeKind.Utc).AddTicks(5480));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PenaltyFinlized",
                table: "ReturnRequests",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 9, 56, 36, 324, DateTimeKind.Utc).AddTicks(2088));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 9, 56, 36, 324, DateTimeKind.Utc).AddTicks(2090));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 9, 56, 36, 324, DateTimeKind.Utc).AddTicks(2092));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 9, 56, 36, 324, DateTimeKind.Utc).AddTicks(2093));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 9, 56, 36, 324, DateTimeKind.Utc).AddTicks(2095));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 9, 56, 36, 324, DateTimeKind.Utc).AddTicks(2097));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 9, 56, 36, 324, DateTimeKind.Utc).AddTicks(2098));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 9, 56, 36, 324, DateTimeKind.Utc).AddTicks(2100));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 9, 56, 36, 324, DateTimeKind.Utc).AddTicks(2101));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 9, 56, 36, 324, DateTimeKind.Utc).AddTicks(2103));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 9, 56, 36, 324, DateTimeKind.Utc).AddTicks(2104));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 9, 56, 36, 324, DateTimeKind.Utc).AddTicks(1806));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 9, 56, 36, 324, DateTimeKind.Utc).AddTicks(1810));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 9, 56, 36, 324, DateTimeKind.Utc).AddTicks(1812));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "ConfigId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 9, 56, 36, 324, DateTimeKind.Utc).AddTicks(2149));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "ConfigId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 9, 56, 36, 324, DateTimeKind.Utc).AddTicks(2151));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "ConfigId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 9, 56, 36, 324, DateTimeKind.Utc).AddTicks(2153));
        }
    }
}
