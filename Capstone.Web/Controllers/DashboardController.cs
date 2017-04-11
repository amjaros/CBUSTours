using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DataAccess;

namespace Capstone.Web.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        [HttpGet]
        public ActionResult Dashboard(DashboardModel model)
        {
            return View("Dashboard", model);
        }

        [HttpGet]
        public ActionResult ItineraryDetail(int id)
        {
            List<LandmarkModel> landmarks = new LandmarkModel().SelectLandmarksByItinerary(id.ToString());

            ItineraryModel model = new ItineraryModel();
            model.Landmarks = landmarks;

            return View("Itinerary", model);
        }

        [HttpGet]
        public ActionResult LandmarkDetail(LandmarkModel model)
        {
            return View("LandmarkDetail", model);
        }
    }
}