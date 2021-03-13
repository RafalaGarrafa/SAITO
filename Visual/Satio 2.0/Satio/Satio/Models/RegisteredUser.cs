using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Satio.Models
{
    public class RegisteredUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ProfilePicture { get; set; }
        public int IdConctactInfo { get; set; }


        public virtual ContactInfo ContactInfo { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
        public virtual ICollection<RegisteredUserRecipe> RegisteredUserRecipe { get; set; }

    }
}
