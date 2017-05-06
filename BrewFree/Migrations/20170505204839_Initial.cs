using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BrewFree.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Security");

            migrationBuilder.EnsureSchema(
                name: "User");

            migrationBuilder.EnsureSchema(
                name: "Lookup");

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BrewingMethods",
                schema: "Lookup",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 2500, nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrewingMethods", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Styles",
                schema: "Lookup",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 100, nullable: false),
                    AlcoholByVolumeMaximum = table.Column<decimal>(nullable: true),
                    AlcoholByVolumeMinimum = table.Column<decimal>(nullable: true),
                    Aroma = table.Column<string>(maxLength: 2500, nullable: true),
                    ColorMaximum = table.Column<decimal>(nullable: true),
                    ColorMinimum = table.Column<decimal>(nullable: true),
                    Description = table.Column<string>(maxLength: 2500, nullable: true),
                    Examples = table.Column<string>(maxLength: 2500, nullable: true),
                    FinalGravityMaximum = table.Column<decimal>(nullable: true),
                    FinalGravityMinimum = table.Column<decimal>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    OriginalGravityMaximum = table.Column<decimal>(nullable: true),
                    OriginalGravityMinimum = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Styles", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "StyleTags",
                schema: "Lookup",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 2500, nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    TypeCode = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StyleTags", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                schema: "Security",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "Brewers",
                schema: "User",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Shared = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brewers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Brewers_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                schema: "Security",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StyleTagAssociation",
                schema: "Lookup",
                columns: table => new
                {
                    StyleCode = table.Column<string>(nullable: false),
                    StyleTagCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StyleTagAssociation", x => new { x.StyleCode, x.StyleTagCode });
                    table.ForeignKey(
                        name: "FK_StyleTagAssociation_Styles_StyleCode",
                        column: x => x.StyleCode,
                        principalSchema: "Lookup",
                        principalTable: "Styles",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StyleTagAssociation_StyleTags_StyleTagCode",
                        column: x => x.StyleTagCode,
                        principalSchema: "Lookup",
                        principalTable: "StyleTags",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Security",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "Security",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Security",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                schema: "User",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    BrewerId = table.Column<string>(nullable: true),
                    BrewingMethodCode = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    StyleCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_Brewers_BrewerId",
                        column: x => x.BrewerId,
                        principalSchema: "User",
                        principalTable: "Brewers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recipes_BrewingMethods_BrewingMethodCode",
                        column: x => x.BrewingMethodCode,
                        principalSchema: "Lookup",
                        principalTable: "BrewingMethods",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recipes_Styles_StyleCode",
                        column: x => x.StyleCode,
                        principalSchema: "Lookup",
                        principalTable: "Styles",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Security",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Security",
                table: "Users",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Brewers_ApplicationUserId",
                schema: "User",
                table: "Brewers",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StyleTagAssociation_StyleTagCode",
                schema: "Lookup",
                table: "StyleTagAssociation",
                column: "StyleTagCode");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_BrewerId",
                schema: "User",
                table: "Recipes",
                column: "BrewerId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_BrewingMethodCode",
                schema: "User",
                table: "Recipes",
                column: "BrewingMethodCode");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_StyleCode",
                schema: "User",
                table: "Recipes",
                column: "StyleCode");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Security",
                table: "Roles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                schema: "Security",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                schema: "Security",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                schema: "Security",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "Security",
                table: "UserRoles",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StyleTagAssociation",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "Recipes",
                schema: "User");

            migrationBuilder.DropTable(
                name: "RoleClaims",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "UserClaims",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "UserLogins",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "UserTokens",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "StyleTags",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "Brewers",
                schema: "User");

            migrationBuilder.DropTable(
                name: "BrewingMethods",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "Styles",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Security");
        }
    }
}
