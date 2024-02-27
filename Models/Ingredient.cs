using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeDBApi.Models {
    public class Ingredient {
        public long Id {get;set;}
        [Required]
        [ForeignKey("IngredientSublist")]
        public long IngredientSublistId {get;set;}
        public IngredientSublist? IngredientSublist {get;set;}
        [Required]
        public int Amount {get;set;}
        [Required]
        public string? Description {get;set;}
        [Required]
        public string? UnitOfMeasure {get;set;}
    }
}