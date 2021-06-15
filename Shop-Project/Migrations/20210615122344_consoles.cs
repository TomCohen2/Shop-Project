using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop_Project.Migrations
{
    public partial class consoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accessory_ShoppingCart_ShoppingCartId",
                table: "Accessory");

            migrationBuilder.DropForeignKey(
                name: "FK_Console_ShoppingCart_ShoppingCartId",
                table: "Console");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_Console_ConsoleId",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_ShoppingCart_ShoppingCartId",
                table: "Game");

            migrationBuilder.DropTable(
                name: "ShoppingCart");

            migrationBuilder.DropIndex(
                name: "IX_Game_ConsoleId",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Game_ShoppingCartId",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Accessory_ShoppingCartId",
                table: "Accessory");

            migrationBuilder.DropColumn(
                name: "ConsoleId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "ShoppingCartId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "ShoppingCartId",
                table: "Accessory");

            migrationBuilder.RenameColumn(
                name: "ShoppingCartId",
                table: "Console",
                newName: "GameId");

            migrationBuilder.RenameIndex(
                name: "IX_Console_ShoppingCartId",
                table: "Console",
                newName: "IX_Console_GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Console_Game_GameId",
                table: "Console",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Console_Game_GameId",
                table: "Console");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "Console",
                newName: "ShoppingCartId");

            migrationBuilder.RenameIndex(
                name: "IX_Console_GameId",
                table: "Console",
                newName: "IX_Console_ShoppingCartId");

            migrationBuilder.AddColumn<int>(
                name: "ConsoleId",
                table: "Game",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartId",
                table: "Game",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartId",
                table: "Accessory",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ShoppingCart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCart", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Game_ConsoleId",
                table: "Game",
                column: "ConsoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_ShoppingCartId",
                table: "Game",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_Accessory_ShoppingCartId",
                table: "Accessory",
                column: "ShoppingCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accessory_ShoppingCart_ShoppingCartId",
                table: "Accessory",
                column: "ShoppingCartId",
                principalTable: "ShoppingCart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Console_ShoppingCart_ShoppingCartId",
                table: "Console",
                column: "ShoppingCartId",
                principalTable: "ShoppingCart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Console_ConsoleId",
                table: "Game",
                column: "ConsoleId",
                principalTable: "Console",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Game_ShoppingCart_ShoppingCartId",
                table: "Game",
                column: "ShoppingCartId",
                principalTable: "ShoppingCart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
