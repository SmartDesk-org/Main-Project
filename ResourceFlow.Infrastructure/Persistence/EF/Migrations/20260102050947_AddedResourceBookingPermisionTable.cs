using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ResourceFlow.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddedResourceBookingPermisionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Designation",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CompanyResourceBookingPermissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    ResourceTypeId = table.Column<int>(type: "int", nullable: false),
                    EmployeeType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CanBook = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyResourceBookingPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyResourceBookingPermissions_ResourceTypes_ResourceTypeId",
                        column: x => x.ResourceTypeId,
                        principalTable: "ResourceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 501, DateTimeKind.Utc).AddTicks(5018));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 501, DateTimeKind.Utc).AddTicks(5023));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 501, DateTimeKind.Utc).AddTicks(5025));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 501, DateTimeKind.Utc).AddTicks(5027));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 501, DateTimeKind.Utc).AddTicks(5029));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 501, DateTimeKind.Utc).AddTicks(5030));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 501, DateTimeKind.Utc).AddTicks(5031));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 501, DateTimeKind.Utc).AddTicks(5032));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 501, DateTimeKind.Utc).AddTicks(5033));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 501, DateTimeKind.Utc).AddTicks(5034));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 501, DateTimeKind.Utc).AddTicks(5036));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 501, DateTimeKind.Utc).AddTicks(5037));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 501, DateTimeKind.Utc).AddTicks(5038));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 501, DateTimeKind.Utc).AddTicks(5039));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 501, DateTimeKind.Utc).AddTicks(5041));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 501, DateTimeKind.Utc).AddTicks(5067));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 501, DateTimeKind.Utc).AddTicks(5069));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 501, DateTimeKind.Utc).AddTicks(5070));

            migrationBuilder.InsertData(
                table: "CompanyResourceBookingPermissions",
                columns: new[] { "Id", "CanBook", "CompanyId", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "EmployeeType", "IsDeleted", "ModifiedAt", "ModifiedBy", "ResourceTypeId" },
                values: new object[,]
                {
                    { 1, true, 1, new DateTime(2026, 1, 2, 5, 9, 45, 501, DateTimeKind.Utc).AddTicks(5650), null, null, null, "MANAGER", false, null, null, 2 },
                    { 2, true, 1, new DateTime(2026, 1, 2, 5, 9, 45, 501, DateTimeKind.Utc).AddTicks(5652), null, null, null, "TEAM_LEAD", false, null, null, 2 }
                });

            migrationBuilder.UpdateData(
                table: "ResourceTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 502, DateTimeKind.Utc).AddTicks(774));

            migrationBuilder.UpdateData(
                table: "ResourceTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 502, DateTimeKind.Utc).AddTicks(780));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 502, DateTimeKind.Utc).AddTicks(1576));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 502, DateTimeKind.Utc).AddTicks(1584));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 502, DateTimeKind.Utc).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 502, DateTimeKind.Utc).AddTicks(1588));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 502, DateTimeKind.Utc).AddTicks(1589));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 502, DateTimeKind.Utc).AddTicks(1591));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 502, DateTimeKind.Utc).AddTicks(1592));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 502, DateTimeKind.Utc).AddTicks(1593));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 502, DateTimeKind.Utc).AddTicks(1594));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 502, DateTimeKind.Utc).AddTicks(1596));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 502, DateTimeKind.Utc).AddTicks(1597));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 502, DateTimeKind.Utc).AddTicks(1598));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 502, DateTimeKind.Utc).AddTicks(1599));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 502, DateTimeKind.Utc).AddTicks(1600));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 502, DateTimeKind.Utc).AddTicks(1601));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 502, DateTimeKind.Utc).AddTicks(1602));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 502, DateTimeKind.Utc).AddTicks(1603));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 502, DateTimeKind.Utc).AddTicks(1604));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 502, DateTimeKind.Utc).AddTicks(1605));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 502, DateTimeKind.Utc).AddTicks(1606));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 502, DateTimeKind.Utc).AddTicks(1607));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 502, DateTimeKind.Utc).AddTicks(1612));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 502, DateTimeKind.Utc).AddTicks(1613));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 502, DateTimeKind.Utc).AddTicks(1615));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 502, DateTimeKind.Utc).AddTicks(1616));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 502, DateTimeKind.Utc).AddTicks(1617));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 502, DateTimeKind.Utc).AddTicks(1618));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 502, DateTimeKind.Utc).AddTicks(1619));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 502, DateTimeKind.Utc).AddTicks(1620));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 502, DateTimeKind.Utc).AddTicks(1621));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 502, DateTimeKind.Utc).AddTicks(1622));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 502, DateTimeKind.Utc).AddTicks(1623));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 502, DateTimeKind.Utc).AddTicks(1624));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 502, DateTimeKind.Utc).AddTicks(1625));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 502, DateTimeKind.Utc).AddTicks(1626));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 502, DateTimeKind.Utc).AddTicks(1627));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 502, DateTimeKind.Utc).AddTicks(1628));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 502, DateTimeKind.Utc).AddTicks(1811));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 502, DateTimeKind.Utc).AddTicks(1813));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 502, DateTimeKind.Utc).AddTicks(1814));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 502, DateTimeKind.Utc).AddTicks(1815));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 502, DateTimeKind.Utc).AddTicks(2164));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 502, DateTimeKind.Utc).AddTicks(2165));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 502, DateTimeKind.Utc).AddTicks(2166));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 502, DateTimeKind.Utc).AddTicks(5375));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 502, DateTimeKind.Utc).AddTicks(5378));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 502, DateTimeKind.Utc).AddTicks(5379));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PassWord" },
                values: new object[] { new DateTime(2026, 1, 2, 5, 9, 45, 832, DateTimeKind.Utc).AddTicks(1894), "$2a$11$Rn0obZJOWkc2zmw9ymgui.jUtSZej/tsl0XsoD6VFKB9p9YW9gdWK" });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyResourceBookingPermissions_CompanyId_ResourceTypeId_EmployeeType",
                table: "CompanyResourceBookingPermissions",
                columns: new[] { "CompanyId", "ResourceTypeId", "EmployeeType" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyResourceBookingPermissions_ResourceTypeId",
                table: "CompanyResourceBookingPermissions",
                column: "ResourceTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyResourceBookingPermissions");

            migrationBuilder.DropColumn(
                name: "Designation",
                table: "Employees");

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
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(1963));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(1965));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(1966));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(1968));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(1969));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(1970));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(1971));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(1972));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(1974));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(1975));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(1976));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(1977));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(1978));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(1979));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(1980));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(1981));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(1982));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(1983));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(1984));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(2067));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(2069));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(2070));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(2072));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(2073));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(2074));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(2076));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(2077));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(2078));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(2079));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(2080));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(2081));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(2082));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(2083));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(2084));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(2085));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(2087));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(2088));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(2089));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(2090));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(2091));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 30, 9, 26, 27, 182, DateTimeKind.Utc).AddTicks(2092));

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
    }
}
