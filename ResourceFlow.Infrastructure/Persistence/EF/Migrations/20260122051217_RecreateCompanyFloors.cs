using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResourceFlow.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class RecreateCompanyFloors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_resourceBookings_QRCodeValue",
                table: "resourceBookings");

            migrationBuilder.DropColumn(
                name: "Scope",
                table: "RolePermissions");

            migrationBuilder.AlterColumn<string>(
                name: "QRCodeValue",
                table: "resourceBookings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 656, DateTimeKind.Utc).AddTicks(9161));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 656, DateTimeKind.Utc).AddTicks(9163));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 656, DateTimeKind.Utc).AddTicks(9164));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 656, DateTimeKind.Utc).AddTicks(9165));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 656, DateTimeKind.Utc).AddTicks(9166));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 656, DateTimeKind.Utc).AddTicks(9167));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 656, DateTimeKind.Utc).AddTicks(9168));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 656, DateTimeKind.Utc).AddTicks(9169));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 656, DateTimeKind.Utc).AddTicks(9170));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 656, DateTimeKind.Utc).AddTicks(9171));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 656, DateTimeKind.Utc).AddTicks(9172));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 656, DateTimeKind.Utc).AddTicks(9173));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 656, DateTimeKind.Utc).AddTicks(9174));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 656, DateTimeKind.Utc).AddTicks(9175));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 656, DateTimeKind.Utc).AddTicks(9176));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 656, DateTimeKind.Utc).AddTicks(9190));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 656, DateTimeKind.Utc).AddTicks(9191));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 656, DateTimeKind.Utc).AddTicks(9192));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 656, DateTimeKind.Utc).AddTicks(9193));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 656, DateTimeKind.Utc).AddTicks(9194));

            migrationBuilder.UpdateData(
                table: "ResourceTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(3942));

            migrationBuilder.UpdateData(
                table: "ResourceTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(3944));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(4200));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(4202));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(4335));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(4338));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(4339));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(4340));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(4341));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(4343));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(4344));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(4345));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(4346));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(4347));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(4348));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(4349));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(4350));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(4351));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(4352));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(4353));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(4354));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(4356));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(4357));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(4358));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(4359));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(4361));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(4362));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(4363));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(4364));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(4365));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(4366));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(4367));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(4368));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(4369));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(4372));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(4374));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(4375));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(4376));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(4377));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(4378));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(4379));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(4380));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(4381));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(4370));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(4371));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(4382));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(4603));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(4604));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(4605));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(5822));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(5824));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(5824));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PassWord" },
                values: new object[] { new DateTime(2026, 1, 22, 5, 12, 15, 996, DateTimeKind.Utc).AddTicks(5676), "$2a$11$qXIeXei0DiU/RvVSPPzZXurVNCERRu35SZuC07CGSEBEb9wdQ6KnG" });

            migrationBuilder.UpdateData(
                table: "employeeType",
                keyColumn: "EmployeeTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(2386));

            migrationBuilder.UpdateData(
                table: "employeeType",
                keyColumn: "EmployeeTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(2390));

            migrationBuilder.UpdateData(
                table: "employeeType",
                keyColumn: "EmployeeTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(2391));

            migrationBuilder.UpdateData(
                table: "employeeType",
                keyColumn: "EmployeeTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(2391));

            migrationBuilder.UpdateData(
                table: "employeeType",
                keyColumn: "EmployeeTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(2392));

            migrationBuilder.UpdateData(
                table: "employeeType",
                keyColumn: "EmployeeTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(2393));

            migrationBuilder.UpdateData(
                table: "employeeType",
                keyColumn: "EmployeeTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(2394));

            migrationBuilder.UpdateData(
                table: "employeeType",
                keyColumn: "EmployeeTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(2395));

            migrationBuilder.UpdateData(
                table: "employeeType",
                keyColumn: "EmployeeTypeId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(2395));

            migrationBuilder.UpdateData(
                table: "employeeType",
                keyColumn: "EmployeeTypeId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 5, 12, 15, 657, DateTimeKind.Utc).AddTicks(2396));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Scope",
                table: "RolePermissions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "QRCodeValue",
                table: "resourceBookings",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsSent = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    NotificationType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ReadAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReferenceId = table.Column<int>(type: "int", nullable: true),
                    ReferenceType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RetryCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    SentAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TargetChannel = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_CompanyDetails_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "CompanyDetails",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Notifications_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 0, 35, 39, 967, DateTimeKind.Utc).AddTicks(8817));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 0, 35, 39, 967, DateTimeKind.Utc).AddTicks(8819));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 0, 35, 39, 967, DateTimeKind.Utc).AddTicks(8820));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 0, 35, 39, 967, DateTimeKind.Utc).AddTicks(8822));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 0, 35, 39, 967, DateTimeKind.Utc).AddTicks(8823));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 0, 35, 39, 967, DateTimeKind.Utc).AddTicks(8824));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 0, 35, 39, 967, DateTimeKind.Utc).AddTicks(8825));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 0, 35, 39, 967, DateTimeKind.Utc).AddTicks(8826));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 0, 35, 39, 967, DateTimeKind.Utc).AddTicks(8828));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 0, 35, 39, 967, DateTimeKind.Utc).AddTicks(8829));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 0, 35, 39, 967, DateTimeKind.Utc).AddTicks(8830));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 0, 35, 39, 967, DateTimeKind.Utc).AddTicks(8832));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 0, 35, 39, 967, DateTimeKind.Utc).AddTicks(8833));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 0, 35, 39, 967, DateTimeKind.Utc).AddTicks(8834));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 0, 35, 39, 967, DateTimeKind.Utc).AddTicks(8836));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 0, 35, 39, 967, DateTimeKind.Utc).AddTicks(8855));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 0, 35, 39, 967, DateTimeKind.Utc).AddTicks(8856));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 0, 35, 39, 967, DateTimeKind.Utc).AddTicks(8857));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 0, 35, 39, 967, DateTimeKind.Utc).AddTicks(8937));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 0, 35, 39, 967, DateTimeKind.Utc).AddTicks(8938));

            migrationBuilder.UpdateData(
                table: "ResourceTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5428));

            migrationBuilder.UpdateData(
                table: "ResourceTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5430));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5884), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5886), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5892), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5894), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5895), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5897), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5899), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5901), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5903), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5904), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5906), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5908), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5909), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5910), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5912), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5913), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5915), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5916), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5918), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5919), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5921), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5923), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5925), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5927), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5929), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5931), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5932), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5934), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5936), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5937), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5939), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5940), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5945), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5946), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5948), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5950), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5951), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5952), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5954), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5956), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5957), 1 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5941), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5943), 0 });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "Scope" },
                values: new object[] { new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5959), 0 });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(6305));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(6357));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(6358));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(8548));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(8552));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(8554));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PassWord" },
                values: new object[] { new DateTime(2026, 1, 20, 0, 35, 40, 304, DateTimeKind.Utc).AddTicks(4900), "$2a$11$cmbX8xn4JxolDIXT0SUHK.mtucCWqSfacln.t3E6x/efcnYgmdN5W" });

            migrationBuilder.UpdateData(
                table: "employeeType",
                keyColumn: "EmployeeTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(2843));

            migrationBuilder.UpdateData(
                table: "employeeType",
                keyColumn: "EmployeeTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(2846));

            migrationBuilder.UpdateData(
                table: "employeeType",
                keyColumn: "EmployeeTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(2848));

            migrationBuilder.UpdateData(
                table: "employeeType",
                keyColumn: "EmployeeTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(2849));

            migrationBuilder.UpdateData(
                table: "employeeType",
                keyColumn: "EmployeeTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(2850));

            migrationBuilder.UpdateData(
                table: "employeeType",
                keyColumn: "EmployeeTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(2852));

            migrationBuilder.UpdateData(
                table: "employeeType",
                keyColumn: "EmployeeTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(2853));

            migrationBuilder.UpdateData(
                table: "employeeType",
                keyColumn: "EmployeeTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(2854));

            migrationBuilder.UpdateData(
                table: "employeeType",
                keyColumn: "EmployeeTypeId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(2856));

            migrationBuilder.UpdateData(
                table: "employeeType",
                keyColumn: "EmployeeTypeId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(2857));

            migrationBuilder.CreateIndex(
                name: "IX_resourceBookings_QRCodeValue",
                table: "resourceBookings",
                column: "QRCodeValue",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_CompanyId",
                table: "Notifications",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_RoleId",
                table: "Notifications",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");
        }
    }
}
