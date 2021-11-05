using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ThAmCo.Catering.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodItem",
                columns: table => new
                {
                    FoodItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: false),
                    UnitPrice = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItem", x => x.FoodItemId);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    MenuId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MenuName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.MenuId);
                });

            migrationBuilder.CreateTable(
                name: "FoodBooking",
                columns: table => new
                {
                    FoodBookingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientReferenceId = table.Column<int>(nullable: false),
                    NumberOfGuests = table.Column<int>(nullable: false),
                    MenuId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodBooking", x => x.FoodBookingId);
                    table.ForeignKey(
                        name: "FK_FoodBooking_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuFoodItem",
                columns: table => new
                {
                    MenuId = table.Column<int>(nullable: false),
                    FoodItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuFoodItem", x => new { x.MenuId, x.FoodItemId });
                    table.ForeignKey(
                        name: "FK_MenuFoodItem_FoodItem_FoodItemId",
                        column: x => x.FoodItemId,
                        principalTable: "FoodItem",
                        principalColumn: "FoodItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuFoodItem_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FoodItem",
                columns: new[] { "FoodItemId", "Description", "UnitPrice" },
                values: new object[,]
                {
                    { 1, "Veggie Burger", 8.99f },
                    { 2, "Chicken Burger", 6.99f },
                    { 3, "Cheese Burger", 5.99f },
                    { 4, "Fettucini Alfredo", 10.99f },
                    { 5, "Cheese Toastie", 2.99f },
                    { 6, "Trifle", 3.99f },
                    { 7, "Banoffee Pudding", 3.99f }
                });

            migrationBuilder.InsertData(
                table: "Menu",
                columns: new[] { "MenuId", "MenuName" },
                values: new object[,]
                {
                    { 1, "Burgers" },
                    { 2, "Vegetarian" },
                    { 3, "Dessert" }
                });

            migrationBuilder.InsertData(
                table: "FoodBooking",
                columns: new[] { "FoodBookingId", "ClientReferenceId", "MenuId", "NumberOfGuests" },
                values: new object[,]
                {
                    { 1, 1, 1, 5 },
                    { 2, 2, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "MenuFoodItem",
                columns: new[] { "MenuId", "FoodItemId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 1 },
                    { 2, 4 },
                    { 2, 7 },
                    { 3, 6 },
                    { 3, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodBooking_MenuId",
                table: "FoodBooking",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuFoodItem_FoodItemId",
                table: "MenuFoodItem",
                column: "FoodItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodBooking");

            migrationBuilder.DropTable(
                name: "MenuFoodItem");

            migrationBuilder.DropTable(
                name: "FoodItem");

            migrationBuilder.DropTable(
                name: "Menu");
        }
    }
}
