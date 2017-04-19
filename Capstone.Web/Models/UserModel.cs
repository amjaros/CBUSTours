using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class UserModel
    {
        public string User_name { get; set; }
        public string User_email { get; set; }
        public string User_password { get; set; }
        public bool EnteredInvalidLogin { get; set; }
    }
}