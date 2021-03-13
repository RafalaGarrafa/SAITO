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
        public int Difficulty { get; set; }
        public int Raiting { get; set; }
        public int IdOwnerUser { get; set; }


        public virtual ICollection<RegisteredUser> RegisteredUsers { get; set; }
        public virtual ICollection<Ingredient> Ingredients { get; set; }
        public virtual ICollection<Warning> Warnings { get; set; }




    }
}
