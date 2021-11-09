using Microsoft.EntityFrameworkCore.Migrations;

namespace TShirtShop.Data.Migrations
{
    public partial class addedSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "SizeId", "Name" },
                values: new object[] { 1, "Small" });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "SizeId", "Name" },
                values: new object[] { 2, "Medium" });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "SizeId", "Name" },
                values: new object[] { 3, "Large" });

            migrationBuilder.InsertData(
                table: "Shirts",
                columns: new[] { "Id", "Description", "Gender", "ImageLocation", "ImageThumnNailLocation", "Name", "Price", "SizeId" },
                values: new object[,]
                {
                    { 3, "Java Developer", 1, "White_Tshirt.jpg", "White_Tshirt.jpg", "Java Developer", 500m, 1 },
                    { 1, "C# Developer", 1, "threadbird-logo-black.jpg", "threadbird-logo-black.jpg", "C# Developer", 500m, 2 },
                    { 2, "HTML", 1, "world-shirt_large.jpg", "world-shirt_large.jpg", "HTML", 500m, 3 },
                    { 4, "HTML", 1, "world-shirt_large.jpg", "world-shirt_large.jpg", "HTML", 500m, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "SizeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "SizeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "SizeId",
                keyValue: 3);
        }
    }
}
