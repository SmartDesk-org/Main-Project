using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResourceFlow.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class someedited : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UpcomingComSubId",
                table: "CompanySubscription",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(6920));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(6925));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(6926));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(6928));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(6930));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(6931));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(6933));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(6934));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(6935));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(6937));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(6938));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(6940));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(6941));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(6943));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(6944));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(6960));

            migrationBuilder.UpdateData(
                table: "ResourceTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(9436));

            migrationBuilder.UpdateData(
                table: "ResourceTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(9442));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(9746));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 2, 1 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(9724));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 3, 1 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(9727));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 4, 1 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(9749));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 5, 1 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(9747));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 6, 1 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(9750));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 7, 1 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(9742));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 8, 1 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(9719));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 9, 1 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(9756));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 10, 1 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(9754));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 11, 1 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(9729));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 12, 1 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(9744));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 13, 1 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(9743));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 14, 1 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(9753));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 15, 1 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(9726));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 16, 1 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(9752));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 1, 2 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(9765));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 2, 2 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(9772));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 3, 2 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(9758));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 4, 2 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(9768));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 5, 2 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(9766));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 6, 2 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(9769));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 7, 2 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(9761));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 8, 2 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(9757));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 9, 2 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(9777));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 10, 2 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(9776));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 11, 2 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(9760));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 12, 2 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(9764));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 13, 2 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(9762));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 14, 2 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(9774));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 15, 2 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(9771));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 16, 2 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(9773));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 1, 3 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(9787));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 2, 3 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(9793));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 3, 3 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(9780));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 4, 3 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(9789));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 5, 3 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(9788));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 6, 3 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(9791));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 7, 3 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(9783));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 8, 3 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(9779));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 9, 3 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(9799));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 10, 3 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(9797));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 11, 3 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(9781));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 12, 3 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(9785));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 13, 3 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(9784));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 14, 3 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(9796));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 15, 3 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(9792));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 16, 3 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 534, DateTimeKind.Utc).AddTicks(9795));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 535, DateTimeKind.Utc).AddTicks(33));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 535, DateTimeKind.Utc).AddTicks(36));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 535, DateTimeKind.Utc).AddTicks(37));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 535, DateTimeKind.Utc).AddTicks(1452));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 535, DateTimeKind.Utc).AddTicks(1455));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 5, 50, 15, 535, DateTimeKind.Utc).AddTicks(1456));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PassWord" },
                values: new object[] { new DateTime(2026, 1, 9, 5, 50, 15, 762, DateTimeKind.Utc).AddTicks(3615), "$2a$11$NWL/M1lS7.9UorkkU84/z.wFt9tuGXmqplabhpk21HzJIVk2GX7ry" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpcomingComSubId",
                table: "CompanySubscription");

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 514, DateTimeKind.Utc).AddTicks(5252));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 514, DateTimeKind.Utc).AddTicks(5260));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 514, DateTimeKind.Utc).AddTicks(5263));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 514, DateTimeKind.Utc).AddTicks(5266));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 514, DateTimeKind.Utc).AddTicks(5269));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 514, DateTimeKind.Utc).AddTicks(5271));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 514, DateTimeKind.Utc).AddTicks(5274));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 514, DateTimeKind.Utc).AddTicks(5276));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 514, DateTimeKind.Utc).AddTicks(5279));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 514, DateTimeKind.Utc).AddTicks(5281));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 514, DateTimeKind.Utc).AddTicks(5284));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 514, DateTimeKind.Utc).AddTicks(5286));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 514, DateTimeKind.Utc).AddTicks(5289));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 514, DateTimeKind.Utc).AddTicks(5291));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 514, DateTimeKind.Utc).AddTicks(5293));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 514, DateTimeKind.Utc).AddTicks(5315));

            migrationBuilder.UpdateData(
                table: "ResourceTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 514, DateTimeKind.Utc).AddTicks(9471));

            migrationBuilder.UpdateData(
                table: "ResourceTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 514, DateTimeKind.Utc).AddTicks(9479));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(356));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 2, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(338));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 3, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(345));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 4, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(360));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 5, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(358));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 6, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(362));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 7, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(349));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 8, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(332));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 9, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(371));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 10, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(369));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 11, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(347));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 12, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(354));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 13, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(351));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 14, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(367));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 15, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(342));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 16, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(364));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 1, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(386));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 2, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(397));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 3, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(375));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 4, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(391));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 5, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(388));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 6, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(392));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 7, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(379));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 8, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(373));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 9, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(433));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 10, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(431));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 11, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(377));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 12, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(385));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 13, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(382));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 14, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(429));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 15, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(395));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 16, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(399));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 1, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(448));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 2, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(459));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 3, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(437));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 4, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(452));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 5, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(450));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 6, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(455));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 7, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(442));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 8, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(435));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 9, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(467));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 10, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(465));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 11, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(439));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 12, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(446));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 13, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(444));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 14, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(463));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 15, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(457));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 16, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(461));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(1039));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(1044));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(1046));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(4422));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(4428));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 31, 15, 515, DateTimeKind.Utc).AddTicks(4430));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PassWord" },
                values: new object[] { new DateTime(2025, 12, 30, 9, 31, 15, 905, DateTimeKind.Utc).AddTicks(240), "$2a$11$NuIr9jNgPn1bKhFXjal.Cu9uLJMP07jB79IRQ.4PqJxilRw/xK/xG" });
        }
    }
}
