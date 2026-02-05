using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
namespace MIDTERM_Q3_32E3_YuanJasper_Rodriguez.Data;
public class ResourceDbContext(DbContextOptions<ResourceDbContext> options) : DbContext(options)
{
    public DbSet<Recipe> Recipes { get; set; } = default!;
    public DbSet<Ingredient> Ingredients { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Seed initial data
        modelBuilder.Entity<Recipe>().HasData(new Recipe
        {
            Id = 1,
            Title = "Chicken Adobo",
            InternalComments = "Grandma's secret",
            Instruction = "Combine and simmer."
        });
    }
}
}
