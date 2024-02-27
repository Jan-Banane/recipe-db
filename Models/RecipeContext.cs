using Microsoft.EntityFrameworkCore;
namespace RecipeDBApi.Models {
    public class RecipeContext : DbContext {
    public RecipeContext(DbContextOptions<RecipeContext> options) : base(options)
    {

    }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<RecipeVersion> RecipeVersions { get; set; }
    public DbSet<IngredientSublist> IngredientSublists { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    }
}