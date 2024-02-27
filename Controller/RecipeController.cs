using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeDBApi.Models;
using RecipeDBApi.Models.DTOs;

namespace RecipeDBApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly RecipeContext _context;

        public RecipeController(RecipeContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipeDTO>>> AllRecipes()
        {
            var recipes = await _context.Recipes.ToListAsync();
            var recipeList = new List<RecipeDTO>();
            foreach(Recipe recipe in recipes)
            {
                RecipeVersion recipeVersion = await _context.RecipeVersions
                .Where(x => x.RecipeId == recipe.Id)
                .OrderByDescending(x => x.CreationDate).FirstAsync();
                recipeList.Add(RecipeToDTO(recipe,recipeVersion));
            }
            return recipeList;
        }
        [HttpPost]
        public async Task<IActionResult> NewRecipe(RecipeDTO newRecipe)
        {
            var recipe = new Recipe {
                Link = newRecipe.Link,
                Comment = newRecipe.Comment
            };
            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();
            var recipeVersion = new RecipeVersion{
                RecipeId = recipe.Id,
                Description = newRecipe.Description,
                Instructions = newRecipe.Instructions,
                Portions = newRecipe.Portions,
                PreparationInMinutes = newRecipe.PreparationInMinutes,
                CookingInMinutes = newRecipe.CookingInMinutes,
                CreationDate = DateTime.Now
            };
            _context.RecipeVersions.Add(recipeVersion);
            await _context.SaveChangesAsync();
            foreach (NewIngredientSublistDTO newIngredientSublist in newRecipe.IngredientSublist)
            {
                var ingredientSublist = new IngredientSublist {
                    RecipeVersionId = recipeVersion.Id,
                    Description = newIngredientSublist.Description
                };
                _context.IngredientSublists.Add(ingredientSublist);
                await _context.SaveChangesAsync();
                foreach (NewIngredientDTO newIngredient in newIngredientSublist.Ingredient)
                {
                    var ingredient = new Ingredient
                    {
                        IngredientSublistId = ingredientSublist.Id,
                        Amount = newIngredient.Amount,
                        Description = newIngredient.Description,
                        UnitOfMeasure = newIngredient.UnitOfMeasure,
                    };
                    _context.Ingredients.Add(ingredient);
                }
            }
            await _context.SaveChangesAsync();
            return Ok();
        }

        private RecipeDTO RecipeToDTO(Recipe recipe,RecipeVersion recipeVersion)
        {
            return new RecipeDTO{
                Id = recipe.Id,
                Link = recipe.Link,
                Comment = recipe.Comment,
                Description = recipeVersion.Description,
                Instructions = recipeVersion.Instructions,
                Portions = recipeVersion.Portions,
                PreparationInMinutes = recipeVersion.PreparationInMinutes,
                CookingInMinutes = recipeVersion.CookingInMinutes
            };
        }
    }
}