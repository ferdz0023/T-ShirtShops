using Microsoft.EntityFrameworkCore.Migrations;

namespace TShirtShop.Data.Migrations
{
    public partial class AddedIsActiveDefaultValue_InsteadNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "SizeId",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "SizeId",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "SizeId",
                keyValue: 3,
                column: "IsActive",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "SizeId",
                keyValue: 1,
                column: "IsActive",
                value: false);

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "SizeId",
                keyValue: 2,
                column: "IsActive",
                value: false);

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "SizeId",
                keyValue: 3,
                column: "IsActive",
                value: false);
        }
    }
}
