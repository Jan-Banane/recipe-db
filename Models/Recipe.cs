using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeDBApi.Models {
    public class Recipe {
        public long Id {get;set;}

        public Uri? Link {get;set;}
        public string? Comment {get;set;}

        public virtual ICollection<RecipeVersion>? RecipeVersions { get; set; }
    }
}