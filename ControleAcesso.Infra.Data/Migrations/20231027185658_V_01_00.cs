using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ControleAcesso.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class V_01_00 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Functionalities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Functionalities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

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
                name: "MenuOptions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    URL = table.Column<string>(type: "text", nullable: false),
                    Position = table.Column<int>(type: "integer", nullable: false),
                    MenuDadId = table.Column<long>(type: "bigint", nullable: true),
                    FunctionalityId = table.Column<long>(type: "bigint", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuOptions_Functionalities_FunctionalityId",
                        column: x => x.FunctionalityId,
                        principalTable: "Functionalities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MenuOptions_MenuOptions_MenuDadId",
                        column: x => x.MenuDadId,
                        principalTable: "MenuOptions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Methods",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    ClassName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Action = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
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
                name: "FunctionalitiesProfiles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProfileId = table.Column<long>(type: "bigint", nullable: false),
                    FunctionalityId = table.Column<long>(type: "bigint", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FunctionalitiesProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FunctionalitiesProfiles_Functionalities_FunctionalityId",
                        column: x => x.FunctionalityId,
                        principalTable: "Functionalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FunctionalitiesProfiles_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.InsertData(
                table: "Functionalities",
                columns: new[] { "Id", "Active", "CreatedAt", "Description", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 1L, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Funcionalidade para manter todos os perfis do sistema", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manter perfil" },
                    { 2L, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Funcionalidade para manter todos os metodos do sistema", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manter metodos" },
                    { 3L, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Funcionalidade para manter todas as funcionalidades do sistema", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manter funcionalidades" },
                    { 4L, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Funcionalidade para manter todos os menus do sistema", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manter menus" },
                    { 5L, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Funcionalidade para manter todos os perfeis de usuarios", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manter perfis do usuario" },
                    { 6L, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Funcionalidade para manter todos os menus do sistema", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manter funcionalidade perfis" },
                    { 7L, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Funcionalidade para manter o próprio perfil no sistema", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manter perfil próprio" }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Active", "CreatedAt", "Description", "ModifiedAt", "Name" },
                values: new object[] { 1L, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Administrador do sistema", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Administrador" });

            migrationBuilder.InsertData(
                table: "FunctionalitiesProfiles",
                columns: new[] { "Id", "Active", "CreatedAt", "FunctionalityId", "ModifiedAt", "ProfileId" },
                values: new object[,]
                {
                    { 1L, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L },
                    { 2L, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L },
                    { 3L, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L },
                    { 4L, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L },
                    { 5L, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L },
                    { 6L, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L },
                    { 7L, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L }
                });

            migrationBuilder.InsertData(
                table: "Methods",
                columns: new[] { "Id", "Action", "Active", "ClassName", "CreatedAt", "Description", "FunctionalityId", "ModifiedAt" },
                values: new object[,]
                {
                    { 1L, "GetAllUsers", true, "UserController", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pegar todos os usuarios do sistema", 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, "GetById", true, "UserController", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pegar qualquer usuario do sistema por id", 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, "Delete", true, "UserController", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deletar qualquer usuario do sistema", 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, "GetAllMethod", true, "MethodController", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pegar todos os metodos do sistema", 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, "GetById", true, "MethodController", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pegar metodo por id do sistema", 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6L, "GetByFunctionalityId", true, "MethodController", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pegar metodos por funcionalidade", 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7L, "Create", true, "MethodController", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Criar metodo", 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8L, "Update", true, "MethodController", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Atualizar metodo", 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9L, "Delete", true, "MethodController", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deletar metodo", 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10L, "GetAllFunctionality", true, "FunctionalityController", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pegar todas as funcionalidades do sistema", 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11L, "GetById", true, "FunctionalityController", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pegar funcionalidade por id", 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12L, "Create", true, "FunctionalityController", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Criar funcionalidades", 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13L, "Update", true, "FunctionalityController", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Atualizar funcionalidades", 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14L, "Delete", true, "FunctionalityController", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deletar funcionalidades", 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15L, "GetAllMenuOption", true, "MenuOptionController", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pegar todos os menus", 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16L, "GetById", true, "MenuOptionController", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pegar menu por id", 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17L, "GetByFunctionalityId", true, "MenuOptionController", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pegar menus por funcionalidade", 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18L, "Create", true, "MenuOptionController", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Criar funcionalidade", 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19L, "Update", true, "MenuOptionController", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alterar funcionalidade", 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20L, "Delete", true, "MenuOptionController", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deletar funcionalidade", 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21L, "GetForUserIdAsync", true, "MenuOptionController", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deletar funcionalidade", 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22L, "GetAllFunctionalityProfiles", true, "FunctionalityProfileController", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pegar todas as funcionalidades perfis do sistema", 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23L, "GetById", true, "FunctionalityProfileController", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pegar funcionalidade perfil por id", 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24L, "GetByFunctionalityId", true, "FunctionalityProfileController", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pegar funcionalidades perfis por funcionalidade", 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25L, "GetByProfileId", true, "FunctionalityProfileController", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pegar funcionalidade perfis por perfil", 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26L, "Create", true, "FunctionalityProfileController", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Criar funcionalidade perfil", 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27L, "Update", true, "FunctionalityProfileController", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alterar funcionalidade perfil", 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28L, "Delete", true, "FunctionalityProfileController", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deletar funcionalidade perfil", 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29L, "GetAllUserProfiles", true, "UserProfileController", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pegar todos os usuários perfis do sistema", 6L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30L, "GetById", true, "UserProfileController", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pegar usuários perfil por id", 6L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31L, "GetByUserId", true, "UserProfileController", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pegar usuários perfis por usuários", 6L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32L, "GetByProfileId", true, "UserProfileController", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pegar usuários perfis por perfil", 6L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33L, "Create", true, "UserProfileController", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Criar usuário perfil", 6L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34L, "Update", true, "UserProfileController", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alterar usuário perfil", 6L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35L, "Delete", true, "UserProfileController", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deletar usuário perfil", 6L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36L, "GetPersonalUser", true, "UserController", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pegar o proprio usuário do sistema", 7L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37L, "UpdatePerosnalUser", true, "UserController", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alterar o proprio usuário do sistema", 7L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38L, "ValidateAccessClassMethod", true, "MethodController", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Verificação externa de ações", 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FunctionalitiesProfiles_FunctionalityId",
                table: "FunctionalitiesProfiles",
                column: "FunctionalityId");

            migrationBuilder.CreateIndex(
                name: "IX_FunctionalitiesProfiles_ProfileId",
                table: "FunctionalitiesProfiles",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuOptions_FunctionalityId",
                table: "MenuOptions",
                column: "FunctionalityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuOptions_MenuDadId",
                table: "MenuOptions",
                column: "MenuDadId");

            migrationBuilder.CreateIndex(
                name: "IX_Methods_FunctionalityId",
                table: "Methods",
                column: "FunctionalityId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersProfiles_ProfileId",
                table: "UsersProfiles",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersProfiles_UserId",
                table: "UsersProfiles",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FunctionalitiesProfiles");

            migrationBuilder.DropTable(
                name: "MenuOptions");

            migrationBuilder.DropTable(
                name: "Methods");

            migrationBuilder.DropTable(
                name: "UsersAccesses");

            migrationBuilder.DropTable(
                name: "UsersProfiles");

            migrationBuilder.DropTable(
                name: "Functionalities");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
