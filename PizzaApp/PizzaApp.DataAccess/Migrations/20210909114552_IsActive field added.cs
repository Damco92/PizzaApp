using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaApp.DataAccess.Migrations
{
    public partial class IsActivefieldadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Pizzas",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Pizzas");
        }
    }
}
