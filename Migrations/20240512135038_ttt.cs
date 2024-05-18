using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce_WebSite.Migrations
{
    /// <inheritdoc />
    public partial class ttt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "DiscountValue",
                table: "Products",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "StatusDiscount",
                table: "Products",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "priceAfterDiscount",
                table: "Products",
                type: "float",
                nullable: true);

            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountValue",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "StatusDiscount",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "priceAfterDiscount",
                table: "Products");

           

            
        }
    }
}
