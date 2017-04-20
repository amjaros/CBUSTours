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
        public ActionResult RouteMap(int id)
        {
            string ItinID = id.ToString(); 
            LandmarkSQLDAL thisDAL = new LandmarkSQLDAL();
            List<LandmarkModel> LandmarkList = thisDAL.SelectLandmarksByItinerary(ItinID);
            return View("RouteMap", LandmarkList);
        }
        public ActionResult OtherRoute(int id)
        {
            ItinerarySQLDAL thatDAL = new ItinerarySQLDAL();
            ItineraryModel IM = new ItineraryModel();
            IM = thatDAL.GetItinerary(id);
            return View("OtherRoute", IM);
        }

        public ActionResult LandmarkDistance(int id)
        {
            LandmarkSQLDAL thisDAL = new LandmarkSQLDAL();
            ItinerarySQLDAL thatDAL = new ItinerarySQLDAL();
            List<LandmarkModel> LandmarkList = thisDAL.GetApprovedLandmarks();
            ItineraryModel IM = new ItineraryModel();
            IM = thatDAL.GetItinerary(id);
            IM.Landmarks = LandmarkList;
            return View("LandmarkDistance", IM);
        }
    
    }
}