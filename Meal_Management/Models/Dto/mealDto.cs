using System.ComponentModel.DataAnnotations;

namespace Meal_Management.Models.Dto
{
    public class mealDto
    {
        public int userId { get; set; }
        public DateOnly dateTime { get; set; }

        public string? userName { get; set; }

        public string? email { get; set; }

        public int meal { get; set; }

        public int totalMeal { get; set; }

        public double deposit { get; set; }

        public double totalDeposit { get; set; }

        public double due { get; set; }

        public double refund { get; set;}

        public double totalCost { get; set; }
        public double mealRate { get; set; }
    }
}
