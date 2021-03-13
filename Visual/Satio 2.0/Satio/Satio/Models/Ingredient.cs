using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Satio.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int IdFood { get; set; }


        public virtual Food Food { get; set; }
        public virtual ICollection<RecipeIngredient> RecipeIngredient { get; set; }

    }
}
