using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Satio.Models
{
    public class ContactInfo
    {
        public int Id { get; set; }
        public string YouTube { get; set; }
        public string Instagram { get; set; }
        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public string WebPage { get; set; }

        public virtual ICollection<RegisteredUser> RegisteredUsers { get; set; }

    }
}
