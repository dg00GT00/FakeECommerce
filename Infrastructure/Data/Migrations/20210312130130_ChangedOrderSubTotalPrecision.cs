using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class ChangedOrderSubTotalPrecision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Dev");

            migrationBuilder.CreateTable(
                name: "DeliveryMethods",
                schema: "Dev",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortName = table.Column<string>(nullable: true),
                    DeliveryTime = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_DeliveryMethods", x => x.Id); });

            migrationBuilder.CreateTable(
                name: "ProductBrands",
                schema: "Dev",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_ProductBrands", x => x.Id); });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                schema: "Dev",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_ProductTypes", x => x.Id); });

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "Dev",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BasketId = table.Column<string>(nullable: false),
                    BuyerEmail = table.Column<string>(nullable: false),
                    OrderDate = table.Column<DateTimeOffset>(nullable: false),
                    ShipToAddress_FirstName = table.Column<string>(nullable: true),
                    ShipToAddress_LastName = table.Column<string>(nullable: true),
                    ShipToAddress_Street = table.Column<string>(nullable: true),
                    ShipToAddress_City = table.Column<string>(nullable: true),
                    ShipToAddress_State = table.Column<string>(nullable: true),
                    ShipToAddress_ZipCode = table.Column<string>(nullable: true),
                    DeliveryMethodId = table.Column<int>(nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(nullable: false),
                    PaymentIntentId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_DeliveryMethods_DeliveryMethodId",
                        column: x => x.DeliveryMethodId,
                        principalSchema: "Dev",
                        principalTable: "DeliveryMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "Dev",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PictureUrl = table.Column<string>(nullable: false),
                    ProductTypeId = table.Column<int>(nullable: false),
                    ProductBrandId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductBrands_ProductBrandId",
                        column: x => x.ProductBrandId,
                        principalSchema: "Dev",
                        principalTable: "ProductBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalSchema: "Dev",
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                schema: "Dev",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemOrdered_ProductItemId = table.Column<int>(nullable: true),
                    ItemOrdered_ProductName = table.Column<string>(nullable: true),
                    ItemOrdered_PictureUrl = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "Dev",
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                schema: "Dev",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryMethodId",
                schema: "Dev",
                table: "Orders",
                column: "DeliveryMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductBrandId",
                schema: "Dev",
                table: "Products",
                column: "ProductBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypeId",
                schema: "Dev",
                table: "Products",
                column: "ProductTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems",
                schema: "Dev");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "Dev");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "Dev");

            migrationBuilder.DropTable(
                name: "ProductBrands",
                schema: "Dev");

            migrationBuilder.DropTable(
                name: "ProductTypes",
                schema: "Dev");

            migrationBuilder.DropTable(
                name: "DeliveryMethods",
                schema: "Dev");
        }
    }
}