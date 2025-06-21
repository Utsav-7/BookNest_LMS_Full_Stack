using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS_Backend.Migrations
{
    /// <inheritdoc />
    public partial class is_deleted_added_default_transaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ReturnRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "BorrowRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ReturnRequests");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "BorrowRequests");

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 9, 26, 26, 603, DateTimeKind.Utc).AddTicks(7746));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 9, 26, 26, 603, DateTimeKind.Utc).AddTicks(7748));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 9, 26, 26, 603, DateTimeKind.Utc).AddTicks(7750));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 9, 26, 26, 603, DateTimeKind.Utc).AddTicks(7829));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 9, 26, 26, 603, DateTimeKind.Utc).AddTicks(7831));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 9, 26, 26, 603, DateTimeKind.Utc).AddTicks(7832));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 9, 26, 26, 603, DateTimeKind.Utc).AddTicks(7834));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 9, 26, 26, 603, DateTimeKind.Utc).AddTicks(7835));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 9, 26, 26, 603, DateTimeKind.Utc).AddTicks(7837));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 9, 26, 26, 603, DateTimeKind.Utc).AddTicks(7838));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 9, 26, 26, 603, DateTimeKind.Utc).AddTicks(7840));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 9, 26, 26, 603, DateTimeKind.Utc).AddTicks(7533));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 9, 26, 26, 603, DateTimeKind.Utc).AddTicks(7536));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 9, 26, 26, 603, DateTimeKind.Utc).AddTicks(7538));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "ConfigId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 9, 26, 26, 603, DateTimeKind.Utc).AddTicks(7882));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "ConfigId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 9, 26, 26, 603, DateTimeKind.Utc).AddTicks(7884));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "ConfigId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 9, 26, 26, 603, DateTimeKind.Utc).AddTicks(7886));
        }
    }
}
