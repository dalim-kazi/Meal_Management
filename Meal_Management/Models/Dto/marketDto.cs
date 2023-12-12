using System.ComponentModel.DataAnnotations;

namespace Meal_Management.Models.Dto
{
    public class marketDto
    {
        public int marketId { get; set; }

        public DateOnly marketDate {  get; set; }

        public double totalDailyMarket { get; set; }

        public double totalDailyMeal { get; set; }
        public double totalMeal { get; set; }
        public double totalMarket { get; set; }
        public double totalMealRate { get; set;}
        public double DailyMealRate { get; set; }
    }
}
