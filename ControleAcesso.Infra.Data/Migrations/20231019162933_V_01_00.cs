using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ControleAcesso.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class V_01_00 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    UserName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    Blocked = table.Column<bool>(type: "boolean", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersAccesses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    IP = table.Column<string>(type: "text", nullable: false),
                    Success = table.Column<bool>(type: "boolean", nullable: false),
                    AccessDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersAccesses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FuncionalitiesProfiles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProfileId = table.Column<long>(type: "bigint", nullable: false),
                    FuncionalityId = table.Column<long>(type: "bigint", nullable: false),
                    FunctionalityId = table.Column<long>(type: "bigint", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncionalitiesProfiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Functionalities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    MenuOptionId = table.Column<long>(type: "bigint", nullable: false),
                    FuncionalityProfileId = table.Column<long>(type: "bigint", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Functionalities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Functionalities_FuncionalitiesProfiles_FuncionalityProfileId",
                        column: x => x.FuncionalityProfileId,
                        principalTable: "FuncionalitiesProfiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MenuOptions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    URL = table.Column<string>(type: "text", nullable: false),
                    Position = table.Column<int>(type: "integer", nullable: false),
                    MenuDadId = table.Column<long>(type: "bigint", nullable: true),
                    FuncionalityId = table.Column<long>(type: "bigint", nullable: false),
                    MenuOptionId = table.Column<long>(type: "bigint", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuOptions_Functionalities_FuncionalityId",
                        column: x => x.FuncionalityId,
                        principalTable: "Functionalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuOptions_MenuOptions_MenuDadId",
                        column: x => x.MenuDadId,
                        principalTable: "MenuOptions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MenuOptions_MenuOptions_MenuOptionId",
                        column: x => x.MenuOptionId,
                        principalTable: "MenuOptions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Methods",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Class = table.Column<string>(type: "text", nullable: false),
                    Method = table.Column<string>(type: "text", nullable: false),
                    FunctionalityId = table.Column<long>(type: "bigint", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Methods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Methods_Functionalities_FunctionalityId",
                        column: x => x.FunctionalityId,
                        principalTable: "Functionalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    FunctionalityId = table.Column<long>(type: "bigint", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_Functionalities_FunctionalityId",
                        column: x => x.FunctionalityId,
                        principalTable: "Functionalities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UsersProfiles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ProfileId = table.Column<long>(type: "bigint", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersProfiles_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersProfiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FuncionalitiesProfiles_FunctionalityId",
                table: "FuncionalitiesProfiles",
                column: "FunctionalityId");

            migrationBuilder.CreateIndex(
                name: "IX_FuncionalitiesProfiles_ProfileId",
                table: "FuncionalitiesProfiles",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Functionalities_FuncionalityProfileId",
                table: "Functionalities",
                column: "FuncionalityProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Functionalities_MenuOptionId",
                table: "Functionalities",
                column: "MenuOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuOptions_FuncionalityId",
                table: "MenuOptions",
                column: "FuncionalityId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuOptions_MenuDadId",
                table: "MenuOptions",
                column: "MenuDadId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuOptions_MenuOptionId",
                table: "MenuOptions",
                column: "MenuOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Methods_FunctionalityId",
                table: "Methods",
                column: "FunctionalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_FunctionalityId",
                table: "Profiles",
                column: "FunctionalityId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersProfiles_ProfileId",
                table: "UsersProfiles",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersProfiles_UserId",
                table: "UsersProfiles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FuncionalitiesProfiles_Functionalities_FunctionalityId",
                table: "FuncionalitiesProfiles",
                column: "FunctionalityId",
                principalTable: "Functionalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FuncionalitiesProfiles_Profiles_ProfileId",
                table: "FuncionalitiesProfiles",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Functionalities_MenuOptions_MenuOptionId",
                table: "Functionalities",
                column: "MenuOptionId",
                principalTable: "MenuOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FuncionalitiesProfiles_Functionalities_FunctionalityId",
                table: "FuncionalitiesProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuOptions_Functionalities_FuncionalityId",
                table: "MenuOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Functionalities_FunctionalityId",
                table: "Profiles");

            migrationBuilder.DropTable(
                name: "Methods");

            migrationBuilder.DropTable(
                name: "UsersAccesses");

            migrationBuilder.DropTable(
                name: "UsersProfiles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Functionalities");

            migrationBuilder.DropTable(
                name: "FuncionalitiesProfiles");

            migrationBuilder.DropTable(
                name: "MenuOptions");

            migrationBuilder.DropTable(
                name: "Profiles");
        }
    }
}
