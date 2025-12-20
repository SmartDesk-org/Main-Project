using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResourceFlow.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class editedbillingaddednameandmailforcomapny : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyMail",
                table: "Billing",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Billing",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubscriptionName",
                table: "Billing",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 20, 6, 25, 30, 340, DateTimeKind.Utc).AddTicks(3841));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 20, 6, 25, 30, 340, DateTimeKind.Utc).AddTicks(3846));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 20, 6, 25, 30, 340, DateTimeKind.Utc).AddTicks(3848));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 20, 6, 25, 30, 340, DateTimeKind.Utc).AddTicks(7728));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 20, 6, 25, 30, 340, DateTimeKind.Utc).AddTicks(7733));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 20, 6, 25, 30, 340, DateTimeKind.Utc).AddTicks(7734));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PassWord" },
                values: new object[] { new DateTime(2025, 12, 20, 6, 25, 30, 820, DateTimeKind.Utc).AddTicks(4835), "$2a$11$kN4i6tbJRnMxzD5PXSVenukS0Pev.vRqX4jqGD7LU7cfVkRvCJYWq" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyMail",
                table: "Billing");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Billing");

            migrationBuilder.DropColumn(
                name: "SubscriptionName",
                table: "Billing");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 11, 21, 29, 873, DateTimeKind.Utc).AddTicks(6600));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 11, 21, 29, 873, DateTimeKind.Utc).AddTicks(6605));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 11, 21, 29, 873, DateTimeKind.Utc).AddTicks(6606));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 11, 21, 29, 873, DateTimeKind.Utc).AddTicks(8498));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 11, 21, 29, 873, DateTimeKind.Utc).AddTicks(8501));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 11, 21, 29, 873, DateTimeKind.Utc).AddTicks(8503));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PassWord" },
                values: new object[] { new DateTime(2025, 12, 19, 11, 21, 30, 476, DateTimeKind.Utc).AddTicks(8061), "$2a$11$Fmfikrtin3ELMiyjcFF0JOnBC1AoZwW27VYo5Gfdr7FctFBbPFPYa" });
        }
    }
}
