using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Satio.Models.ViewModels
{
    public class UserInfoModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ProfilePicture { get; set; }

        public ContactInfoViewModel ContactInfo { get; set; }
    }


    public class ContactInfoViewModel
    {
        public string YouTube { get; set; }
        public string Instagram { get; set; }
        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public string WebPage { get; set; }
    }
    
}
