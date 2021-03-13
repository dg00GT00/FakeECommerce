using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class InsertedBasketUserEmailKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Basket_BasketId",
                schema: "Dev",
                table: "Basket");

            migrationBuilder.DropColumn(
                name: "BasketId",
                schema: "Dev",
                table: "Basket");

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                schema: "Dev",
                table: "Basket",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserEmail",
                schema: "Dev",
                table: "Basket");

            migrationBuilder.AddColumn<string>(
                name: "BasketId",
                schema: "Dev",
                table: "Basket",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Basket_BasketId",
                schema: "Dev",
                table: "Basket",
                column: "BasketId");
        }
    }
}