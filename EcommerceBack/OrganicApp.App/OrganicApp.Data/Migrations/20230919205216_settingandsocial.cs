using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrganicApp.Data.Migrations
{
    public partial class settingandsocial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Socials_ContactServices_ContactServiceId",
                table: "Socials");

            migrationBuilder.DropTable(
                name: "ContactServices");

            migrationBuilder.RenameColumn(
                name: "ContactServiceId",
                table: "Socials",
                newName: "SettingId");

            migrationBuilder.RenameIndex(
                name: "IX_Socials_ContactServiceId",
                table: "Socials",
                newName: "IX_Socials_SettingId");

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Socials_Settings_SettingId",
                table: "Socials",
                column: "SettingId",
                principalTable: "Settings",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Socials_Settings_SettingId",
                table: "Socials");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.RenameColumn(
                name: "SettingId",
                table: "Socials",
                newName: "ContactServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Socials_SettingId",
                table: "Socials",
                newName: "IX_Socials_ContactServiceId");

            migrationBuilder.CreateTable(
                name: "ContactServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactServices", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Socials_ContactServices_ContactServiceId",
                table: "Socials",
                column: "ContactServiceId",
                principalTable: "ContactServices",
                principalColumn: "Id");
        }
    }
}
