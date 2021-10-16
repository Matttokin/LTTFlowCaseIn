using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LttFlow.Migrations
{
    public partial class addTgTb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MeterReadingGroupList",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    Alias = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeterReadingGroupList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeterReadingGroupList_AbpUsers_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MeterReadingList",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    GIUD = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    GroupId = table.Column<int>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    Value = table.Column<decimal>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeterReadingList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeterReadingList_AbpUsers_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TelegramNotificationGroupList",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    Alias = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelegramNotificationGroupList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TelegramNotificationGroupList_AbpUsers_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TelegramUserList",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    TelegramId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    IsUsed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelegramUserList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TelegramUserList_AbpUsers_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TelegramUserNotificationList",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    GroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelegramUserNotificationList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TelegramUserNotificationList_AbpUsers_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeterReadingGroupList_CreatorUserId",
                table: "MeterReadingGroupList",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MeterReadingList_CreatorUserId",
                table: "MeterReadingList",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TelegramNotificationGroupList_CreatorUserId",
                table: "TelegramNotificationGroupList",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TelegramUserList_CreatorUserId",
                table: "TelegramUserList",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TelegramUserNotificationList_CreatorUserId",
                table: "TelegramUserNotificationList",
                column: "CreatorUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeterReadingGroupList");

            migrationBuilder.DropTable(
                name: "MeterReadingList");

            migrationBuilder.DropTable(
                name: "TelegramNotificationGroupList");

            migrationBuilder.DropTable(
                name: "TelegramUserList");

            migrationBuilder.DropTable(
                name: "TelegramUserNotificationList");
        }
    }
}
