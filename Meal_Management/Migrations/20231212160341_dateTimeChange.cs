using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Meal_Management.Migrations
{
    /// <inheritdoc />
    public partial class dateTimeChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "dateDate",
                table: "mealManagements",
                newName: "mealDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "mealDate",
                table: "mealManagements",
                newName: "dateDate");
        }
    }
}
