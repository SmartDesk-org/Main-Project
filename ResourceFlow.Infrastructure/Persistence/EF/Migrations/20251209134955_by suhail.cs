using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResourceFlow.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class bysuhail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubscriptionName",
                table: "SubscriptionPlans",
                newName: "SubscriptionPlanName");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2025, 12, 9, 13, 49, 54, 424, DateTimeKind.Utc).AddTicks(6909));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2025, 12, 9, 13, 49, 54, 424, DateTimeKind.Utc).AddTicks(6912));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2025, 12, 9, 13, 49, 54, 424, DateTimeKind.Utc).AddTicks(6913));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreateAt", "PassWord" },
                values: new object[] { new DateTime(2025, 12, 9, 13, 49, 54, 594, DateTimeKind.Utc).AddTicks(2935), "$2a$11$eZX/SL3HwnzUGizG2swhfu7y7pDJY/UVuJPfqDu6z4xjVqdDCP6Sq" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubscriptionPlanName",
                table: "SubscriptionPlans",
                newName: "SubscriptionName");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2025, 12, 9, 13, 39, 57, 0, DateTimeKind.Utc).AddTicks(9336));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2025, 12, 9, 13, 39, 57, 0, DateTimeKind.Utc).AddTicks(9342));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2025, 12, 9, 13, 39, 57, 0, DateTimeKind.Utc).AddTicks(9345));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreateAt", "PassWord" },
                values: new object[] { new DateTime(2025, 12, 9, 13, 39, 57, 263, DateTimeKind.Utc).AddTicks(2152), "$2a$11$3.3DBOxwmtphSb2Rr0LDvu6Fyl7/eo/gDBEhIzNW6NbX54hldWz0i" });
        }
    }
}
