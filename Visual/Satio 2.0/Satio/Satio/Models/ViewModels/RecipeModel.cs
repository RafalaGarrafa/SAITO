using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Satio.Models.ViewModels
{
    public class RecipeModel
    {
        public string Username { get; set; }
        public List<RecipesViewModel> Recipes { get; set; }

    }

    public class RecipesViewModel
    {
        public string Name { get; set; }
        public string Steps { get; set; }
        public int PrepTime { get; set; }
        public int Difficulty { get; set; }
        public int Rating { get; set; }
    }
}
