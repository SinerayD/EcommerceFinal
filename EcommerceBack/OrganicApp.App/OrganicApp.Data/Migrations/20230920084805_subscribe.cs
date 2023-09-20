using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrganicApp.Data.Migrations
{
    public partial class subscribe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Socials_Settings_SettingId",
                table: "Socials");

            migrationBuilder.DropIndex(
                name: "IX_Socials_SettingId",
                table: "Socials");

            migrationBuilder.DropColumn(
                name: "SettingId",
                table: "Socials");

            migrationBuilder.CreateTable(
                name: "subscribes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subscribes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "subscribes");

            migrationBuilder.AddColumn<int>(
                name: "SettingId",
                table: "Socials",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Socials_SettingId",
                table: "Socials",
                column: "SettingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Socials_Settings_SettingId",
                table: "Socials",
                column: "SettingId",
                principalTable: "Settings",
                principalColumn: "Id");
        }
    }
}
