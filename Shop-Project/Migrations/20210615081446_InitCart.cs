using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop_Project.Migrations
{
    public partial class InitCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameGenre_Genre_genresId",
                table: "GameGenre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameGenre",
                table: "GameGenre");

            migrationBuilder.DropIndex(
                name: "IX_GameGenre_genresId",
                table: "GameGenre");

            migrationBuilder.RenameColumn(
                name: "genresId",
                table: "GameGenre",
                newName: "GenresId");

            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartId",
                table: "Game",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartId",
                table: "Console",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartId",
                table: "Accessory",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameGenre",
                table: "GameGenre",
                columns: new[] { "GenresId", "gamesId" });

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
                name: "IX_GameGenre_gamesId",
                table: "GameGenre",
                column: "gamesId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_ShoppingCartId",
                table: "Game",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_Console_ShoppingCartId",
                table: "Console",
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
                name: "FK_Game_ShoppingCart_ShoppingCartId",
                table: "Game",
                column: "ShoppingCartId",
                principalTable: "ShoppingCart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GameGenre_Genre_GenresId",
                table: "GameGenre",
                column: "GenresId",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accessory_ShoppingCart_ShoppingCartId",
                table: "Accessory");

            migrationBuilder.DropForeignKey(
                name: "FK_Console_ShoppingCart_ShoppingCartId",
                table: "Console");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_ShoppingCart_ShoppingCartId",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_GameGenre_Genre_GenresId",
                table: "GameGenre");

            migrationBuilder.DropTable(
                name: "ShoppingCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameGenre",
                table: "GameGenre");

            migrationBuilder.DropIndex(
                name: "IX_GameGenre_gamesId",
                table: "GameGenre");

            migrationBuilder.DropIndex(
                name: "IX_Game_ShoppingCartId",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Console_ShoppingCartId",
                table: "Console");

            migrationBuilder.DropIndex(
                name: "IX_Accessory_ShoppingCartId",
                table: "Accessory");

            migrationBuilder.DropColumn(
                name: "ShoppingCartId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "ShoppingCartId",
                table: "Console");

            migrationBuilder.DropColumn(
                name: "ShoppingCartId",
                table: "Accessory");

            migrationBuilder.RenameColumn(
                name: "GenresId",
                table: "GameGenre",
                newName: "genresId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameGenre",
                table: "GameGenre",
                columns: new[] { "gamesId", "genresId" });

            migrationBuilder.CreateIndex(
                name: "IX_GameGenre_genresId",
                table: "GameGenre",
                column: "genresId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameGenre_Genre_genresId",
                table: "GameGenre",
                column: "genresId",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
