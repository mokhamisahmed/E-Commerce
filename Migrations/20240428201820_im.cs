using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce_WebSite.Migrations
{
    /// <inheritdoc />
    public partial class im : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image_path",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image_path",
                table: "Products");
        }
    }
}
