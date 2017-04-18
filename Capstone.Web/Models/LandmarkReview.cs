using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class LandmarkReview
    {
        public int ReviewID { get; set; }
        public bool Rating { get; set; }
        public string Description { get; set; }
    }
}