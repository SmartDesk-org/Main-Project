using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ResourceFlow.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8055));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Code", "CreatedAt" },
                values: new object[] { 3, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8061) });

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Code", "CreatedAt" },
                values: new object[] { 4, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8063) });

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Code", "CreatedAt", "Name", "ParentId" },
                values: new object[] { 5, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8065), "Company Desk", 2 });

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Code", "CreatedAt", "Name", "ParentId" },
                values: new object[] { 6, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8066), "Company Meeting Room", 2 });

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Code", "CreatedAt", "Name" },
                values: new object[] { 7, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8068), "Employee Management" });

            migrationBuilder.InsertData(
                table: "AppModules",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsDeleted", "ModifiedAt", "ModifiedBy", "Name", "ParentId" },
                values: new object[,]
                {
                    { 7, 8, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8069), null, null, null, false, null, null, "Subscription Plans", null },
                    { 14, 15, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8078), null, null, null, false, null, null, "Notifications", null },
                    { 15, 16, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8079), null, null, null, false, null, null, "Client Messages", null },
                    { 16, 2, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8080), null, null, null, false, null, null, "Roles", null }
                });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8581));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 6, 1 },
                columns: new[] { "Add", "CreatedAt", "Delete", "Edit" },
                values: new object[] { false, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8584), false, false });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 1, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8597));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 6, 2 },
                columns: new[] { "Add", "CreatedAt", "Delete", "Edit" },
                values: new object[] { true, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8602), true, true });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "ModuleCode", "RoleId", "Add", "CreatedAt", "CreatedBy", "Delete", "DeletedAt", "DeletedBy", "Edit", "IsDeleted", "ModifiedAt", "ModifiedBy", "View" },
                values: new object[,]
                {
                    { 2, 1, true, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8552), null, true, null, null, true, false, null, null, true },
                    { 3, 1, true, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8573), null, true, null, null, true, false, null, null, true },
                    { 4, 1, false, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8583), null, false, null, null, false, false, null, null, true },
                    { 5, 1, false, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8582), null, false, null, null, false, false, null, null, true },
                    { 7, 1, false, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8575), null, false, null, null, false, false, null, null, true },
                    { 8, 1, true, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8536), null, true, null, null, true, false, null, null, true },
                    { 9, 1, true, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8589), null, true, null, null, true, false, null, null, true },
                    { 10, 1, true, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8588), null, true, null, null, true, false, null, null, true },
                    { 11, 1, false, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8574), null, true, null, null, true, false, null, null, true },
                    { 12, 1, false, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8578), null, false, null, null, false, false, null, null, true },
                    { 13, 1, false, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8576), null, false, null, null, false, false, null, null, true },
                    { 14, 1, false, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8587), null, false, null, null, false, false, null, null, true },
                    { 15, 1, true, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8572), null, true, null, null, true, false, null, null, true },
                    { 16, 1, false, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8586), null, true, null, null, true, false, null, null, true },
                    { 2, 2, false, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8604), null, false, null, null, false, false, null, null, false },
                    { 3, 2, true, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8592), null, true, null, null, true, false, null, null, true },
                    { 4, 2, true, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8600), null, true, null, null, true, false, null, null, true },
                    { 5, 2, true, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8599), null, true, null, null, true, false, null, null, true },
                    { 7, 2, true, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8594), null, true, null, null, true, false, null, null, true },
                    { 8, 2, false, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8590), null, false, null, null, false, false, null, null, true },
                    { 9, 2, true, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8609), null, true, null, null, true, false, null, null, true },
                    { 10, 2, true, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8607), null, true, null, null, true, false, null, null, true },
                    { 11, 2, false, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8593), null, false, null, null, false, false, null, null, true },
                    { 12, 2, true, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8596), null, false, null, null, false, false, null, null, true },
                    { 13, 2, false, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8595), null, false, null, null, false, false, null, null, true },
                    { 14, 2, false, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8606), null, false, null, null, false, false, null, null, true },
                    { 15, 2, true, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8603), null, true, null, null, true, false, null, null, true },
                    { 16, 2, true, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8605), null, false, null, null, false, false, null, null, true },
                    { 1, 3, false, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8616), null, false, null, null, true, false, null, null, true },
                    { 2, 3, false, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8622), null, false, null, null, false, false, null, null, false },
                    { 3, 3, false, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8611), null, false, null, null, false, false, null, null, true },
                    { 4, 3, false, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8619), null, false, null, null, false, false, null, null, true },
                    { 5, 3, false, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8617), null, false, null, null, false, false, null, null, true },
                    { 6, 3, false, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8620), null, false, null, null, false, false, null, null, true },
                    { 7, 3, false, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8613), null, false, null, null, true, false, null, null, true },
                    { 8, 3, false, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8610), null, false, null, null, false, false, null, null, true },
                    { 9, 3, false, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8629), null, false, null, null, false, false, null, null, false },
                    { 10, 3, false, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8626), null, false, null, null, false, false, null, null, false },
                    { 11, 3, false, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8612), null, false, null, null, false, false, null, null, false },
                    { 12, 3, false, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8615), null, false, null, null, false, false, null, null, false },
                    { 13, 3, false, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8614), null, false, null, null, false, false, null, null, false },
                    { 14, 3, false, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8624), null, false, null, null, false, false, null, null, false },
                    { 15, 3, false, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8621), null, false, null, null, false, false, null, null, true },
                    { 16, 3, false, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8623), null, false, null, null, false, false, null, null, false }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(9003));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(9006));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 5, 5, 4, 768, DateTimeKind.Utc).AddTicks(578));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 5, 5, 4, 768, DateTimeKind.Utc).AddTicks(583));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 5, 5, 4, 768, DateTimeKind.Utc).AddTicks(584));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PassWord" },
                values: new object[] { new DateTime(2025, 12, 24, 5, 5, 5, 120, DateTimeKind.Utc).AddTicks(4410), "$2a$11$.jVH1A07IoJ8JybeCAUJ0Oe0Qx9jUbpBjm0IJQ13RhkV1Sf67fEyC" });

            migrationBuilder.InsertData(
                table: "AppModules",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsDeleted", "ModifiedAt", "ModifiedBy", "Name", "ParentId" },
                values: new object[,]
                {
                    { 8, 9, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8070), null, null, null, false, null, null, "Resource Management", 7 },
                    { 9, 10, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8071), null, null, null, false, null, null, "Subscription Types", 7 },
                    { 10, 11, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8072), null, null, null, false, null, null, "Company Subscriptions", 7 },
                    { 11, 12, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8074), null, null, null, false, null, null, "Payment", 10 },
                    { 12, 13, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8075), null, null, null, false, null, null, "Billing", 10 },
                    { 13, 14, new DateTime(2025, 12, 24, 5, 5, 4, 767, DateTimeKind.Utc).AddTicks(8076), null, null, null, false, null, null, "Subscription History", 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 9, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 10, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 11, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 12, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 13, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 14, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 15, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 16, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 8, 2 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 9, 2 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 10, 2 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 11, 2 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 12, 2 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 13, 2 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 14, 2 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 15, 2 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 16, 2 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 9, 3 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 10, 3 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 11, 3 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 12, 3 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 13, 3 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 14, 3 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 15, 3 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 16, 3 });

            migrationBuilder.DeleteData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 22, 10, 21, 0, 383, DateTimeKind.Utc).AddTicks(9821));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Code", "CreatedAt" },
                values: new object[] { 2, new DateTime(2025, 12, 22, 10, 21, 0, 383, DateTimeKind.Utc).AddTicks(9825) });

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Code", "CreatedAt" },
                values: new object[] { 3, new DateTime(2025, 12, 22, 10, 21, 0, 383, DateTimeKind.Utc).AddTicks(9826) });

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Code", "CreatedAt", "Name", "ParentId" },
                values: new object[] { 4, new DateTime(2025, 12, 22, 10, 21, 0, 383, DateTimeKind.Utc).AddTicks(9827), "Resource Management", null });

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Code", "CreatedAt", "Name", "ParentId" },
                values: new object[] { 5, new DateTime(2025, 12, 22, 10, 21, 0, 383, DateTimeKind.Utc).AddTicks(9828), "Employee Management", null });

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Code", "CreatedAt", "Name" },
                values: new object[] { 6, new DateTime(2025, 12, 22, 10, 21, 0, 383, DateTimeKind.Utc).AddTicks(9829), "Subscription Plan" });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 22, 10, 21, 0, 384, DateTimeKind.Utc).AddTicks(108));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 6, 1 },
                columns: new[] { "Add", "CreatedAt", "Delete", "Edit" },
                values: new object[] { true, new DateTime(2025, 12, 22, 10, 21, 0, 384, DateTimeKind.Utc).AddTicks(113), true, true });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 1, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 12, 22, 10, 21, 0, 384, DateTimeKind.Utc).AddTicks(114));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumns: new[] { "ModuleCode", "RoleId" },
                keyValues: new object[] { 6, 2 },
                columns: new[] { "Add", "CreatedAt", "Delete", "Edit" },
                values: new object[] { false, new DateTime(2025, 12, 22, 10, 21, 0, 384, DateTimeKind.Utc).AddTicks(115), false, false });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 22, 10, 21, 0, 384, DateTimeKind.Utc).AddTicks(286));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 22, 10, 21, 0, 384, DateTimeKind.Utc).AddTicks(288));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 22, 10, 21, 0, 384, DateTimeKind.Utc).AddTicks(289));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 22, 10, 21, 0, 384, DateTimeKind.Utc).AddTicks(1566));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 22, 10, 21, 0, 384, DateTimeKind.Utc).AddTicks(1568));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 22, 10, 21, 0, 384, DateTimeKind.Utc).AddTicks(1569));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PassWord" },
                values: new object[] { new DateTime(2025, 12, 22, 10, 21, 0, 697, DateTimeKind.Utc).AddTicks(4380), "$2a$11$mOsSyRKlBduNuNWYlK7QSO6t0ag6HUw6X90IeNTIuCvBnesS5djti" });
        }
    }
}
