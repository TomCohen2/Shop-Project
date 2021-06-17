using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop_Project.Migrations
{
    public partial class DBConnection3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Console_Game_GameId",
                table: "Console");

            migrationBuilder.DropIndex(
                name: "IX_Console_GameId",
                table: "Console");

            migrationBuilder.DropColumn(
                name: "ConsoleId",
                table: "Console");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Console");

            migrationBuilder.AddColumn<int>(
                name: "ConsoleId",
                table: "Game",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ConsoleId",
                table: "Accessory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Game_ConsoleId",
                table: "Game",
                column: "ConsoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Console_ConsoleId",
                table: "Game",
                column: "ConsoleId",
                principalTable: "Console",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Console_ConsoleId",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Game_ConsoleId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "ConsoleId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "ConsoleId",
                table: "Accessory");

            migrationBuilder.AddColumn<int>(
                name: "ConsoleId",
                table: "Console",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Console",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Console_GameId",
                table: "Console",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Console_Game_GameId",
                table: "Console",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
