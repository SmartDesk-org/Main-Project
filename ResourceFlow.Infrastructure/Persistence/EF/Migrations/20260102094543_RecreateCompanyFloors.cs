using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ResourceFlow.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class RecreateCompanyFloors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppModules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_AppModules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppModules_AppModules_ParentId",
                        column: x => x.ParentId,
                        principalTable: "AppModules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ClientMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    IsImportant = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_ClientMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyDetails",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CompanySubscriptionId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_CompanyDetails", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Histories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    SubscriptionId = table.Column<int>(type: "int", nullable: false),
                    CompanySubscriptionId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AmountPaid = table.Column<double>(type: "float", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ChangeReason = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Histories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_SubscriptionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Billing",
                columns: table => new
                {
                    BillingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubscriptionId = table.Column<int>(type: "int", nullable: false),
                    SubscriptionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanySubscriptionId = table.Column<int>(type: "int", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    TransactionId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    BillingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubscriptionStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubscriptionEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvoicePdfPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Billing", x => x.BillingId);
                    table.ForeignKey(
                        name: "FK_Billing_CompanyDetails_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "CompanyDetails",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyFloors",
                columns: table => new
                {
                    FloorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FloorName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FloorNumber = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    Map = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
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
                    table.PrimaryKey("PK_CompanyFloors", x => x.FloorId);
                    table.ForeignKey(
                        name: "FK_CompanyFloors_CompanyDetails_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "CompanyDetails",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    PaymentIntentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiptId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", maxLength: 50, nullable: false),
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
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_CompanyDetails_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "CompanyDetails",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Resources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resources_CompanyDetails_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "CompanyDetails",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ModuleCode = table.Column<int>(type: "int", nullable: false),
                    View = table.Column<bool>(type: "bit", nullable: false),
                    Add = table.Column<bool>(type: "bit", nullable: false),
                    Edit = table.Column<bool>(type: "bit", nullable: false),
                    Delete = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_RolePermissions", x => new { x.RoleId, x.ModuleCode });
                    table.ForeignKey(
                        name: "FK_RolePermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PassWord = table.Column<string>(type: "nvarchar(260)", maxLength: 260, nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshTokenExpiry = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PasswordResetToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordResetExpiry = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    FailedLoginAttempts = table.Column<int>(type: "int", nullable: false),
                    LockoutEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastFailedLogin = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_CompanyDetails_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "CompanyDetails",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriptionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxEmployees = table.Column<int>(type: "int", nullable: false),
                    MaxFloors = table.Column<int>(type: "int", nullable: false),
                    MaxDesks = table.Column<int>(type: "int", nullable: false),
                    MaxMeetingRooms = table.Column<int>(type: "int", nullable: false),
                    PriceMonthly = table.Column<double>(type: "float", nullable: false),
                    PriceYearly = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    GracePeriodDays = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscriptions_SubscriptionTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "SubscriptionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyDesks",
                columns: table => new
                {
                    DeskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    FloorId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    XPosition = table.Column<float>(type: "real", nullable: false),
                    YPosition = table.Column<float>(type: "real", nullable: false),
                    SpecificationsJson = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_CompanyDesks", x => x.DeskId);
                    table.ForeignKey(
                        name: "FK_CompanyDesks_CompanyDetails_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "CompanyDetails",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyDesks_CompanyFloors_FloorId",
                        column: x => x.FloorId,
                        principalTable: "CompanyFloors",
                        principalColumn: "FloorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyMeetingRooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    FloorId = table.Column<int>(type: "int", nullable: false),
                    RoomName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    XPosition = table.Column<float>(type: "real", nullable: false),
                    YPosition = table.Column<float>(type: "real", nullable: false),
                    SpecificationsJson = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_CompanyMeetingRooms", x => x.RoomId);
                    table.ForeignKey(
                        name: "FK_CompanyMeetingRooms_CompanyDetails_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "CompanyDetails",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyMeetingRooms_CompanyFloors_FloorId",
                        column: x => x.FloorId,
                        principalTable: "CompanyFloors",
                        principalColumn: "FloorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    DefaultFloorId = table.Column<int>(type: "int", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
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
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_CompanyDetails_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "CompanyDetails",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotificationType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TargetChannel = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ReferenceType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReferenceId = table.Column<int>(type: "int", nullable: true),
                    SentAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsSent = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ReadAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRead = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RetryCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
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

            migrationBuilder.CreateTable(
                name: "CompanySubscription",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    SubscriptionId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AmoutToBePaid = table.Column<double>(type: "float", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_CompanySubscription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanySubscription_CompanyDetails_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "CompanyDetails",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanySubscription_Subscriptions_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "Subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppModules",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsDeleted", "ModifiedAt", "ModifiedBy", "Name", "ParentId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9207), null, null, null, false, null, null, "User Management", null },
                    { 2, 3, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9210), null, null, null, false, null, null, "Company Details", null },
                    { 6, 7, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9216), null, null, null, false, null, null, "Employee Management", null },
                    { 7, 8, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9217), null, null, null, false, null, null, "Subscription Plans", null },
                    { 14, 15, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9224), null, null, null, false, null, null, "Notifications", null },
                    { 15, 16, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9225), null, null, null, false, null, null, "Client Messages", null },
                    { 16, 2, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9226), null, null, null, false, null, null, "Roles", null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsDeleted", "ModifiedAt", "ModifiedBy", "RoleName" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9836), null, null, null, false, null, null, "SuperAdmin" },
                    { 2, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9838), null, null, null, false, null, null, "CompanyAdmin" },
                    { 3, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9839), null, null, null, false, null, null, "Employee" }
                });

            migrationBuilder.InsertData(
                table: "SubscriptionTypes",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsDeleted", "ModifiedAt", "ModifiedBy", "TypeName" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 2, 9, 45, 42, 182, DateTimeKind.Utc).AddTicks(1006), null, null, null, false, null, null, "Basic" },
                    { 2, new DateTime(2026, 1, 2, 9, 45, 42, 182, DateTimeKind.Utc).AddTicks(1009), null, null, null, false, null, null, "Upgrade" },
                    { 3, new DateTime(2026, 1, 2, 9, 45, 42, 182, DateTimeKind.Utc).AddTicks(1010), null, null, null, false, null, null, "Renewal" }
                });

            migrationBuilder.InsertData(
                table: "AppModules",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsDeleted", "ModifiedAt", "ModifiedBy", "Name", "ParentId" },
                values: new object[,]
                {
                    { 3, 4, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9212), null, null, null, false, null, null, "Company Floor", 2 },
                    { 4, 5, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9213), null, null, null, false, null, null, "Company Desk", 2 },
                    { 5, 6, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9214), null, null, null, false, null, null, "Company Meeting Room", 2 },
                    { 8, 9, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9218), null, null, null, false, null, null, "Resource Management", 7 },
                    { 9, 10, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9219), null, null, null, false, null, null, "Subscription Types", 7 },
                    { 10, 11, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9220), null, null, null, false, null, null, "Company Subscriptions", 7 }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "ModuleCode", "RoleId", "Add", "CreatedAt", "CreatedBy", "Delete", "DeletedAt", "DeletedBy", "Edit", "IsDeleted", "ModifiedAt", "ModifiedBy", "View" },
                values: new object[,]
                {
                    { 1, 1, true, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9577), null, true, null, null, true, false, null, null, true },
                    { 2, 1, true, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9570), null, true, null, null, true, false, null, null, true },
                    { 3, 1, true, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9572), null, true, null, null, true, false, null, null, true },
                    { 4, 1, false, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9579), null, false, null, null, false, false, null, null, true },
                    { 5, 1, false, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9578), null, false, null, null, false, false, null, null, true },
                    { 6, 1, false, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9580), null, false, null, null, false, false, null, null, true },
                    { 7, 1, false, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9574), null, false, null, null, false, false, null, null, true },
                    { 8, 1, true, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9561), null, true, null, null, true, false, null, null, true },
                    { 9, 1, true, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9584), null, true, null, null, true, false, null, null, true },
                    { 10, 1, true, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9583), null, true, null, null, true, false, null, null, true },
                    { 11, 1, false, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9573), null, true, null, null, true, false, null, null, true },
                    { 12, 1, false, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9576), null, false, null, null, false, false, null, null, true },
                    { 13, 1, false, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9575), null, false, null, null, false, false, null, null, true },
                    { 14, 1, false, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9582), null, false, null, null, false, false, null, null, true },
                    { 15, 1, true, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9572), null, true, null, null, true, false, null, null, true },
                    { 16, 1, false, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9581), null, true, null, null, true, false, null, null, true },
                    { 1, 2, true, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9590), null, false, null, null, true, false, null, null, true },
                    { 2, 2, false, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9595), null, false, null, null, false, false, null, null, false },
                    { 3, 2, true, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9586), null, true, null, null, true, false, null, null, true },
                    { 4, 2, true, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9592), null, true, null, null, true, false, null, null, true },
                    { 5, 2, true, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9591), null, true, null, null, true, false, null, null, true },
                    { 6, 2, true, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9593), null, true, null, null, true, false, null, null, true },
                    { 7, 2, true, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9588), null, true, null, null, true, false, null, null, true },
                    { 8, 2, false, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9585), null, false, null, null, false, false, null, null, true },
                    { 9, 2, true, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9599), null, true, null, null, true, false, null, null, true },
                    { 10, 2, false, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9598), null, false, null, null, false, false, null, null, true },
                    { 11, 2, false, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9586), null, false, null, null, false, false, null, null, true },
                    { 12, 2, true, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9589), null, false, null, null, false, false, null, null, true },
                    { 13, 2, false, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9588), null, false, null, null, false, false, null, null, true },
                    { 14, 2, false, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9597), null, false, null, null, false, false, null, null, true },
                    { 15, 2, true, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9594), null, true, null, null, true, false, null, null, true },
                    { 16, 2, true, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9596), null, false, null, null, false, false, null, null, true },
                    { 1, 3, false, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9606), null, false, null, null, true, false, null, null, true },
                    { 2, 3, false, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9610), null, false, null, null, false, false, null, null, false },
                    { 3, 3, false, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9601), null, false, null, null, false, false, null, null, true },
                    { 4, 3, false, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9607), null, false, null, null, false, false, null, null, true },
                    { 5, 3, false, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9606), null, false, null, null, false, false, null, null, true },
                    { 6, 3, false, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9608), null, false, null, null, false, false, null, null, true },
                    { 7, 3, false, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9603), null, false, null, null, true, false, null, null, true },
                    { 8, 3, false, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9600), null, false, null, null, false, false, null, null, true },
                    { 9, 3, false, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9614), null, false, null, null, false, false, null, null, false },
                    { 10, 3, false, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9613), null, false, null, null, false, false, null, null, false },
                    { 11, 3, false, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9602), null, false, null, null, false, false, null, null, false },
                    { 12, 3, false, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9605), null, false, null, null, false, false, null, null, false },
                    { 13, 3, false, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9604), null, false, null, null, false, false, null, null, false },
                    { 14, 3, false, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9612), null, false, null, null, false, false, null, null, false },
                    { 15, 3, false, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9609), null, false, null, null, false, false, null, null, true },
                    { 16, 3, false, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9611), null, false, null, null, false, false, null, null, false }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CompanyId", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Email", "FailedLoginAttempts", "IsActive", "IsBlocked", "IsDeleted", "LastFailedLogin", "LockoutEnd", "ModifiedAt", "ModifiedBy", "PassWord", "PasswordResetExpiry", "PasswordResetToken", "RefreshToken", "RefreshTokenExpiry", "RoleId", "UserName" },
                values: new object[] { 1, null, new DateTime(2026, 1, 2, 9, 45, 42, 491, DateTimeKind.Utc).AddTicks(9547), null, null, null, "suhailpalakkal1@gmail.com", 0, true, false, false, null, null, null, null, "$2a$11$6DRjYaDsb9w02zBCQcvCheq.l77Rrhm2pn6sNmq6v7QfnLKf0tpU2", null, null, "", null, 1, "Suhail" });

            migrationBuilder.InsertData(
                table: "AppModules",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsDeleted", "ModifiedAt", "ModifiedBy", "Name", "ParentId" },
                values: new object[,]
                {
                    { 11, 12, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9221), null, null, null, false, null, null, "Payment", 10 },
                    { 12, 13, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9222), null, null, null, false, null, null, "Billing", 10 },
                    { 13, 14, new DateTime(2026, 1, 2, 9, 45, 42, 181, DateTimeKind.Utc).AddTicks(9223), null, null, null, false, null, null, "Subscription History", 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppModules_ParentId",
                table: "AppModules",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Billing_CompanyId",
                table: "Billing",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyDesks_CompanyId_Status",
                table: "CompanyDesks",
                columns: new[] { "CompanyId", "Status" });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyDesks_FloorId",
                table: "CompanyDesks",
                column: "FloorId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyFloors_CompanyId_IsActive",
                table: "CompanyFloors",
                columns: new[] { "CompanyId", "IsActive" });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyMeetingRooms_CompanyId_Status",
                table: "CompanyMeetingRooms",
                columns: new[] { "CompanyId", "Status" });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyMeetingRooms_FloorId",
                table: "CompanyMeetingRooms",
                column: "FloorId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanySubscription_CompanyId",
                table: "CompanySubscription",
                column: "CompanyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompanySubscription_SubscriptionId",
                table: "CompanySubscription",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyId",
                table: "Employees",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId",
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

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CompanyId",
                table: "Payments",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_CompanyId",
                table: "Resources",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_TypeId",
                table: "Subscriptions",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CompanyId",
                table: "Users",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppModules");

            migrationBuilder.DropTable(
                name: "Billing");

            migrationBuilder.DropTable(
                name: "ClientMessages");

            migrationBuilder.DropTable(
                name: "CompanyDesks");

            migrationBuilder.DropTable(
                name: "CompanyMeetingRooms");

            migrationBuilder.DropTable(
                name: "CompanySubscription");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Histories");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "CompanyFloors");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "SubscriptionTypes");

            migrationBuilder.DropTable(
                name: "CompanyDetails");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
