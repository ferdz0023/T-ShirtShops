using Microsoft.EntityFrameworkCore.Migrations;

namespace TShirtShop.Data.Migrations
{
    public partial class UpdateShirts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_Shirts_ShirtId",
                table: "ShoppingCartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shirts",
                table: "Shirts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Shirts");

            migrationBuilder.AlterColumn<int>(
                name: "ShirtId",
                table: "ShoppingCartItems",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ShirtId",
                table: "Shirts",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shirts",
                table: "Shirts",
                column: "ShirtId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_Shirts_ShirtId",
                table: "ShoppingCartItems",
                column: "ShirtId",
                principalTable: "Shirts",
                principalColumn: "ShirtId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_Shirts_ShirtId",
                table: "ShoppingCartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shirts",
                table: "Shirts");

            migrationBuilder.DropColumn(
                name: "ShirtId",
                table: "Shirts");

            migrationBuilder.AlterColumn<int>(
                name: "ShirtId",
                table: "ShoppingCartItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Shirts",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shirts",
                table: "Shirts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_Shirts_ShirtId",
                table: "ShoppingCartItems",
                column: "ShirtId",
                principalTable: "Shirts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
