using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommercePlateform.Migrations
{
    public partial class UpdatedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProducts",
                schema: "Identity");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                schema: "Identity",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                schema: "Identity",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId",
                schema: "Identity",
                table: "Orders",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_ProductId",
                schema: "Identity",
                table: "Orders",
                column: "ProductId",
                principalSchema: "Identity",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_ProductId",
                schema: "Identity",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ProductId",
                schema: "Identity",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ProductId",
                schema: "Identity",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Quantity",
                schema: "Identity",
                table: "Orders");

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                schema: "Identity",
                columns: table => new
                {
                    Order = table.Column<int>(type: "int", nullable: false),
                    OrdersOrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => new { x.Order, x.OrdersOrderId });
                    table.ForeignKey(
                        name: "FK_OrderProducts_Orders_OrdersOrderId",
                        column: x => x.OrdersOrderId,
                        principalSchema: "Identity",
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Products_Order",
                        column: x => x.Order,
                        principalSchema: "Identity",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_OrdersOrderId",
                schema: "Identity",
                table: "OrderProducts",
                column: "OrdersOrderId");
        }
    }
}
