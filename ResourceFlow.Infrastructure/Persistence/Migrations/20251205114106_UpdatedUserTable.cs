using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResourceFlow.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PassWord",
                table: "Users",
                type: "character varying(260)",
                maxLength: 260,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Users",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2025, 12, 5, 11, 41, 4, 990, DateTimeKind.Utc).AddTicks(1180));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2025, 12, 5, 11, 41, 4, 990, DateTimeKind.Utc).AddTicks(1184));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2025, 12, 5, 11, 41, 4, 990, DateTimeKind.Utc).AddTicks(1186));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CompanyId", "CreateAt", "PassWord", "UserName" },
                values: new object[] { null, new DateTime(2025, 12, 5, 11, 41, 5, 284, DateTimeKind.Utc).AddTicks(841), "$2a$11$VMyEXLh3.rs/b5BlUaBu9ORdwHPT4oQXBfu2U52Mtw4/aqBzmab8S", "Suhail" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_CompanyId",
                table: "Users",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_CompanyDetails_CompanyId",
                table: "Users",
                column: "CompanyId",
                principalTable: "CompanyDetails",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_CompanyDetails_CompanyId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CompanyId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "PassWord",
                table: "Users",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(260)",
                oldMaxLength: 260);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2025, 12, 5, 10, 19, 51, 32, DateTimeKind.Utc).AddTicks(1588));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2025, 12, 5, 10, 19, 51, 32, DateTimeKind.Utc).AddTicks(1591));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2025, 12, 5, 10, 19, 51, 32, DateTimeKind.Utc).AddTicks(1592));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreateAt", "PassWord" },
                values: new object[] { new DateTime(2025, 12, 5, 10, 19, 51, 360, DateTimeKind.Utc).AddTicks(298), "$2a$11$gt9fJ3gr55S29v9qaGSHTewNfIWxzcxZby.d.lJRNzRuhOmzCdy6G" });
        }
    }
}
