using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResourceFlow.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class editedcopsub : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CompanySubscription_CompanyId",
                table: "CompanySubscription");

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(6062));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(6072));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(6074));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(6077));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(6080));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(6083));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(6085));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(6087));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(6090));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(6092));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(6095));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(6098));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(6100));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(6102));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(6105));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(6121));

            migrationBuilder.UpdateData(
                table: "ResourceTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(9200));

            migrationBuilder.UpdateData(
                table: "ResourceTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(9207));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(9703));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 2, 1 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(9686));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 3, 1 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(9692));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 4, 1 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(9707));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 5, 1 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(9705));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 6, 1 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(9709));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 7, 1 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(9696));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 8, 1 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(9681));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 9, 1 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(9719));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 10, 1 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(9717));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 11, 1 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(9694));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 12, 1 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(9701));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 13, 1 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(9698));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 14, 1 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(9714));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 15, 1 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(9689));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 16, 1 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(9711));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 1, 2 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(9733));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 2, 2 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(9743));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 3, 2 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(9723));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 4, 2 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(9737));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 5, 2 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(9735));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 6, 2 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(9739));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 7, 2 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(9727));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 8, 2 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(9721));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 9, 2 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(9751));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 10, 2 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(9749));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 11, 2 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(9725));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 12, 2 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(9731));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 13, 2 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(9729));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 14, 2 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(9747));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 15, 2 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(9741));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 16, 2 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(9745));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 1, 3 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(9781));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 2, 3 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(9791));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 3, 3 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(9755));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 4, 3 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(9785));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 5, 3 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(9783));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 6, 3 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(9787));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 7, 3 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(9759));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 8, 3 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(9753));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 9, 3 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(9800));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 10, 3 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(9797));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 11, 3 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(9757));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 12, 3 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(9763));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 13, 3 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(9761));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 14, 3 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(9795));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 15, 3 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(9789));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 16, 3 },
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 287, DateTimeKind.Utc).AddTicks(9793));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 288, DateTimeKind.Utc).AddTicks(210));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 288, DateTimeKind.Utc).AddTicks(214));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 288, DateTimeKind.Utc).AddTicks(216));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 288, DateTimeKind.Utc).AddTicks(2544));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 288, DateTimeKind.Utc).AddTicks(2549));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 8, 30, 27, 288, DateTimeKind.Utc).AddTicks(2551));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PassWord" },
                values: new object[] { new DateTime(2026, 1, 9, 8, 30, 27, 622, DateTimeKind.Utc).AddTicks(1471), "$2a$11$vZlYJyerof04rVONes89c.ZcsJona0c59hIp3c3aN7dBYOamekp8u" });

            migrationBuilder.CreateIndex(
                name: "IX_CompanySubscription_CompanyId",
                table: "CompanySubscription",
                column: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CompanySubscription_CompanyId",
                table: "CompanySubscription");

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

            migrationBuilder.CreateIndex(
                name: "IX_CompanySubscription_CompanyId",
                table: "CompanySubscription",
                column: "CompanyId",
                unique: true);
        }
    }
}
