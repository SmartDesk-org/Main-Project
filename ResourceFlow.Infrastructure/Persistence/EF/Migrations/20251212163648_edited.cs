using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResourceFlow.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class edited : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Subscriptions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 12, 16, 36, 46, 659, DateTimeKind.Utc).AddTicks(7978));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 12, 16, 36, 46, 659, DateTimeKind.Utc).AddTicks(7984));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 12, 16, 36, 46, 659, DateTimeKind.Utc).AddTicks(7987));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PassWord" },
                values: new object[] { new DateTime(2025, 12, 12, 16, 36, 47, 64, DateTimeKind.Utc).AddTicks(905), "$2a$11$ZEXNSXRXpl0Uz3CapLP0aOTjLKCk1YX1DgWjunvQDNu5yJN741Qly" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Subscriptions");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 12, 16, 31, 16, 321, DateTimeKind.Utc).AddTicks(7810));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 12, 16, 31, 16, 321, DateTimeKind.Utc).AddTicks(7820));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 12, 16, 31, 16, 321, DateTimeKind.Utc).AddTicks(7823));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PassWord" },
                values: new object[] { new DateTime(2025, 12, 12, 16, 31, 16, 668, DateTimeKind.Utc).AddTicks(8680), "$2a$11$SHJxoMRoe.yoF4osObeQM.HiYgX5eh0mkOxa3M4/8s4fMbAevcoJC" });
        }
    }
}
