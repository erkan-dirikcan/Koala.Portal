using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Koala.Portal.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgendaType",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BackColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FontColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BorderColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendaType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Oid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    SKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CrmDepartment",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Oid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CrmName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrmDepartment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CrmFirm",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Oid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InUse = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrmFirm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailTemplate",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailTemplate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fixture",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsVehicle = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fixture", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HelpDeskCatogory",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HelpDeskCatogory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Module",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SupportFile",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TicketId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedByOid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endwith = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedByType = table.Column<int>(type: "int", nullable: false),
                    AttachmentType = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportFile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Agenda",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AgendaTypeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EventCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirmOid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TicketOid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CancelDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComplatedDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoteForCustomer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsComplated = table.Column<bool>(type: "bit", nullable: false),
                    IsCanceled = table.Column<bool>(type: "bit", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CancelUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CancelDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ComplateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agenda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agenda_AgendaType_AgendaTypeId",
                        column: x => x.AgendaTypeId,
                        principalTable: "AgendaType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserCrmDepartment",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DepartmanId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserCrmDepartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserCrmDepartment_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserCrmDepartment_CrmDepartment_DepartmanId",
                        column: x => x.DepartmanId,
                        principalTable: "CrmDepartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CrmFirmContact",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Oid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirmId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InUse = table.Column<bool>(type: "bit", nullable: false),
                    SupportTicket = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrmFirmContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CrmFirmContact_CrmFirm_FirmId",
                        column: x => x.FirmId,
                        principalTable: "CrmFirm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HelpDeskProblem",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Views = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HelpDeskProblem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HelpDeskProblem_HelpDeskCatogory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "HelpDeskCatogory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Claims",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ModuleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Claims_Module_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Module",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeneratedIds",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ModuleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Prefix = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartNumber = table.Column<int>(type: "int", nullable: false),
                    LastNumber = table.Column<int>(type: "int", nullable: false),
                    Digit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneratedIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneratedIds_Module_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Module",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AgendaFirmOfficials",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Oid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgendaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendaFirmOfficials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgendaFirmOfficials_Agenda_AgendaId",
                        column: x => x.AgendaId,
                        principalTable: "Agenda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AgendaFixtures",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AgendaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FixtureId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartKm = table.Column<int>(type: "int", nullable: true),
                    LastKm = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendaFixtures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgendaFixtures_Agenda_AgendaId",
                        column: x => x.AgendaId,
                        principalTable: "Agenda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgendaFixtures_Fixture_FixtureId",
                        column: x => x.FixtureId,
                        principalTable: "Fixture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AgendaUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AgendaId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendaUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgendaUsers_Agenda_AgendaId",
                        column: x => x.AgendaId,
                        principalTable: "Agenda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgendaUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CrmPhoneNumber",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Oid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RelatedFirm = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RelatedContact = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AreaCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrmPhoneNumber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CrmPhoneNumber_CrmFirmContact_RelatedContact",
                        column: x => x.RelatedContact,
                        principalTable: "CrmFirmContact",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CrmPhoneNumber_CrmFirm_RelatedFirm",
                        column: x => x.RelatedFirm,
                        principalTable: "CrmFirm",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProjectCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectManagerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirmId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirmPersonId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ServiceHour = table.Column<int>(type: "int", nullable: true),
                    EstimatedHour = table.Column<int>(type: "int", nullable: true),
                    CancelDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProjectStatus = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_AspNetUsers_ProjectManagerId",
                        column: x => x.ProjectManagerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Project_CrmFirmContact_FirmPersonId",
                        column: x => x.FirmPersonId,
                        principalTable: "CrmFirmContact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Project_CrmFirm_FirmId",
                        column: x => x.FirmId,
                        principalTable: "CrmFirm",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HelpDeskSolition",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SolitionNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HelpDeskProblemId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Like = table.Column<int>(type: "int", nullable: false),
                    DisLike = table.Column<int>(type: "int", nullable: false),
                    CustomerCanSee = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HelpDeskSolition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HelpDeskSolition_HelpDeskProblem_HelpDeskProblemId",
                        column: x => x.HelpDeskProblemId,
                        principalTable: "HelpDeskProblem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectFiles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProjectId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectFiles_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectLine",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProjectId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceTime = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    StateStatus = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CancelDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RowOrdwer = table.Column<int>(type: "int", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectLine_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectLineNote",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProjectLineId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportNote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectLineNote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectLineNote_ProjectLine_ProjectLineId",
                        column: x => x.ProjectLineId,
                        principalTable: "ProjectLine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectLineWork",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LineId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeSpend = table.Column<int>(type: "int", nullable: false),
                    LetTimeDeduct = table.Column<bool>(type: "bit", nullable: false),
                    DeliveredPersonOid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveredPerson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkStatus = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    CancelDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RowOrdwer = table.Column<int>(type: "int", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectLineWork", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectLineWork_ProjectLine_LineId",
                        column: x => x.LineId,
                        principalTable: "ProjectLine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectLineWorkSupports",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SupportOid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupportCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectLinetWorkId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectLineWorkSupports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectLineWorkSupports_ProjectLineWork_ProjectLinetWorkId",
                        column: x => x.ProjectLinetWorkId,
                        principalTable: "ProjectLineWork",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectPerson",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProjectId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProjectLineId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProjectLineWorkId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectPerson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectPerson_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectPerson_ProjectLineWork_ProjectLineWorkId",
                        column: x => x.ProjectLineWorkId,
                        principalTable: "ProjectLineWork",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectPerson_ProjectLine_ProjectLineId",
                        column: x => x.ProjectLineId,
                        principalTable: "ProjectLine",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectPerson_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AgendaType",
                columns: new[] { "Id", "BackColor", "BorderColor", "Description", "FontColor", "IsActive", "Name" },
                values: new object[,]
                {
                    { "069f9c6c-dbb5-11ee-a5b1-704d7b71982b", "#007a96", "", "Müşteri veYa servisden ürün teslim alma etkinliği", "#ffffff", true, "Ürün Teslim Alma" },
                    { "069f9c6e-dbb5-11ee-a5b1-704d7b71982b", "#00bbdd", "", "Ürün Teslimatı ", "#ffffff", true, "Teslimat" },
                    { "069f9c70-dbb5-11ee-a5b1-704d7b71982b", "#c90000", "", "Logo Proje Destek", "#ffffff", true, "Logo Proje Destek" },
                    { "069f9c72-dbb5-11ee-a5b1-704d7b71982b", "#ff7a00", "", "Müşteri Taleplerine Göre Yapılacak Proje, Uyarlama veya Geliştirmeler Hakkında Toplantı", "#ffffff", true, "Proje Toplantısı" },
                    { "069f9c74-dbb5-11ee-a5b1-704d7b71982b", "#ffee98", "", "Donanım Yerinde Destek", "#03347d", true, "Donanım Yerinde Destek" },
                    { "069f9c76-dbb5-11ee-a5b1-704d7b71982b", "Logo Müşteri Ziyareti", "#ffffff", "", "#669600", true, "Logo Müşteri Ziyareti" },
                    { "069f9c78-dbb5-11ee-a5b1-704d7b71982b", "#7d0078", "", "Logo dönem veya yıl sonu devir işlemleri", "#ffffff", true, "Logo Devir" },
                    { "069f9c7a-dbb5-11ee-a5b1-704d7b71982b", "#002585", "", "Logo Yerinde Destek", "#faff00", true, "Logo Yerinde Destek" },
                    { "069f9c7c-dbb5-11ee-a5b1-704d7b71982b", "#ffc700", "", "Personel Senelik İzin ", "#000000", true, "Yıllık İzin" }
                });

            migrationBuilder.InsertData(
                table: "Fixture",
                columns: new[] { "Id", "Description", "IsActive", "IsVehicle", "Name" },
                values: new object[,]
                {
                    { "069f9c7e-dbb5-11ee-a5b1-704d7b71982b", "34-BIG-293", true, true, "Fiat Egea" },
                    { "069f9c80-dbb5-11ee-a5b1-704d7b71982b", "34-FR-4680", true, true, "Volkswagen - Cady" },
                    { "069f9c82-dbb5-11ee-a5b1-704d7b71982b", "Logo Departman Notebook", true, false, "Logo Notebook" },
                    { "069f9c84-dbb5-11ee-a5b1-704d7b71982b", "Teknik Departman Notebook", true, false, "Teknik Notebook" },
                    { "069f9c86-dbb5-11ee-a5b1-704d7b71982b", "34-FC-1504", true, true, "Fiat Punto" }
                });

            migrationBuilder.InsertData(
                table: "Module",
                columns: new[] { "Id", "Description", "Name", "Status" },
                values: new object[,]
                {
                    { "069f9c87-dbb5-11ee-a5b1-704d7b71982b", "Sistem bilgisayar proje yönetim uygulaması.", "Proje", 1 },
                    { "069f9c88-dbb5-11ee-a5b1-704d7b71982b", "Yardım masası uygulaması.", "Yardım Masası", 1 },
                    { "069f9c89-dbb5-11ee-a5b1-704d7b71982b", "Personel izin, toplantı gibi etkinliklerinin takibi amacıyla oluşturulan ajanda uygulaması.", "Ajanda", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_AgendaTypeId",
                table: "Agenda",
                column: "AgendaTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AgendaFirmOfficials_AgendaId",
                table: "AgendaFirmOfficials",
                column: "AgendaId");

            migrationBuilder.CreateIndex(
                name: "IX_AgendaFixtures_AgendaId",
                table: "AgendaFixtures",
                column: "AgendaId");

            migrationBuilder.CreateIndex(
                name: "IX_AgendaFixtures_FixtureId",
                table: "AgendaFixtures",
                column: "FixtureId");

            migrationBuilder.CreateIndex(
                name: "IX_AgendaUsers_AgendaId",
                table: "AgendaUsers",
                column: "AgendaId");

            migrationBuilder.CreateIndex(
                name: "IX_AgendaUsers_UserId",
                table: "AgendaUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserCrmDepartment_AppUserId",
                table: "AppUserCrmDepartment",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserCrmDepartment_DepartmanId",
                table: "AppUserCrmDepartment",
                column: "DepartmanId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Claims_ModuleId",
                table: "Claims",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_CrmFirm_Code",
                table: "CrmFirm",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_CrmFirmContact_FirmId",
                table: "CrmFirmContact",
                column: "FirmId");

            migrationBuilder.CreateIndex(
                name: "IX_CrmPhoneNumber_RelatedContact",
                table: "CrmPhoneNumber",
                column: "RelatedContact");

            migrationBuilder.CreateIndex(
                name: "IX_CrmPhoneNumber_RelatedFirm",
                table: "CrmPhoneNumber",
                column: "RelatedFirm");

            migrationBuilder.CreateIndex(
                name: "IX_EmailTemplate_Name",
                table: "EmailTemplate",
                column: "Name",
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GeneratedIds_ModuleId",
                table: "GeneratedIds",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_HelpDeskProblem_CategoryId",
                table: "HelpDeskProblem",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_HelpDeskSolition_HelpDeskProblemId",
                table: "HelpDeskSolition",
                column: "HelpDeskProblemId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_FirmId",
                table: "Project",
                column: "FirmId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_FirmPersonId",
                table: "Project",
                column: "FirmPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ProjectCode",
                table: "Project",
                column: "ProjectCode");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ProjectManagerId",
                table: "Project",
                column: "ProjectManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectFiles_ProjectId",
                table: "ProjectFiles",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectLine_ProjectId",
                table: "ProjectLine",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectLineNote_ProjectLineId",
                table: "ProjectLineNote",
                column: "ProjectLineId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectLineWork_LineId",
                table: "ProjectLineWork",
                column: "LineId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectLineWorkSupports_ProjectLinetWorkId",
                table: "ProjectLineWorkSupports",
                column: "ProjectLinetWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPerson_ProjectId",
                table: "ProjectPerson",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPerson_ProjectLineId",
                table: "ProjectPerson",
                column: "ProjectLineId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPerson_ProjectLineWorkId",
                table: "ProjectPerson",
                column: "ProjectLineWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPerson_UserId",
                table: "ProjectPerson",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgendaFirmOfficials");

            migrationBuilder.DropTable(
                name: "AgendaFixtures");

            migrationBuilder.DropTable(
                name: "AgendaUsers");

            migrationBuilder.DropTable(
                name: "AppUserCrmDepartment");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Claims");

            migrationBuilder.DropTable(
                name: "CrmPhoneNumber");

            migrationBuilder.DropTable(
                name: "EmailTemplate");

            migrationBuilder.DropTable(
                name: "GeneratedIds");

            migrationBuilder.DropTable(
                name: "HelpDeskSolition");

            migrationBuilder.DropTable(
                name: "ProjectFiles");

            migrationBuilder.DropTable(
                name: "ProjectLineNote");

            migrationBuilder.DropTable(
                name: "ProjectLineWorkSupports");

            migrationBuilder.DropTable(
                name: "ProjectPerson");

            migrationBuilder.DropTable(
                name: "SupportFile");

            migrationBuilder.DropTable(
                name: "Fixture");

            migrationBuilder.DropTable(
                name: "Agenda");

            migrationBuilder.DropTable(
                name: "CrmDepartment");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Module");

            migrationBuilder.DropTable(
                name: "HelpDeskProblem");

            migrationBuilder.DropTable(
                name: "ProjectLineWork");

            migrationBuilder.DropTable(
                name: "AgendaType");

            migrationBuilder.DropTable(
                name: "HelpDeskCatogory");

            migrationBuilder.DropTable(
                name: "ProjectLine");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CrmFirmContact");

            migrationBuilder.DropTable(
                name: "CrmFirm");
        }
    }
}
