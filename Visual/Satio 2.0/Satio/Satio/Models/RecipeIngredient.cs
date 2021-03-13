using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Satio.Models
{
    public class RecipeIngredient
    {
        public int Id { get; set; }
        public int IdIngredient { get; set; }
        public int IdRecipe { get; set; }

        public virtual Ingredient Ingredient { get; set; }
        public virtual Recipe Recipe { get; set; }


    }
}
