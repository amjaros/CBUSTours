using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.DataAccess;
using Capstone.Web.Models;

namespace Capstone.Web.Controllers
{
    public class RouteController : Controller
    {
        // GET: Route
        public ActionResult RouteMap()
        {
            string itinerary = "1";
            LandmarkSQLDAL thisDAL = new LandmarkSQLDAL();
            List<LandmarkModel> LandmarkList = thisDAL.SelectLandmarksByItinerary(itinerary);
            return View("RouteMap", LandmarkList);
        }
        public ActionResult OtherRoute()
        {
            string itinerary = "1";
            LandmarkSQLDAL thisDAL = new LandmarkSQLDAL();
            List<LandmarkModel> LandmarkList = thisDAL.SelectLandmarksByItinerary(itinerary);
            return View("OtherRoute", LandmarkList);
        }
    }
}