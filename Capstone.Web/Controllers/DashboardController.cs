using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.Models;

namespace Capstone.Web.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Dashboard(DashboardModel model)
        {
            return View("Dashboard", model);
        }

        public ActionResult Itinerary()
        {
            ItineraryModel model = new ItineraryModel();

            return View("Itinerary", model);
        }
    }
}