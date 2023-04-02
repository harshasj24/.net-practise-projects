using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Groceries.Migrations
{
    /// <inheritdoc />
    public partial class groapp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroceriesTable",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    groceriename = table.Column<string>(name: "grocerie_name", type: "nvarchar(max)", nullable: false),
                    grocerieprice = table.Column<string>(name: "grocerie_price", type: "nvarchar(max)", nullable: false),
                    groceriesdecription = table.Column<string>(name: "groceries_decription", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroceriesTable", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "UsersTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersTable", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroceriesTable");

            migrationBuilder.DropTable(
                name: "UsersTable");
        }
    }
}
