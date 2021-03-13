using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Satio.Models
{
    public class Warning
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int ThreatLevel { get; set; }

        public virtual ICollection<RecipeWarning> RecipeWarning { get; set; }

    }
}
