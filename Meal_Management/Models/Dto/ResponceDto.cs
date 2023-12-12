namespace Meal_Management.Models.Dto
{
    public class ResponceDto
    {
        public object? Result { get; set; }
        public bool isSuccess { get; set; } = true;
        public string? Massage { get; set; }
    }
}
