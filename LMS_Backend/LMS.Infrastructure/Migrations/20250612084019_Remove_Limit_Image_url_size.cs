using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS_Backend.Migrations
{
    /// <inheritdoc />
    public partial class Remove_Limit_Image_url_size : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CoverImageUrl",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CoverImageUrl",
                table: "Books",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 12, 8, 38, 22, 365, DateTimeKind.Utc).AddTicks(8231));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 12, 8, 38, 22, 365, DateTimeKind.Utc).AddTicks(8237));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 12, 8, 38, 22, 365, DateTimeKind.Utc).AddTicks(8241));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 12, 8, 38, 22, 365, DateTimeKind.Utc).AddTicks(8244));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 12, 8, 38, 22, 365, DateTimeKind.Utc).AddTicks(8247));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 12, 8, 38, 22, 365, DateTimeKind.Utc).AddTicks(8251));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 12, 8, 38, 22, 365, DateTimeKind.Utc).AddTicks(8254));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 12, 8, 38, 22, 365, DateTimeKind.Utc).AddTicks(8257));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 12, 8, 38, 22, 365, DateTimeKind.Utc).AddTicks(8260));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 12, 8, 38, 22, 365, DateTimeKind.Utc).AddTicks(8263));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 12, 8, 38, 22, 365, DateTimeKind.Utc).AddTicks(8266));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 12, 8, 38, 22, 365, DateTimeKind.Utc).AddTicks(7606));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 12, 8, 38, 22, 365, DateTimeKind.Utc).AddTicks(7613));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 12, 8, 38, 22, 365, DateTimeKind.Utc).AddTicks(7617));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "ConfigId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 12, 8, 38, 22, 365, DateTimeKind.Utc).AddTicks(8411));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "ConfigId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 12, 8, 38, 22, 365, DateTimeKind.Utc).AddTicks(8416));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "ConfigId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 12, 8, 38, 22, 365, DateTimeKind.Utc).AddTicks(8420));
        }
    }
}
