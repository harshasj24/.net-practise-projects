using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Groceries.Migrations
{
    /// <inheritdoc />
    public partial class imageurl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imgUrl",
                table: "GroceriesTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imgUrl",
                table: "GroceriesTable");
        }
    }
}
