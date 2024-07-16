using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Product.Migrations
{
    public partial class ProductTableAPI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Productss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productss", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Productss",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "This Is Product One", "Laptop" },
                    { 2, "This Is Product Two", "DeskTop" },
                    { 3, "This Is Product Three", "Printer" },
                    { 4, "This Is Product Four", "HeadPhone" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productss");
        }
    }
}
