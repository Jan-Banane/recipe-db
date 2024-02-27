using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeDBApi.Models {
    public class IngredientSublist {
        public long Id {get;set;}
        [Required]
        [ForeignKey("RecipeVersion")]
        public long RecipeVersionId {get;set;}
        public RecipeVersion? RecipeVersion {get;set;}
        public string? Description {get;set;}
        public virtual ICollection<Ingredient>? Ingredients { get; set; }

    }
}