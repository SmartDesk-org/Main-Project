using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ResourceFlow.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class typeseedadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "ResourceTypes",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultHeight", "DefaultWidth", "DeletedAt", "DeletedBy", "Icon", "IsActive", "IsDeleted", "ModifiedAt", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(3953), null, 60, 60, null, null, "desk.png", true, false, null, null, "Desk" },
                    { 2, new DateTime(2025, 12, 29, 7, 27, 10, 52, DateTimeKind.Utc).AddTicks(3957), null, 120, 120, null, null, "meetingroom.png", true, false, null, null, "MeetingRoom" }
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ResourceTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ResourceTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(7605));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(7613));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(7614));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(7617));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(7619));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(7621));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(7622));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(7624));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(7625));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(7627));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(7629));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(7631));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(7633));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(7634));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(7636));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(8414));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 2, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(8380));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 3, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(8405));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 4, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(8419));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 5, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(8418));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 6, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(8421));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 7, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(8408));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 8, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(8374));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 9, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(8426));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 10, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(8425));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 11, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(8406));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 12, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(8412));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 13, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(8411));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 14, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(8423));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 15, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(8403));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 16, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(8422));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 1, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(8437));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 2, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(8444));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 3, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(8429));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 4, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(8440));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 5, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(8438));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 6, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(8442));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 7, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(8432));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 8, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(8427));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 9, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(8450));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 10, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(8448));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 11, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(8431));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 12, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(8435));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 13, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(8434));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 14, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(8447));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 15, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(8443));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 16, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(8446));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 1, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(8458));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 2, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(8466));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 3, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(8452));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 4, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(8461));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 5, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(8460));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 6, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(8463));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 7, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(8455));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 8, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(8451));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 9, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(8472));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 10, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(8471));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 11, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(8453));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 12, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(8457));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 13, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(8456));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 14, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(8469));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 15, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(8465));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 16, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(8468));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(8863));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(8872));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 471, DateTimeKind.Utc).AddTicks(8873));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 472, DateTimeKind.Utc).AddTicks(637));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 472, DateTimeKind.Utc).AddTicks(641));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 29, 7, 13, 24, 472, DateTimeKind.Utc).AddTicks(642));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PassWord" },
                values: new object[] { new DateTime(2025, 12, 29, 7, 13, 24, 845, DateTimeKind.Utc).AddTicks(1085), "$2a$11$7q70J4o.IJZIMIlXSeIoF.CjgsjC7N.sWAYRzTqrqHQ.SwBmXPLj6" });
        }
    }
}
