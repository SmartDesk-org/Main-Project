using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ResourceFlow.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedRolePermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(228));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(234));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(238));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(240));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(244));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(246));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(381));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(383));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(385));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(387));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(388));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(390));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(392));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(393));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(395));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(421));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(423));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(424));

            migrationBuilder.InsertData(
                table: "AppModules",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsDeleted", "ModifiedAt", "ModifiedBy", "Name", "ParentId" },
                values: new object[,]
                {
                    { 19, 19, new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(426), null, null, null, false, null, null, "Resource Booking Permission", null },
                    { 20, 20, new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(427), null, null, null, false, null, null, "Resource Booking", null }
                });

            migrationBuilder.UpdateData(
                table: "CompanyResourceBookingPermissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(977));

            migrationBuilder.UpdateData(
                table: "CompanyResourceBookingPermissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(980));

            migrationBuilder.UpdateData(
                table: "ResourceTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(4464));

            migrationBuilder.UpdateData(
                table: "ResourceTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(4470));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(4808));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(4812));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(4816));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(4819));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(4822));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(4823));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(4824));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(4846));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(4848));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(4849));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(4850));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(4852));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(4853));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(4855));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(4856));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(4857));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(4861));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(4862));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(4863));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(4867));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(4868));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(4870));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(4871));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(4873));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(4875));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(4876));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(4878));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(4879));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(4880));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(4881));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(4883));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(4884));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(4888));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(4890));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(4891));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(4892));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(4893));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(4895));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(4896));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(4897));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(4898));

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "Add", "CreatedAt", "CreatedBy", "Delete", "DeletedAt", "DeletedBy", "Edit", "IsDeleted", "ModifiedAt", "ModifiedBy", "ModuleCode", "RoleId", "Scope", "UserId", "View" },
                values: new object[,]
                {
                    { 42, true, new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(4885), null, true, null, null, true, false, null, null, 18, 2, 0, null, true },
                    { 43, true, new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(4886), null, true, null, null, true, false, null, null, 20, 2, 0, null, true },
                    { 44, true, new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(4899), null, true, null, null, true, false, null, null, 20, 3, 0, null, true }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(5184));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(5186));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(5187));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(7544));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(7547));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 7, 12, 33, 58, DateTimeKind.Utc).AddTicks(7548));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PassWord" },
                values: new object[] { new DateTime(2026, 1, 8, 7, 12, 33, 386, DateTimeKind.Utc).AddTicks(9636), "$2a$11$xqAtvFegKLD4y1VOVuep2evUCclMLoJ/eLSkcbg2JPtuDnR5/DQkC" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(4964));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(4968));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(4969));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(4971));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(4974));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(4975));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(4976));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(5098));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(5099));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(5100));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(5101));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(5102));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(5104));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(5105));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(5106));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(5124));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(5125));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(5126));

            migrationBuilder.UpdateData(
                table: "CompanyResourceBookingPermissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(5672));

            migrationBuilder.UpdateData(
                table: "CompanyResourceBookingPermissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(5675));

            migrationBuilder.UpdateData(
                table: "ResourceTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(8532));

            migrationBuilder.UpdateData(
                table: "ResourceTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(8535));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(8981));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(8986));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(8991));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(8995));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(8996));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(8998));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9001));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9002));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9006));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9009));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9198));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9200));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9201));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9202));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9204));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9205));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9206));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9208));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9209));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9211));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9213));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9215));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9216));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9218));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9219));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9221));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9222));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9224));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9225));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9228));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9229));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9230));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9232));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9233));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9235));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9236));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9237));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9239));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9240));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9241));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9589));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9590));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9591));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 219, DateTimeKind.Utc).AddTicks(1783));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 219, DateTimeKind.Utc).AddTicks(1785));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 219, DateTimeKind.Utc).AddTicks(1787));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PassWord" },
                values: new object[] { new DateTime(2026, 1, 2, 7, 15, 44, 548, DateTimeKind.Utc).AddTicks(389), "$2a$11$XallUFBJnK7TGROK2E5ld.c9lkL9T1IibpLD67jFxqa9X33zsgASq" });
        }
    }
}
