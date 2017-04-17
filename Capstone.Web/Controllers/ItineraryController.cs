using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.DataAccess;
using Capstone.Web.Models;

namespace Capstone.Web.Controllers
{
    public class ItineraryController : Controller
    {
        // GET: Itinerary
        [HttpGet]
        public ActionResult ItineraryDetail(int id)
        {
            ItineraryModel model = new ItinerarySQLDAL().GetItinerary(id);
            return View("ItineraryDetail", model);
        }

        public ActionResult ItineraryDetailForAddLandmark(int id)
        {
            ItineraryModel model = new ItinerarySQLDAL().GetItinerary(id);
            return View("ItineraryDetail", model);
        }

        [HttpGet]
        public ActionResult AddLandmark(LandmarkModel model)
        {
            return View("ItineraryDetail", model);
        }

        [HttpGet]
        public ActionResult DeleteLandmark(int id, int itineraryId)
        {
            bool landmarkDeleted = new LandmarkSQLDAL().DeleteLandmarkFromItinerary(id.ToString(), itineraryId.ToString());

            ItineraryModel model = new ItinerarySQLDAL().GetItinerary(itineraryId);

            return View("ItineraryDetail", model);
        }
    }
}
