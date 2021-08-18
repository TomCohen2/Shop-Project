using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop_Project.Migrations
{
    public partial class acc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessoryConsole");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Accessory",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Accessory_ConsoleId",
                table: "Accessory",
                column: "ConsoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accessory_Console_ConsoleId",
                table: "Accessory",
                column: "ConsoleId",
                principalTable: "Console",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accessory_Console_ConsoleId",
                table: "Accessory");

            migrationBuilder.DropIndex(
                name: "IX_Accessory_ConsoleId",
                table: "Accessory");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Accessory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AccessoryConsole",
                columns: table => new
                {
                    accessoriesId = table.Column<int>(type: "int", nullable: false),
                    consolesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessoryConsole", x => new { x.accessoriesId, x.consolesId });
                    table.ForeignKey(
                        name: "FK_AccessoryConsole_Accessory_accessoriesId",
                        column: x => x.accessoriesId,
                        principalTable: "Accessory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccessoryConsole_Console_consolesId",
                        column: x => x.consolesId,
                        principalTable: "Console",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccessoryConsole_consolesId",
                table: "AccessoryConsole",
                column: "consolesId");
        }
    }
}
