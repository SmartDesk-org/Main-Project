using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ResourceFlow.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EmployeesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CompanyId = table.Column<int>(type: "integer", nullable: false),
                    DefaultFloorId = table.Column<int>(type: "integer", nullable: false),
                    Department = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<int>(type: "integer", nullable: false),
                    IsDelete = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2025, 12, 4, 11, 50, 38, 148, DateTimeKind.Utc).AddTicks(7720));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2025, 12, 4, 11, 50, 38, 148, DateTimeKind.Utc).AddTicks(7724));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2025, 12, 4, 11, 50, 38, 148, DateTimeKind.Utc).AddTicks(7725));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreateAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsDelete", "ModifiedAt", "ModifiedBy", "PassWord" },
                values: new object[] { new DateTime(2025, 12, 4, 11, 50, 38, 303, DateTimeKind.Utc).AddTicks(5386), 0, null, 0, false, null, 0, "$2a$11$/QU3kBonqYcb2z7uOzl8Be/5SM/uqKrI8mXghCnjQgxg5fUrpA93G" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2025, 12, 3, 10, 12, 53, 955, DateTimeKind.Utc).AddTicks(2960));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2025, 12, 3, 10, 12, 53, 955, DateTimeKind.Utc).AddTicks(2968));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2025, 12, 3, 10, 12, 53, 955, DateTimeKind.Utc).AddTicks(2971));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "PassWord",
                value: "$2a$11$05MuUUsS6mX1ptgHhGQDG.VEOAWMkQolysUh8Y4LPn1P2MKXnt1Xa");
        }
    }
}
