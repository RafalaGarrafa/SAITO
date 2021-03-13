using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Satio.Models
{
    public class RecipeWarning
    {
        public int Id { get; set; }
        public int IdWarning { get; set; }
        public int IdRecipe { get; set; }

        public virtual Warning Warning { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
