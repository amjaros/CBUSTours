using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class LandmarkModel
    {
        public string name { get; set; }

        public string address { get; set; }

        public string description { get; set; }

        public string image { get; set; }

        public bool approved { get; set; }

    }
}