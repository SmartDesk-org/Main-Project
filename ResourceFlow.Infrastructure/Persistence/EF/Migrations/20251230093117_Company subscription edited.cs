using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResourceFlow.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class Companysubscriptionedited : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Resources",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "DesksLimit",
                table: "CompanySubscription",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmployeesLimit",
                table: "CompanySubscription",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FloorsLimit",
                table: "CompanySubscription",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MeetingRoomsLimit",
                table: "CompanySubscription",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "DesksLimit",
                table: "CompanySubscription");

            migrationBuilder.DropColumn(
                name: "EmployeesLimit",
                table: "CompanySubscription");

            migrationBuilder.DropColumn(
                name: "FloorsLimit",
                table: "CompanySubscription");

            migrationBuilder.DropColumn(
                name: "MeetingRoomsLimit",
                table: "CompanySubscription");

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(2409));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(2414));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(2416));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(2417));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(2419));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(2420));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(2421));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(2423));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(2424));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(2425));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(2427));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(2428));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(2430));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(2431));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(2432));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(2454));

            migrationBuilder.UpdateData(
                table: "ResourceTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(3953));

            migrationBuilder.UpdateData(
                table: "ResourceTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(3957));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(4232));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 2, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(4224));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 3, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(4226));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 4, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(4235));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 5, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(4234));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 6, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(4236));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 7, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(4229));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 8, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(4220));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 9, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(4241));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 10, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(4239));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 11, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(4228));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 12, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(4231));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 13, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(4230));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 14, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(4238));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 15, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(4225));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 16, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(4237));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 1, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(4252));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 2, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(4275));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 3, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(4246));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 4, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(4254));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 5, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(4253));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 6, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(4255));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 7, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(4248));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 8, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(4245));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 9, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(4279));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 10, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(4278));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 11, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(4247));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 12, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(4250));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 13, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(4249));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 14, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(4277));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 15, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(4274));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 16, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(4276));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 1, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(4287));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 2, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(4293));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 3, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(4282));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 4, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(4289));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 5, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(4288));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 6, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(4291));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 7, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(4284));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 8, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(4280));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 9, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(4298));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 10, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(4296));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 11, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(4283));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 12, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(4286));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 13, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(4285));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 14, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(4295));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 15, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(4292));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 16, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(4294));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(4549));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(4552));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(4553));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(5810));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(5829));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(5830));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PassWord" },
                values: new object[] { new DateTime(2025, 12, 29, 7, 27, 10, 184, DateTimeKind.Utc).AddTicks(5537), "$2a$11$DrGmVUpmFZx3PJ0zxxQyleN48fqzMXW5.DFbodRutBCy8Qu6Idcwm" });
        }
    }
}
