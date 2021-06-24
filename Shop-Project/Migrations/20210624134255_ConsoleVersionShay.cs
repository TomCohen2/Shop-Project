using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop_Project.Migrations
{
    public partial class ConsoleVersionShay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfRelease",
                table: "Console");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Console");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Console");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Console");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Console");

            migrationBuilder.DropColumn(
                name: "trailer",
                table: "Console");

            migrationBuilder.CreateTable(
                name: "ConsoleVersion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfRelease = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    trailer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsoleVersion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsoleVersion_Console_ConsoleId",
                        column: x => x.ConsoleId,
                        principalTable: "Console",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsoleVersion_ConsoleId",
                table: "ConsoleVersion",
                column: "ConsoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsoleVersion");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfRelease",
                table: "Console",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Console",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Console",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Console",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Console",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "trailer",
                table: "Console",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
