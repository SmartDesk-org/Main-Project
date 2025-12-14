using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ResourceFlow.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class SeedRolesModulesPermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "User" },
                    { 2, "CompanyDetails" },
                    { 3, "CompanyFloor" },
                    { 4, "Resource" },
                    { 5, "Employee" },
                    { 6, "Subscription" }
                });

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

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "RoleId", "CanAdd", "CanDelete", "CanEdit", "CanView", "Id", "ModuleId" },
                values: new object[,]
                {
                    { 1, true, true, true, true, 1, 1 },
                    { 2, false, false, false, true, 2, 1 },
                    { 3, false, false, false, false, 3, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "RoleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "RoleId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "RoleId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 13, 10, 52, 46, 350, DateTimeKind.Utc).AddTicks(2588));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 13, 10, 52, 46, 350, DateTimeKind.Utc).AddTicks(2591));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 13, 10, 52, 46, 350, DateTimeKind.Utc).AddTicks(2592));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PassWord" },
                values: new object[] { new DateTime(2025, 12, 13, 10, 52, 46, 484, DateTimeKind.Utc).AddTicks(2559), "$2a$11$yIVIpFMsrxcKn5rRmcw4N.6bzxeJwC7D8QlGVHufyg5vQEAHGidLe" });
        }
    }
}
