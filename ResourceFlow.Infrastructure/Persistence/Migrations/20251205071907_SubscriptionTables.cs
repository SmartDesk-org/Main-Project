using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ResourceFlow.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SubscriptionTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<DateTime>(
            //    name: "PasswordResetExpiry",
            //    table: "Users",
            //    type: "timestamp with time zone",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "PasswordResetToken",
            //    table: "Users",
            //    type: "text",
            //    nullable: true);

            //migrationBuilder.CreateTable(
            //    name: "CompanyDetails",
            //    columns: table => new
            //    {
            //        CompanyId = table.Column<int>(type: "integer", nullable: false)
            //            .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            //        Name = table.Column<string>(type: "text", nullable: false),
            //        Address = table.Column<string>(type: "text", nullable: false),
            //        IsActive = table.Column<bool>(type: "boolean", nullable: false),
            //        CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
            //        CreatedBy = table.Column<int>(type: "integer", nullable: false),
            //        ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
            //        ModifiedBy = table.Column<int>(type: "integer", nullable: false),
            //        DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
            //        DeletedBy = table.Column<int>(type: "integer", nullable: false),
            //        IsDelete = table.Column<bool>(type: "boolean", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CompanyDetails", x => x.CompanyId);
            //    });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ResourceName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SubscriptionName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ResourceId = table.Column<int>(type: "integer", nullable: false),
                    PriceMonthly = table.Column<double>(type: "double precision", nullable: false),
                    PriceYearly = table.Column<double>(type: "double precision", nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2025, 12, 5, 7, 19, 6, 571, DateTimeKind.Utc).AddTicks(7300));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2025, 12, 5, 7, 19, 6, 571, DateTimeKind.Utc).AddTicks(7304));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2025, 12, 5, 7, 19, 6, 571, DateTimeKind.Utc).AddTicks(7305));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreateAt", "PassWord", "PasswordResetExpiry", "PasswordResetToken" },
                values: new object[] { new DateTime(2025, 12, 5, 7, 19, 6, 890, DateTimeKind.Utc).AddTicks(6479), "$2a$11$sfi7K5RJB8KtYADhnnJ8lu9.q9Gd2KRgAZAVNFu/l/1n1tbDeEtEy", null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_ResourceId",
                table: "Subscriptions",
                column: "ResourceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyDetails");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropColumn(
                name: "PasswordResetExpiry",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordResetToken",
                table: "Users");

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
                columns: new[] { "CreateAt", "PassWord" },
                values: new object[] { new DateTime(2025, 12, 4, 11, 50, 38, 303, DateTimeKind.Utc).AddTicks(5386), "$2a$11$/QU3kBonqYcb2z7uOzl8Be/5SM/uqKrI8mXghCnjQgxg5fUrpA93G" });
        }
    }
}
