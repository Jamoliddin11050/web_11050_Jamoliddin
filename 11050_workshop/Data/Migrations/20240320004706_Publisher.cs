using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _11050_workshop.Data.Migrations
{
    public partial class Publisher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PublisherId",
                table: "books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_publishers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_books_PublisherId",
                table: "books",
                column: "PublisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_books_publishers_PublisherId",
                table: "books",
                column: "PublisherId",
                principalTable: "publishers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_publishers_PublisherId",
                table: "books");

            migrationBuilder.DropTable(
                name: "publishers");

            migrationBuilder.DropIndex(
                name: "IX_books_PublisherId",
                table: "books");

            migrationBuilder.DropColumn(
                name: "PublisherId",
                table: "books");
        }
    }
}
