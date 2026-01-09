using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResourceFlow.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultScope : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 181, DateTimeKind.Utc).AddTicks(8783));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 181, DateTimeKind.Utc).AddTicks(8786));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 181, DateTimeKind.Utc).AddTicks(8787));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 181, DateTimeKind.Utc).AddTicks(8788));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 181, DateTimeKind.Utc).AddTicks(8789));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 181, DateTimeKind.Utc).AddTicks(8790));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 181, DateTimeKind.Utc).AddTicks(8790));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 181, DateTimeKind.Utc).AddTicks(8791));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 181, DateTimeKind.Utc).AddTicks(8844));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 181, DateTimeKind.Utc).AddTicks(8846));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 181, DateTimeKind.Utc).AddTicks(8847));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 181, DateTimeKind.Utc).AddTicks(8848));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 181, DateTimeKind.Utc).AddTicks(8849));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 181, DateTimeKind.Utc).AddTicks(8851));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 181, DateTimeKind.Utc).AddTicks(8851));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 181, DateTimeKind.Utc).AddTicks(8870));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 181, DateTimeKind.Utc).AddTicks(8871));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 181, DateTimeKind.Utc).AddTicks(8872));

            migrationBuilder.UpdateData(
                table: "ResourceTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(1747));

            migrationBuilder.UpdateData(
                table: "ResourceTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(1751));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(1963), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(1965), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(1966), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(1968), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(1969), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(1970), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(1971), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(1972), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(1974), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(1975), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(1976), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(1977), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(1978), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(1979), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(1980), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(1981), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(1982), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(1983), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(1984), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(2067), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(2069), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(2070), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(2072), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(2073), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(2074), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(2076), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(2077), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(2078), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(2079), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(2080), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(2081), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(2082), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(2083), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(2084), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(2085), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(2087), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(2088), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(2089), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(2090), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(2091), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(2092), 1 });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(2314));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(2315));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(2315));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(3549));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(3550));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(3551));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PassWord" },
                values: new object[] { new DateTime(2025, 12, 30, 9, 26, 27, 518, DateTimeKind.Utc).AddTicks(8587), "$2a$11$SCEBXVaLJD8kgD9eTuOspOxtQV3yZfGJ.nIM8X6fYsnnSKqtJ.OxW" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(1111));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(1114));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(1115));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(1116));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(1117));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(1118));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(1119));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(1120));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(1121));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(1122));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(1123));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(1124));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(1126));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(1127));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(1127));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(1153));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(1154));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(1155));

            migrationBuilder.UpdateData(
                table: "ResourceTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(3720));

            migrationBuilder.UpdateData(
                table: "ResourceTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(3722));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(4104), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(4106), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(4107), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(4109), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(4110), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(4111), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(4112), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(4113), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(4115), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(4116), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(4117), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(4118), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(4119), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(4120), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(4121), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(4121), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(4122), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(4123), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(4124), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(4126), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(4127), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(4128), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(4129), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(4131), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(4132), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(4133), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(4134), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(4135), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(4136), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(4137), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(4138), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(4139), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(4140), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(4141), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(4142), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(4143), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(4144), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(4145), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(4146), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(4147), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(4148), 0 });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(4375));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(4376));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(4377));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(5967));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(5969));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 8, 22, 38, 678, DateTimeKind.Utc).AddTicks(5969));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PassWord" },
                values: new object[] { new DateTime(2025, 12, 30, 8, 22, 38, 925, DateTimeKind.Utc).AddTicks(8028), "$2a$11$hWUR3ihe3iz7uPBRD6vYsu.kYmvMWaw26DSNci2Fs5aB/uV3ORMOq" });
        }
    }
}
