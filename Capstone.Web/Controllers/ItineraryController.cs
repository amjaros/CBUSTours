using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.Models;

namespace Capstone.Web.Controllers
{
    public class ItineraryController : Controller
    {
        // GET: Itinerary
        [HttpGet]
        public ActionResult ItineraryDetail(ItineraryModel model)
        {
            return View("ItineraryDetail", model);
        }

        [HttpGet]
        public ActionResult SearchLandmarks()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddLandmark(LandmarkModel model)
        {
            return View("ItineraryDetail", model);
        }

        [HttpGet]
        public ActionResult DeleteLandmark(LandmarkModel model)
        {
            return View("ItineraryDetail", model);
        }


    }
}