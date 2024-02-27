using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeDBApi.Models.DTOs {
    public class RecipeDTO {
        public long Id {get;set;}
        public Uri? Link {get;set;}
        public string? Comment {get;set;}
        public string? Description {get;set;}
        public string? Instructions {get;set;}
        public int Portions {get;set;}
        public int PreparationInMinutes {get;set;}
        public int CookingInMinutes {get;set;}
        public virtual ICollection<NewIngredientSublistDTO>? IngredientSublist { get; set; }

    }
    public class NewIngredientSublistDTO {
        public string? Description {get;set;}
        public virtual ICollection<NewIngredientDTO>? Ingredient { get; set; }
    }
    public class NewIngredientDTO {
        public int Amount {get;set;}
        public string? Description {get;set;}
        public string? UnitOfMeasure {get;set;}
    }
}