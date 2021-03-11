using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class ChangeToSQLServer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Dev",
                table: "ProductTypes",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                    name: "Id",
                    schema: "Dev",
                    table: "ProductTypes",
                    nullable: false,
                    oldClrType: typeof(int),
                    oldType: "integer")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ProductTypeId",
                schema: "Dev",
                table: "Products",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ProductBrandId",
                schema: "Dev",
                table: "Products",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "PictureUrl",
                schema: "Dev",
                table: "Products",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Dev",
                table: "Products",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "Dev",
                table: "Products",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                    name: "Id",
                    schema: "Dev",
                    table: "Products",
                    nullable: false,
                    oldClrType: typeof(int),
                    oldType: "integer")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Dev",
                table: "ProductBrands",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                    name: "Id",
                    schema: "Dev",
                    table: "ProductBrands",
                    nullable: false,
                    oldClrType: typeof(int),
                    oldType: "integer")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "Subtotal",
                schema: "Dev",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                schema: "Dev",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentIntentId",
                schema: "Dev",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "OrderDate",
                schema: "Dev",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<int>(
                name: "DeliveryMethodId",
                schema: "Dev",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "BuyerEmail",
                schema: "Dev",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "BasketId",
                schema: "Dev",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ShipToAddress_ZipCode",
                schema: "Dev",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShipToAddress_Street",
                schema: "Dev",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShipToAddress_State",
                schema: "Dev",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShipToAddress_LastName",
                schema: "Dev",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShipToAddress_FirstName",
                schema: "Dev",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShipToAddress_City",
                schema: "Dev",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                    name: "Id",
                    schema: "Dev",
                    table: "Orders",
                    nullable: false,
                    oldClrType: typeof(int),
                    oldType: "integer")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "ItemOrdered_ProductName",
                schema: "Dev",
                table: "OrderItems",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ItemOrdered_ProductItemId",
                schema: "Dev",
                table: "OrderItems",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ItemOrdered_PictureUrl",
                schema: "Dev",
                table: "OrderItems",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                schema: "Dev",
                table: "OrderItems",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                schema: "Dev",
                table: "OrderItems",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                    name: "Id",
                    schema: "Dev",
                    table: "OrderItems",
                    nullable: false,
                    oldClrType: typeof(int),
                    oldType: "integer")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "ShortName",
                schema: "Dev",
                table: "DeliveryMethods",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "Dev",
                table: "DeliveryMethods",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryTime",
                schema: "Dev",
                table: "DeliveryMethods",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                    name: "Id",
                    schema: "Dev",
                    table: "DeliveryMethods",
                    nullable: false,
                    oldClrType: typeof(int),
                    oldType: "integer")
                .Annotation("SqlServer:Identity", "1, 1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Dev",
                table: "ProductTypes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                    name: "Id",
                    schema: "Dev",
                    table: "ProductTypes",
                    type: "integer",
                    nullable: false,
                    oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ProductTypeId",
                schema: "Dev",
                table: "Products",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ProductBrandId",
                schema: "Dev",
                table: "Products",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "PictureUrl",
                schema: "Dev",
                table: "Products",
                type: "text",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Dev",
                table: "Products",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "Dev",
                table: "Products",
                type: "text",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                    name: "Id",
                    schema: "Dev",
                    table: "Products",
                    type: "integer",
                    nullable: false,
                    oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Dev",
                table: "ProductBrands",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                    name: "Id",
                    schema: "Dev",
                    table: "ProductBrands",
                    type: "integer",
                    nullable: false,
                    oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "Subtotal",
                schema: "Dev",
                table: "Orders",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                schema: "Dev",
                table: "Orders",
                type: "text",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "PaymentIntentId",
                schema: "Dev",
                table: "Orders",
                type: "text",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "OrderDate",
                schema: "Dev",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTimeOffset));

            migrationBuilder.AlterColumn<int>(
                name: "DeliveryMethodId",
                schema: "Dev",
                table: "Orders",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "BuyerEmail",
                schema: "Dev",
                table: "Orders",
                type: "text",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "BasketId",
                schema: "Dev",
                table: "Orders",
                type: "text",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ShipToAddress_ZipCode",
                schema: "Dev",
                table: "Orders",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShipToAddress_Street",
                schema: "Dev",
                table: "Orders",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShipToAddress_State",
                schema: "Dev",
                table: "Orders",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShipToAddress_LastName",
                schema: "Dev",
                table: "Orders",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShipToAddress_FirstName",
                schema: "Dev",
                table: "Orders",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShipToAddress_City",
                schema: "Dev",
                table: "Orders",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                    name: "Id",
                    schema: "Dev",
                    table: "Orders",
                    type: "integer",
                    nullable: false,
                    oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "ItemOrdered_ProductName",
                schema: "Dev",
                table: "OrderItems",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ItemOrdered_ProductItemId",
                schema: "Dev",
                table: "OrderItems",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ItemOrdered_PictureUrl",
                schema: "Dev",
                table: "OrderItems",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                schema: "Dev",
                table: "OrderItems",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                schema: "Dev",
                table: "OrderItems",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                    name: "Id",
                    schema: "Dev",
                    table: "OrderItems",
                    type: "integer",
                    nullable: false,
                    oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "ShortName",
                schema: "Dev",
                table: "DeliveryMethods",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "Dev",
                table: "DeliveryMethods",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryTime",
                schema: "Dev",
                table: "DeliveryMethods",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                    name: "Id",
                    schema: "Dev",
                    table: "DeliveryMethods",
                    type: "integer",
                    nullable: false,
                    oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}