using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS_Backend.Migrations
{
    /// <inheritdoc />
    public partial class datatype_change_approvedAt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovedAt",
                table: "ReturnRequests");

            migrationBuilder.DropColumn(
                name: "RequestedAt",
                table: "ReturnRequests");

            migrationBuilder.AddColumn<DateOnly>(
                name: "ApprovedDate",
                table: "ReturnRequests",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "RequestedDate",
                table: "ReturnRequests",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovedDate",
                table: "ReturnRequests");

            migrationBuilder.DropColumn(
                name: "RequestedDate",
                table: "ReturnRequests");

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedAt",
                table: "ReturnRequests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RequestedAt",
                table: "ReturnRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 9, 28, 1, 747, DateTimeKind.Utc).AddTicks(3061));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 9, 28, 1, 747, DateTimeKind.Utc).AddTicks(3063));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 9, 28, 1, 747, DateTimeKind.Utc).AddTicks(3065));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 9, 28, 1, 747, DateTimeKind.Utc).AddTicks(3067));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 9, 28, 1, 747, DateTimeKind.Utc).AddTicks(3068));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 9, 28, 1, 747, DateTimeKind.Utc).AddTicks(3070));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 9, 28, 1, 747, DateTimeKind.Utc).AddTicks(3071));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 9, 28, 1, 747, DateTimeKind.Utc).AddTicks(3260));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 9, 28, 1, 747, DateTimeKind.Utc).AddTicks(3261));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 9, 28, 1, 747, DateTimeKind.Utc).AddTicks(3263));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 9, 28, 1, 747, DateTimeKind.Utc).AddTicks(3264));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 9, 28, 1, 747, DateTimeKind.Utc).AddTicks(2778));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 9, 28, 1, 747, DateTimeKind.Utc).AddTicks(2781));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 9, 28, 1, 747, DateTimeKind.Utc).AddTicks(2783));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "ConfigId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 9, 28, 1, 747, DateTimeKind.Utc).AddTicks(3325));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "ConfigId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 9, 28, 1, 747, DateTimeKind.Utc).AddTicks(3327));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "ConfigId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 9, 28, 1, 747, DateTimeKind.Utc).AddTicks(3329));
        }
    }
}
