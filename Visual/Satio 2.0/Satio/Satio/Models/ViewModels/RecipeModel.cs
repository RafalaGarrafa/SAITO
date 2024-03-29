﻿using System;
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

        public List<WarningViewModel> Warnings { get; set; }

        public List<IngredientViewModel> Ingredients { get; set; }
    }

    public class IngredientViewModel
    {
        public int Quantity { get; set; }

        public FoodViewModel Food { get; set; }
    }
    public class WarningViewModel
    {
        public string Description { get; set; }
        public int ThreatLevel { get; set; }
    }

    public class FoodViewModel
    {
        public string Name { get; set; }
    }
}
