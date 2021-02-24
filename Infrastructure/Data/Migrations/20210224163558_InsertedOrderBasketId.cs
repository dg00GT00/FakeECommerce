using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class InsertedOrderBasketId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_DeliveryMethods_DeliveryMethodId",
                schema: "Dev",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentIntentId",
                schema: "Dev",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DeliveryMethodId",
                schema: "Dev",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BuyerEmail",
                schema: "Dev",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BasketId",
                schema: "Dev",
                table: "Orders",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_DeliveryMethods_DeliveryMethodId",
                schema: "Dev",
                table: "Orders",
                column: "DeliveryMethodId",
                principalSchema: "Dev",
                principalTable: "DeliveryMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_DeliveryMethods_DeliveryMethodId",
                schema: "Dev",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BasketId",
                schema: "Dev",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentIntentId",
                schema: "Dev",
                table: "Orders",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "DeliveryMethodId",
                schema: "Dev",
                table: "Orders",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "BuyerEmail",
                schema: "Dev",
                table: "Orders",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

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
    }
}