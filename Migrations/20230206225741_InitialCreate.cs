using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodDelivery.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuItemCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItemCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    MenuItemCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItem_MenuItemCategory_MenuItemCategoryId",
                        column: x => x.MenuItemCategoryId,
                        principalTable: "MenuItemCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MenuItemCategory",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Drinks" });

            migrationBuilder.InsertData(
                table: "MenuItemCategory",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "MainDish" });

            migrationBuilder.InsertData(
                table: "MenuItem",
                columns: new[] { "Id", "MenuItemCategoryId", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Coca Cola", 599m },
                    { 2, 1, "Suco de limão", 399m },
                    { 3, 2, "Big Burguer", 3999m },
                    { 4, 2, "Chicken Burguer", 3599m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuItem_MenuItemCategoryId",
                table: "MenuItem",
                column: "MenuItemCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuItem");

            migrationBuilder.DropTable(
                name: "MenuItemCategory");
        }
    }
}
