using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendaDeLanches.Migrations
{
    public partial class AddShoppingCartItens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CategoryDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Snacks",
                columns: table => new
                {
                    SnackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SnackName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DescriptionDetailed = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ImageThumnailURL = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsPreferred = table.Column<bool>(type: "bit", nullable: false),
                    InStock = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Snacks", x => x.SnackId);
                    table.ForeignKey(
                        name: "FK_Snacks_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItens",
                columns: table => new
                {
                    ShoppingCartId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SnackId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartItemId = table.Column<int>(type: "int", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItens", x => x.ShoppingCartId);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItens_Snacks_SnackId",
                        column: x => x.SnackId,
                        principalTable: "Snacks",
                        principalColumn: "SnackId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItens_SnackId",
                table: "ShoppingCartItens",
                column: "SnackId");

            migrationBuilder.CreateIndex(
                name: "IX_Snacks_CategoryId",
                table: "Snacks",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCartItens");

            migrationBuilder.DropTable(
                name: "Snacks");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
