using Microsoft.EntityFrameworkCore.Migrations;

namespace TShirtShop.Data.Migrations
{
    public partial class AddedIsActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Shirts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Shirts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Shirts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Shirts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Sizes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Shirts",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Shirts");

            migrationBuilder.InsertData(
                table: "Shirts",
                columns: new[] { "Id", "Description", "Gender", "ImageLocation", "ImageThumnNailLocation", "Name", "Price", "SizeId" },
                values: new object[,]
                {
                    { 1, "C# Developer", 1, "threadbird-logo-black.jpg", "threadbird-logo-black.jpg", "C# Developer", 500m, 2 },
                    { 2, "HTML", 1, "world-shirt_large.jpg", "world-shirt_large.jpg", "HTML", 500m, 3 },
                    { 3, "Java Developer", 1, "White_Tshirt.jpg", "White_Tshirt.jpg", "Java Developer", 500m, 1 },
                    { 4, "HTML", 1, "world-shirt_large.jpg", "world-shirt_large.jpg", "HTML", 500m, 3 }
                });
        }
    }
}
