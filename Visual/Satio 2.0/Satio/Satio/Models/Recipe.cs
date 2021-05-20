using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Satio.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Steps { get; set; }
        public int PrepTime { get; set; }
        public Int16 Difficulty { get; set; }
        public Int16 Rating { get; set; }
        public int IdOwnerUser { get; set; }


        public virtual RegisteredUser RegisteredUser { get; set; }
        public virtual ICollection<RegisteredUserRecipe> RegisteredUserRecipe { get; set; }
        public virtual ICollection<RecipeIngredient> RecipeIngredient { get; set; }
        public virtual ICollection<RecipeWarning> RecipeWarning { get; set; }




    }
}
