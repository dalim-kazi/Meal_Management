using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Meal_Management.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "markets",
                columns: table => new
                {
                    marketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    marketDate = table.Column<DateOnly>(type: "date", nullable: false),
                    totalDailyMarket = table.Column<double>(type: "float", nullable: false),
                    totalDailyMeal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_markets", x => x.marketId);
                });

            migrationBuilder.CreateTable(
                name: "mealManagements",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateDate = table.Column<DateOnly>(type: "date", nullable: false),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    meal = table.Column<int>(type: "int", nullable: false),
                    deposit = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mealManagements", x => x.userId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "markets");

            migrationBuilder.DropTable(
                name: "mealManagements");
        }
    }
}
