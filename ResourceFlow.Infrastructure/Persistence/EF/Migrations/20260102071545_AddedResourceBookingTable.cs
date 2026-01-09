using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResourceFlow.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddedResourceBookingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "resourceBookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    ResourceId = table.Column<int>(type: "int", nullable: false),
                    ResourceTypeId = table.Column<int>(type: "int", nullable: false),
                    BookedByUserId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_resourceBookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_resourceBookings_CompanyDetails_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "CompanyDetails",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_resourceBookings_ResourceTypes_ResourceTypeId",
                        column: x => x.ResourceTypeId,
                        principalTable: "ResourceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_resourceBookings_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(4964));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(4968));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(4969));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(4971));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(4974));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(4975));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(4976));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(5098));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(5099));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(5100));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(5101));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(5102));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(5104));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(5105));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(5106));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(5124));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(5125));

            migrationBuilder.UpdateData(
                table: "AppModules",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(5126));

            migrationBuilder.UpdateData(
                table: "CompanyResourceBookingPermissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(5672));

            migrationBuilder.UpdateData(
                table: "CompanyResourceBookingPermissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(5675));

            migrationBuilder.UpdateData(
                table: "ResourceTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(8532));

            migrationBuilder.UpdateData(
                table: "ResourceTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(8535));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(8981));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(8986));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(8991));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(8995));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(8996));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(8998));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9001));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9002));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9006));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9009));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9198));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9200));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9201));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9202));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9204));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9205));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9206));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9208));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9209));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9211));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9213));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9215));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9216));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9218));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9219));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9221));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9222));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9224));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9225));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9228));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9229));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9230));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9232));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9233));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9235));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9236));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9237));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9239));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9240));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9241));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9589));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9590));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 218, DateTimeKind.Utc).AddTicks(9591));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 219, DateTimeKind.Utc).AddTicks(1783));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 219, DateTimeKind.Utc).AddTicks(1785));

            migrationBuilder.UpdateData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 7, 15, 44, 219, DateTimeKind.Utc).AddTicks(1787));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PassWord" },
                values: new object[] { new DateTime(2026, 1, 2, 7, 15, 44, 548, DateTimeKind.Utc).AddTicks(389), "$2a$11$XallUFBJnK7TGROK2E5ld.c9lkL9T1IibpLD67jFxqa9X33zsgASq" });

            migrationBuilder.CreateIndex(
                name: "IX_resourceBookings_CompanyId",
                table: "resourceBookings",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_resourceBookings_ResourceId_StartTime_EndTime",
                table: "resourceBookings",
                columns: new[] { "ResourceId", "StartTime", "EndTime" });

            migrationBuilder.CreateIndex(
                name: "IX_resourceBookings_ResourceTypeId",
                table: "resourceBookings",
                column: "ResourceTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "resourceBookings");

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

            migrationBuilder.UpdateData(
                table: "CompanyResourceBookingPermissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 501, DateTimeKind.Utc).AddTicks(5650));

            migrationBuilder.UpdateData(
                table: "CompanyResourceBookingPermissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 5, 9, 45, 501, DateTimeKind.Utc).AddTicks(5652));

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
        }
    }
}
