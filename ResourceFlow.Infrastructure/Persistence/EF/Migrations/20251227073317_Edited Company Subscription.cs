using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResourceFlow.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class EditedCompanySubscription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxDesks",
                table: "CompanySubscription",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxEmployees",
                table: "CompanySubscription",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxFloors",
                table: "CompanySubscription",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxMeetingRooms",
                table: "CompanySubscription",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(6741));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(6749));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(6751));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(6754));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(6757));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(6759));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(6780));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(6782));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(6784));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(6786));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(6789));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(6791));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(6793));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(6795));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(6797));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(6799));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(7380));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 2, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(7365));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 3, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(7370));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 4, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(7384));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 5, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(7382));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 6, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(7386));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 7, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(7374));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 8, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(7345));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 9, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(7394));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 10, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(7392));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 11, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(7372));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 12, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(7378));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 13, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(7376));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 14, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(7390));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 15, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(7368));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 16, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(7388));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 1, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(7413));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 2, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(7422));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 3, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(7398));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 4, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(7417));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 5, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(7415));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 6, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(7419));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 7, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(7402));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 8, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(7396));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 9, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(7433));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 10, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(7428));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 11, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(7400));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 12, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(7411));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 13, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(7409));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 14, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(7426));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 15, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(7421));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 16, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(7424));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 1, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(7447));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 2, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(7478));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 3, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(7437));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 4, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(7451));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 5, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(7449));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 6, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(7453));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 7, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(7441));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 8, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(7435));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 9, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(7486));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 10, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(7484));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 11, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(7439));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 12, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(7445));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 13, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(7443));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 14, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(7482));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 15, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(7476));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 16, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(7480));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(7831));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(7835));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(7837));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 903, DateTimeKind.Utc).AddTicks(9996));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 904, DateTimeKind.Utc).AddTicks(2));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 27, 7, 33, 13, 904, DateTimeKind.Utc).AddTicks(4));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PassWord" },
                values: new object[] { new DateTime(2025, 12, 27, 7, 33, 14, 257, DateTimeKind.Utc).AddTicks(9871), "$2a$11$X74uq3MZyLV5E3Cp399UDuq6A9qpmhWwJHEkwiUYCBynMsWoTJ8wW" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxDesks",
                table: "CompanySubscription");

            migrationBuilder.DropColumn(
                name: "MaxEmployees",
                table: "CompanySubscription");

            migrationBuilder.DropColumn(
                name: "MaxFloors",
                table: "CompanySubscription");

            migrationBuilder.DropColumn(
                name: "MaxMeetingRooms",
                table: "CompanySubscription");

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(5236));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(5246));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(5249));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(5253));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(5256));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(5259));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(5261));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(5264));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(5267));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(5270));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(5273));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(5276));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(5279));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(5282));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(5285));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(5287));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(6016));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 2, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(5994));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 3, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(6001));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 4, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(6022));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 5, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(6019));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 6, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(6024));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 7, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(6007));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 8, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(5974));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 9, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(6036));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 10, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(6033));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 11, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(6004));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 12, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(6013));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 13, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(6010));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 14, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(6030));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 15, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(5998));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 16, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(6027));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 1, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(6087));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 2, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(6101));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 3, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(6041));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 4, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(6093));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 5, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(6090));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 6, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(6096));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 7, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(6078));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 8, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(6038));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 9, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(6113));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 10, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(6110));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 11, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(6074));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 12, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(6084));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 13, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(6080));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 14, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(6107));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 15, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(6099));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 16, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(6104));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 1, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(6133));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 2, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(6147));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 3, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(6119));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 4, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(6138));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 5, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(6136));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 6, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(6141));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 7, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(6124));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 8, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(6116));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 9, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(6158));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 10, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(6155));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 11, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(6121));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 12, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(6130));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 13, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(6127));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 14, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(6152));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 15, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(6144));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 16, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(6149));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(6623));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(6627));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 322, DateTimeKind.Utc).AddTicks(6630));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 323, DateTimeKind.Utc).AddTicks(364));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 323, DateTimeKind.Utc).AddTicks(371));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 26, 14, 42, 24, 323, DateTimeKind.Utc).AddTicks(374));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PassWord" },
                values: new object[] { new DateTime(2025, 12, 26, 14, 42, 24, 712, DateTimeKind.Utc).AddTicks(9523), "$2a$11$XRoeyt6cYUOcSDuaBuYOjOW6A6nYf5MbB2jJu1DWpVjtrnDrRQMSG" });
        }
    }
}
