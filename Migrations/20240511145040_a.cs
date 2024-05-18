using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce_WebSite.Migrations
{
    /// <inheritdoc />
    public partial class a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isDeliver",
                table: "Orders",
                newName: "isAccept");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isAccept",
                table: "Orders",
                newName: "isDeliver");
        }
    }
}
