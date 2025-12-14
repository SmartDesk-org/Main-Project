using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResourceFlow.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class FixRolePermissionSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "ModuleId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "ModuleId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "ModuleId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 13, 11, 25, 58, 705, DateTimeKind.Utc).AddTicks(1420));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 13, 11, 25, 58, 705, DateTimeKind.Utc).AddTicks(1429));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 13, 11, 25, 58, 705, DateTimeKind.Utc).AddTicks(1431));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PassWord" },
                values: new object[] { new DateTime(2025, 12, 13, 11, 25, 59, 23, DateTimeKind.Utc).AddTicks(7157), "$2a$11$owGyGucHfcpo.jXXU0RpP.PYpW/Jdkj1nns1aSXLirUvXxQOQ9goG" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "ModuleId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "ModuleId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "ModuleId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 13, 11, 13, 2, 79, DateTimeKind.Utc).AddTicks(3303));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 13, 11, 13, 2, 79, DateTimeKind.Utc).AddTicks(3308));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 13, 11, 13, 2, 79, DateTimeKind.Utc).AddTicks(3308));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PassWord" },
                values: new object[] { new DateTime(2025, 12, 13, 11, 13, 2, 411, DateTimeKind.Utc).AddTicks(6402), "$2a$11$KQ4VSU3zKzpXB9jRgc5bl.21eAL4u9jTxMXLMwbiRGrDwEcGAxvqO" });
        }
    }
}
