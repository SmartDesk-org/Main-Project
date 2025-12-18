using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResourceFlow.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class Typetableedited : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "SubscriptionTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "SubscriptionTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "SubscriptionTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "SubscriptionTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SubscriptionTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "SubscriptionTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "SubscriptionTypes",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 18, 10, 5, 21, 952, DateTimeKind.Utc).AddTicks(6809));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 18, 10, 5, 21, 952, DateTimeKind.Utc).AddTicks(6815));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 18, 10, 5, 21, 952, DateTimeKind.Utc).AddTicks(6815));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsDeleted", "ModifiedAt", "ModifiedBy" },
                values: new object[] { new DateTime(2025, 12, 18, 10, 5, 21, 952, DateTimeKind.Utc).AddTicks(8038), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsDeleted", "ModifiedAt", "ModifiedBy" },
                values: new object[] { new DateTime(2025, 12, 18, 10, 5, 21, 952, DateTimeKind.Utc).AddTicks(8041), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsDeleted", "ModifiedAt", "ModifiedBy" },
                values: new object[] { new DateTime(2025, 12, 18, 10, 5, 21, 952, DateTimeKind.Utc).AddTicks(8042), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PassWord" },
                values: new object[] { new DateTime(2025, 12, 18, 10, 5, 22, 288, DateTimeKind.Utc).AddTicks(5442), "$2a$11$SP1OEDwPFs0SwvY8lbUZn.YjLzh7G.rLUCLonJaQdgrtgXs2o1r52" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "SubscriptionTypes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "SubscriptionTypes");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "SubscriptionTypes");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "SubscriptionTypes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SubscriptionTypes");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "SubscriptionTypes");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "SubscriptionTypes");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 18, 8, 27, 3, 444, DateTimeKind.Utc).AddTicks(7784));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 18, 8, 27, 3, 444, DateTimeKind.Utc).AddTicks(7790));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 18, 8, 27, 3, 444, DateTimeKind.Utc).AddTicks(7791));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PassWord" },
                values: new object[] { new DateTime(2025, 12, 18, 8, 27, 3, 837, DateTimeKind.Utc).AddTicks(3669), "$2a$11$Xyul7JxY8muyAvpDZfo4Ae/m8jgFaqgTtmSAnW5oqqCswbjJ01/Gm" });
        }
    }
}
