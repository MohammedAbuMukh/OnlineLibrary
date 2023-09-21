using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    SectionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.SectionId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Serial = table.Column<string>(nullable: true),
                    SectionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "SectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "SectionId", "Name" },
                values: new object[,]
                {
                    { 1, "History" },
                    { 2, "Engineering" },
                    { 3, "Mathmatics" },
                    { 4, "Medical" },
                    { 5, "Fantasy" },
                    { 6, "Physics" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Name", "Price", "SectionId", "Serial" },
                values: new object[,]
                {
                    { 1, "Art of war", 40.0, 1, "0001" },
                    { 4, "History of rome", 55.0, 1, "0004" },
                    { 2, "Basics of engineering", 20.0, 2, "0002" },
                    { 5, "The song of the cell ", 60.0, 4, "0005" },
                    { 6, "Harry potter", 80.0, 5, "0006" },
                    { 3, "Physics I", 15.0, 6, "0003" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_SectionId",
                table: "Books",
                column: "SectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Sections");
        }
    }
}
