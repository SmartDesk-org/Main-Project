using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ResourceFlow.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class InitialSetup : Migration
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
                name: "employeeType",
                columns: table => new
                {
                    EmployeeTypeId = table.Column<int>(type: "int", nullable: false)
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
                    table.PrimaryKey("PK_employeeType", x => x.EmployeeTypeId);
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
                name: "ResourceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefaultWidth = table.Column<int>(type: "int", nullable: false),
                    DefaultHeight = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_ResourceTypes", x => x.Id);
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
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    FloorName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FloorNumber = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Scale = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_CompanyDetails_CompanyId",
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
                name: "CompanyResourceBookingPermissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    ResourceTypeId = table.Column<int>(type: "int", nullable: false),
                    EmployeeTypeId = table.Column<int>(type: "int", nullable: false),
                    CanBook = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
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
                    table.PrimaryKey("PK_CompanyResourceBookingPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyResourceBookingPermissions_ResourceTypes_ResourceTypeId",
                        column: x => x.ResourceTypeId,
                        principalTable: "ResourceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyResourceBookingPermissions_employeeType_EmployeeTypeId",
                        column: x => x.EmployeeTypeId,
                        principalTable: "employeeType",
                        principalColumn: "EmployeeTypeId",
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
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    FloorId = table.Column<int>(type: "int", nullable: false),
                    ResourceTypeId = table.Column<int>(type: "int", nullable: false),
                    X = table.Column<int>(type: "int", nullable: false),
                    Y = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Rotation = table.Column<int>(type: "int", nullable: false),
                    MetadataJson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    QRCodeValue = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    QRCodeImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Resources_CompanyFloors_FloorId",
                        column: x => x.FloorId,
                        principalTable: "CompanyFloors",
                        principalColumn: "FloorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resources_ResourceTypes_ResourceTypeId",
                        column: x => x.ResourceTypeId,
                        principalTable: "ResourceTypes",
                        principalColumn: "Id");
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
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "RolePermissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    ModuleCode = table.Column<int>(type: "int", nullable: false),
                    Scope = table.Column<int>(type: "int", nullable: false),
                    View = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Add = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Edit = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Delete = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
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
                    table.PrimaryKey("PK_RolePermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
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
                    EmployeesLimit = table.Column<int>(type: "int", nullable: false),
                    FloorsLimit = table.Column<int>(type: "int", nullable: false),
                    DesksLimit = table.Column<int>(type: "int", nullable: false),
                    MeetingRoomsLimit = table.Column<int>(type: "int", nullable: false),
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
                    IsCheckedIn = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CheckInTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CheckOutTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    QRCodeValue = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    QrExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false),
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

            migrationBuilder.InsertData(
                table: "AppModules",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsDeleted", "ModifiedAt", "ModifiedBy", "Name", "ParentId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 1, 20, 0, 35, 39, 967, DateTimeKind.Utc).AddTicks(8817), null, null, null, false, null, null, "User Management", null },
                    { 2, 3, new DateTime(2026, 1, 20, 0, 35, 39, 967, DateTimeKind.Utc).AddTicks(8819), null, null, null, false, null, null, "Company Details", null },
                    { 4, 5, new DateTime(2026, 1, 20, 0, 35, 39, 967, DateTimeKind.Utc).AddTicks(8822), null, null, null, false, null, null, "Resource Type", null },
                    { 5, 6, new DateTime(2026, 1, 20, 0, 35, 39, 967, DateTimeKind.Utc).AddTicks(8823), null, null, null, false, null, null, "FeedBack", null },
                    { 6, 7, new DateTime(2026, 1, 20, 0, 35, 39, 967, DateTimeKind.Utc).AddTicks(8824), null, null, null, false, null, null, "Employee Management", null },
                    { 7, 8, new DateTime(2026, 1, 20, 0, 35, 39, 967, DateTimeKind.Utc).AddTicks(8825), null, null, null, false, null, null, "Subscription Plans", null },
                    { 14, 15, new DateTime(2026, 1, 20, 0, 35, 39, 967, DateTimeKind.Utc).AddTicks(8834), null, null, null, false, null, null, "Notifications", null },
                    { 15, 16, new DateTime(2026, 1, 20, 0, 35, 39, 967, DateTimeKind.Utc).AddTicks(8836), null, null, null, false, null, null, "Client Messages", null },
                    { 16, 2, new DateTime(2026, 1, 20, 0, 35, 39, 967, DateTimeKind.Utc).AddTicks(8855), null, null, null, false, null, null, "Roles", null },
                    { 17, 17, new DateTime(2026, 1, 20, 0, 35, 39, 967, DateTimeKind.Utc).AddTicks(8856), null, null, null, false, null, null, "AppModules", null },
                    { 19, 19, new DateTime(2026, 1, 20, 0, 35, 39, 967, DateTimeKind.Utc).AddTicks(8937), null, null, null, false, null, null, "Resource Booking Permission", null },
                    { 20, 20, new DateTime(2026, 1, 20, 0, 35, 39, 967, DateTimeKind.Utc).AddTicks(8938), null, null, null, false, null, null, "Resource Booking", null }
                });

            migrationBuilder.InsertData(
                table: "ResourceTypes",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultHeight", "DefaultWidth", "DeletedAt", "DeletedBy", "Icon", "IsActive", "IsDeleted", "ModifiedAt", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5428), null, 60, 60, null, null, "desk.png", true, false, null, null, "Desk" },
                    { 2, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5430), null, 120, 120, null, null, "meetingroom.png", true, false, null, null, "MeetingRoom" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsDeleted", "ModifiedAt", "ModifiedBy", "RoleName" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(6305), null, null, null, false, null, null, "SuperAdmin" },
                    { 2, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(6357), null, null, null, false, null, null, "CompanyAdmin" },
                    { 3, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(6358), null, null, null, false, null, null, "Employee" }
                });

            migrationBuilder.InsertData(
                table: "SubscriptionTypes",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsDeleted", "ModifiedAt", "ModifiedBy", "TypeName" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(8548), null, null, null, false, null, null, "Basic" },
                    { 2, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(8552), null, null, null, false, null, null, "Upgrade" },
                    { 3, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(8554), null, null, null, false, null, null, "Renewal" }
                });

            migrationBuilder.InsertData(
                table: "employeeType",
                columns: new[] { "EmployeeTypeId", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsDeleted", "ModifiedAt", "ModifiedBy", "TypeName" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(2843), null, null, null, false, null, null, "JuniorDeveloper" },
                    { 2, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(2846), null, null, null, false, null, null, "MidLevelDeveloper" },
                    { 3, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(2848), null, null, null, false, null, null, "SeniorDeveloper" },
                    { 4, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(2849), null, null, null, false, null, null, "LeadDeveloper" },
                    { 5, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(2850), null, null, null, false, null, null, "TeamLead" },
                    { 6, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(2852), null, null, null, false, null, null, "DevelopmentManager" },
                    { 7, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(2853), null, null, null, false, null, null, "ProjectManager" },
                    { 8, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(2854), null, null, null, false, null, null, "SoftwareArchitect" },
                    { 9, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(2856), null, null, null, false, null, null, "QAEngineer" },
                    { 10, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(2857), null, null, null, false, null, null, "DevOpsEngineer" }
                });

            migrationBuilder.InsertData(
                table: "AppModules",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsDeleted", "ModifiedAt", "ModifiedBy", "Name", "ParentId" },
                values: new object[,]
                {
                    { 3, 4, new DateTime(2026, 1, 20, 0, 35, 39, 967, DateTimeKind.Utc).AddTicks(8820), null, null, null, false, null, null, "Company Floor", 2 },
                    { 8, 9, new DateTime(2026, 1, 20, 0, 35, 39, 967, DateTimeKind.Utc).AddTicks(8826), null, null, null, false, null, null, "Resource Management", 7 },
                    { 9, 10, new DateTime(2026, 1, 20, 0, 35, 39, 967, DateTimeKind.Utc).AddTicks(8828), null, null, null, false, null, null, "Subscription Types", 7 },
                    { 10, 11, new DateTime(2026, 1, 20, 0, 35, 39, 967, DateTimeKind.Utc).AddTicks(8829), null, null, null, false, null, null, "Company Subscriptions", 7 },
                    { 18, 18, new DateTime(2026, 1, 20, 0, 35, 39, 967, DateTimeKind.Utc).AddTicks(8857), null, null, null, false, null, null, "Role Permission", 17 }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "Add", "CreatedAt", "CreatedBy", "Delete", "DeletedAt", "DeletedBy", "Edit", "IsDeleted", "ModifiedAt", "ModifiedBy", "ModuleCode", "RoleId", "Scope", "UserId", "View" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5884), null, true, null, null, true, false, null, null, 8, 1, 1, null, true },
                    { 2, true, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5886), null, true, null, null, true, false, null, null, 2, 1, 1, null, true },
                    { 3, true, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5892), null, true, null, null, true, false, null, null, 15, 1, 1, null, true },
                    { 4, true, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5894), null, true, null, null, true, false, null, null, 3, 1, 1, null, true },
                    { 5, true, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5895), null, true, null, null, true, false, null, null, 10, 1, 1, null, true },
                    { 6, true, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5897), null, true, null, null, true, false, null, null, 9, 1, 1, null, true },
                    { 7, true, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5899), null, true, null, null, true, false, null, null, 1, 1, 1, null, true },
                    { 8, true, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5901), null, true, null, null, true, false, null, null, 17, 1, 1, null, true },
                    { 9, true, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5903), null, true, null, null, true, false, null, null, 18, 1, 1, null, true }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Delete", "DeletedAt", "DeletedBy", "Edit", "IsDeleted", "ModifiedAt", "ModifiedBy", "ModuleCode", "RoleId", "Scope", "UserId", "View" },
                values: new object[,]
                {
                    { 10, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5904), null, true, null, null, true, false, null, null, 16, 1, 1, null, true },
                    { 11, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5906), null, true, null, null, true, false, null, null, 11, 1, 1, null, true }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsDeleted", "ModifiedAt", "ModifiedBy", "ModuleCode", "RoleId", "Scope", "UserId", "View" },
                values: new object[,]
                {
                    { 12, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5908), null, null, null, false, null, null, 7, 1, 1, null, true },
                    { 13, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5909), null, null, null, false, null, null, 13, 1, 1, null, true },
                    { 14, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5910), null, null, null, false, null, null, 12, 1, 1, null, true },
                    { 15, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5912), null, null, null, false, null, null, 4, 1, 1, null, true },
                    { 16, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5913), null, null, null, false, null, null, 14, 1, 1, null, true },
                    { 17, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5915), null, null, null, false, null, null, 5, 1, 1, null, true },
                    { 18, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5916), null, null, null, false, null, null, 6, 1, 1, null, true }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "Add", "CreatedAt", "CreatedBy", "Delete", "DeletedAt", "DeletedBy", "Edit", "IsDeleted", "ModifiedAt", "ModifiedBy", "ModuleCode", "RoleId", "Scope", "UserId", "View" },
                values: new object[,]
                {
                    { 19, true, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5918), null, true, null, null, true, false, null, null, 3, 2, 0, null, true },
                    { 20, true, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5919), null, true, null, null, true, false, null, null, 4, 2, 0, null, true },
                    { 21, true, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5921), null, true, null, null, true, false, null, null, 15, 2, 0, null, true },
                    { 22, true, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5923), null, true, null, null, true, false, null, null, 7, 2, 0, null, true },
                    { 23, true, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5925), null, true, null, null, true, false, null, null, 5, 2, 0, null, true }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "Add", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Edit", "IsDeleted", "ModifiedAt", "ModifiedBy", "ModuleCode", "RoleId", "Scope", "UserId", "View" },
                values: new object[,]
                {
                    { 24, true, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5927), null, null, null, true, false, null, null, 12, 2, 0, null, true },
                    { 25, true, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5929), null, null, null, true, false, null, null, 1, 2, 0, null, true }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "Add", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsDeleted", "ModifiedAt", "ModifiedBy", "ModuleCode", "RoleId", "Scope", "UserId", "View" },
                values: new object[,]
                {
                    { 26, true, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5931), null, null, null, false, null, null, 16, 2, 0, null, true },
                    { 27, true, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5932), null, null, null, false, null, null, 6, 2, 0, null, true }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsDeleted", "ModifiedAt", "ModifiedBy", "ModuleCode", "RoleId", "Scope", "UserId", "View" },
                values: new object[,]
                {
                    { 28, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5934), null, null, null, false, null, null, 14, 2, 0, null, true },
                    { 29, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5936), null, null, null, false, null, null, 11, 2, 0, null, true },
                    { 30, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5937), null, null, null, false, null, null, 13, 2, 0, null, true },
                    { 31, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5939), null, null, null, false, null, null, 8, 2, 1, null, true },
                    { 32, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5940), null, null, null, false, null, null, 10, 2, 1, null, true }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Edit", "IsDeleted", "ModifiedAt", "ModifiedBy", "ModuleCode", "RoleId", "Scope", "UserId", "View" },
                values: new object[,]
                {
                    { 33, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5945), null, null, null, true, false, null, null, 7, 3, 0, null, true },
                    { 34, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5946), null, null, null, true, false, null, null, 1, 3, 0, null, true }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "Add", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsDeleted", "ModifiedAt", "ModifiedBy", "ModuleCode", "RoleId", "Scope", "UserId", "View" },
                values: new object[] { 35, true, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5948), null, null, null, false, null, null, 6, 3, 0, null, true });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsDeleted", "ModifiedAt", "ModifiedBy", "ModuleCode", "RoleId", "Scope", "UserId", "View" },
                values: new object[,]
                {
                    { 36, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5950), null, null, null, false, null, null, 5, 3, 0, null, true },
                    { 37, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5951), null, null, null, false, null, null, 3, 3, 0, null, true },
                    { 38, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5952), null, null, null, false, null, null, 11, 3, 0, null, true },
                    { 39, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5954), null, null, null, false, null, null, 4, 3, 0, null, true },
                    { 40, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5956), null, null, null, false, null, null, 15, 3, 0, null, true },
                    { 41, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5957), null, null, null, false, null, null, 8, 3, 1, null, true }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "Add", "CreatedAt", "CreatedBy", "Delete", "DeletedAt", "DeletedBy", "Edit", "IsDeleted", "ModifiedAt", "ModifiedBy", "ModuleCode", "RoleId", "Scope", "UserId", "View" },
                values: new object[,]
                {
                    { 42, true, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5941), null, true, null, null, true, false, null, null, 19, 2, 0, null, true },
                    { 43, true, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5943), null, true, null, null, true, false, null, null, 20, 2, 0, null, true },
                    { 44, true, new DateTime(2026, 1, 20, 0, 35, 39, 968, DateTimeKind.Utc).AddTicks(5959), null, true, null, null, true, false, null, null, 20, 3, 0, null, true }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CompanyId", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Email", "FailedLoginAttempts", "IsActive", "IsBlocked", "IsDeleted", "LastFailedLogin", "LockoutEnd", "ModifiedAt", "ModifiedBy", "PassWord", "PasswordResetExpiry", "PasswordResetToken", "RefreshToken", "RefreshTokenExpiry", "RoleId", "UserName" },
                values: new object[] { 1, null, new DateTime(2026, 1, 20, 0, 35, 40, 304, DateTimeKind.Utc).AddTicks(4900), null, null, null, "suhailpalakkal1@gmail.com", 0, true, false, false, null, null, null, null, "$2a$11$cmbX8xn4JxolDIXT0SUHK.mtucCWqSfacln.t3E6x/efcnYgmdN5W", null, null, "", null, 1, "Suhail" });

            migrationBuilder.InsertData(
                table: "AppModules",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsDeleted", "ModifiedAt", "ModifiedBy", "Name", "ParentId" },
                values: new object[,]
                {
                    { 11, 12, new DateTime(2026, 1, 20, 0, 35, 39, 967, DateTimeKind.Utc).AddTicks(8830), null, null, null, false, null, null, "Payment", 10 },
                    { 12, 13, new DateTime(2026, 1, 20, 0, 35, 39, 967, DateTimeKind.Utc).AddTicks(8832), null, null, null, false, null, null, "Billing", 10 },
                    { 13, 14, new DateTime(2026, 1, 20, 0, 35, 39, 967, DateTimeKind.Utc).AddTicks(8833), null, null, null, false, null, null, "Subscription History", 10 }
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
                name: "IX_CompanyFloors_CompanyId_IsActive",
                table: "CompanyFloors",
                columns: new[] { "CompanyId", "IsActive" });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyResourceBookingPermissions_CompanyId_ResourceTypeId_EmployeeTypeId",
                table: "CompanyResourceBookingPermissions",
                columns: new[] { "CompanyId", "ResourceTypeId", "EmployeeTypeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyResourceBookingPermissions_EmployeeTypeId",
                table: "CompanyResourceBookingPermissions",
                column: "EmployeeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyResourceBookingPermissions_ResourceTypeId",
                table: "CompanyResourceBookingPermissions",
                column: "ResourceTypeId");

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
                name: "IX_Feedbacks_CompanyId",
                table: "Feedbacks",
                column: "CompanyId");

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
                name: "IX_resourceBookings_CompanyId",
                table: "resourceBookings",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_resourceBookings_QRCodeValue",
                table: "resourceBookings",
                column: "QRCodeValue",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_resourceBookings_ResourceId_StartTime_EndTime",
                table: "resourceBookings",
                columns: new[] { "ResourceId", "StartTime", "EndTime" });

            migrationBuilder.CreateIndex(
                name: "IX_resourceBookings_ResourceTypeId",
                table: "resourceBookings",
                column: "ResourceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_CompanyId_FloorId",
                table: "Resources",
                columns: new[] { "CompanyId", "FloorId" });

            migrationBuilder.CreateIndex(
                name: "IX_Resources_CompanyId_ResourceTypeId",
                table: "Resources",
                columns: new[] { "CompanyId", "ResourceTypeId" });

            migrationBuilder.CreateIndex(
                name: "IX_Resources_FloorId",
                table: "Resources",
                column: "FloorId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_ResourceTypeId",
                table: "Resources",
                column: "ResourceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_RoleId_ModuleCode",
                table: "RolePermissions",
                columns: new[] { "RoleId", "ModuleCode" },
                unique: true,
                filter: "[UserId] IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_RoleId_ModuleCode_UserId",
                table: "RolePermissions",
                columns: new[] { "RoleId", "ModuleCode", "UserId" },
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_UserId",
                table: "RolePermissions",
                column: "UserId");

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
                name: "CompanyResourceBookingPermissions");

            migrationBuilder.DropTable(
                name: "CompanySubscription");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Histories");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "resourceBookings");

            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "employeeType");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "SubscriptionTypes");

            migrationBuilder.DropTable(
                name: "CompanyFloors");

            migrationBuilder.DropTable(
                name: "ResourceTypes");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "CompanyDetails");
        }
    }
}
