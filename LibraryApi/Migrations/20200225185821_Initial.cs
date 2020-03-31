using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 200, nullable: true),
                    Author = table.Column<string>(maxLength: 200, nullable: true),
                    Genre = table.Column<string>(maxLength: 200, nullable: true),
                    NumberOfPages = table.Column<int>(nullable: false),
                    InInventory = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Genre", "InInventory", "NumberOfPages", "Title" },
                values: new object[] { 1, "Thoreau", "Philosophy", false, 322, "Walden" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Genre", "InInventory", "NumberOfPages", "Title" },
                values: new object[] { 2, "Franz Kafka", "Fiction", false, 180, "In the Penal Colony" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Genre", "InInventory", "NumberOfPages", "Title" },
                values: new object[] { 3, "Franz Kafka", "Fiction", false, 223, "The Trial" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
