using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Satio.Models
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdFood { get; set; }
        public virtual Ingredient Ingredient { get; set; }

    }
}
