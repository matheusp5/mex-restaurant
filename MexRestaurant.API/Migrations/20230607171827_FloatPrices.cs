using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MexRestaurant.API.Migrations
{
    /// <inheritdoc />
    public partial class FloatPrices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "Products",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<float>(
                name: "Total",
                table: "CartProducts",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "CartProducts",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float");
        }
    }
}
