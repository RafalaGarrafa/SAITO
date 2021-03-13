using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Satio.Models
{
    public class RegisteredUserRecipe
    {
        public int Id { get; set; }
        public int IdRegisteredUser { get; set; }
        public int IdRecipe { get; set; }

        public virtual  RegisteredUser RegisteredUser{ get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
