using Microsoft.EntityFrameworkCore.Migrations;

namespace TShirtShop.Data.Migrations
{
    public partial class AddedForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_Shirts_ShirtId",
                table: "ShoppingCartItems");

            migrationBuilder.AlterColumn<int>(
                name: "ShirtId",
                table: "ShoppingCartItems",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_Shirts_ShirtId",
                table: "ShoppingCartItems",
                column: "ShirtId",
                principalTable: "Shirts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_Shirts_ShirtId",
                table: "ShoppingCartItems");

            migrationBuilder.AlterColumn<int>(
                name: "ShirtId",
                table: "ShoppingCartItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_Shirts_ShirtId",
                table: "ShoppingCartItems",
                column: "ShirtId",
                principalTable: "Shirts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
