using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class UpdatedOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_DeliveryMethods_DeliveryMethodId",
                schema: "Dev",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Order_OrderId",
                schema: "Dev",
                table: "OrderItem");

            migrationBuilder.DropTable(
                name: "ProductItemOrdered",
                schema: "Dev");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItem",
                schema: "Dev",
                table: "OrderItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                schema: "Dev",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "OrderItem",
                schema: "Dev",
                newName: "OrderItems",
                newSchema: "Dev");

            migrationBuilder.RenameTable(
                name: "Order",
                schema: "Dev",
                newName: "Orders",
                newSchema: "Dev");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItem_OrderId",
                schema: "Dev",
                table: "OrderItems",
                newName: "IX_OrderItems_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_DeliveryMethodId",
                schema: "Dev",
                table: "Orders",
                newName: "IX_Orders_DeliveryMethodId");

            migrationBuilder.AddColumn<string>(
                name: "ItemOrdered_PictureUrl",
                schema: "Dev",
                table: "OrderItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemOrdered_ProductItemId",
                schema: "Dev",
                table: "OrderItems",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemOrdered_ProductName",
                schema: "Dev",
                table: "OrderItems",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItems",
                schema: "Dev",
                table: "OrderItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                schema: "Dev",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                schema: "Dev",
                table: "OrderItems",
                column: "OrderId",
                principalSchema: "Dev",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_DeliveryMethods_DeliveryMethodId",
                schema: "Dev",
                table: "Orders",
                column: "DeliveryMethodId",
                principalSchema: "Dev",
                principalTable: "DeliveryMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                schema: "Dev",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_DeliveryMethods_DeliveryMethodId",
                schema: "Dev",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                schema: "Dev",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItems",
                schema: "Dev",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "ItemOrdered_PictureUrl",
                schema: "Dev",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "ItemOrdered_ProductItemId",
                schema: "Dev",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "ItemOrdered_ProductName",
                schema: "Dev",
                table: "OrderItems");

            migrationBuilder.RenameTable(
                name: "Orders",
                schema: "Dev",
                newName: "Order",
                newSchema: "Dev");

            migrationBuilder.RenameTable(
                name: "OrderItems",
                schema: "Dev",
                newName: "OrderItem",
                newSchema: "Dev");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_DeliveryMethodId",
                schema: "Dev",
                table: "Order",
                newName: "IX_Order_DeliveryMethodId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_OrderId",
                schema: "Dev",
                table: "OrderItem",
                newName: "IX_OrderItem_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                schema: "Dev",
                table: "Order",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItem",
                schema: "Dev",
                table: "OrderItem",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ProductItemOrdered",
                schema: "Dev",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(type: "integer", nullable: false),
                    PictureUrl = table.Column<string>(type: "text", nullable: true),
                    ProductItemId = table.Column<int>(type: "integer", nullable: false),
                    ProductName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductItemOrdered", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_ProductItemOrdered_OrderItem_OrderItemId",
                        column: x => x.OrderItemId,
                        principalSchema: "Dev",
                        principalTable: "OrderItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Order_DeliveryMethods_DeliveryMethodId",
                schema: "Dev",
                table: "Order",
                column: "DeliveryMethodId",
                principalSchema: "Dev",
                principalTable: "DeliveryMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Order_OrderId",
                schema: "Dev",
                table: "OrderItem",
                column: "OrderId",
                principalSchema: "Dev",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}