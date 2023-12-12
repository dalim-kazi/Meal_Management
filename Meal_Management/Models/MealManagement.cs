using System.ComponentModel.DataAnnotations;

namespace Meal_Management.Models
{
    public class MealManagement
    {
        [Key]
        public int userId { get; set; }

        public DateOnly mealDate { get; set; }

        [Required]
        public string? userName { get; set; }

        [Required]
        public string? email { get; set; }

        [Required]
        public int meal {  get; set; }

        [Required]
        public double deposit { get; set; }
    }
}
