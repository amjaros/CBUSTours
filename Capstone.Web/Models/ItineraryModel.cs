using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class ItineraryModel
    {
        public string Name { get; set; }
        public int Itinerary_id { get; set; }
        public string Starting_point { get; set; }
        public List<LandmarkModel> Landmarks { get; set; }
    }
}