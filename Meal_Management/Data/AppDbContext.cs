using Meal_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Meal_Management.Data
{
    public class AppDbContext:DbContext
    {
      public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
        
        }
        public DbSet<MealManagement> mealManagements { get; set; }
        public DbSet<Market> markets { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
