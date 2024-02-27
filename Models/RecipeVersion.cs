using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeDBApi.Models {
    public class RecipeVersion {
        public long Id {get;set;}
        [Required]
        [ForeignKey("Recipe")]
        public long RecipeId {get;set;}
        public Recipe? Recipe {get;set;}
        [Required]
        public string? Description {get;set;}
        [Required]
        public string? Instructions {get;set;}
        public int Portions {get;set;}
        public int PreparationInMinutes {get;set;}
        public int CookingInMinutes {get;set;}
        [Required]
        public DateTime CreationDate {get;set;}
        public virtual ICollection<IngredientSublist>? IngredientSublists { get; set; }

    }
}