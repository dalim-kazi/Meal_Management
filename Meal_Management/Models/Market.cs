using System.ComponentModel.DataAnnotations;

namespace Meal_Management.Models
{
    public class Market
    {
        [Key]
        public int marketId { get; set; }

        public DateOnly marketDate { get; set; }

        [Required]
        public double totalDailyMarket { get; set; }

        [Required]
        public double totalDailyMeal { get; set; }

    }
}
