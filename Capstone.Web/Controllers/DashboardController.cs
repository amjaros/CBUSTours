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
        public ActionResult Dashboard(int id)
        {
            DashboardModel model = new DashboardModel();
            model.Itineraries = new ItinerarySQLDAL().GetAllItineraries(id);

            Session["sid"] = id;
            id = (int)Session["sid"];

            return View("Dashboard", model);
        }

        [HttpGet]
        public ActionResult ItineraryDetail(int id)
        {

            return RedirectToAction("ItineraryDetail", "Itinerary", new { id = id });
        }

        [HttpGet]
        public ActionResult LandmarkDetail(LandmarkModel model)
        {
            return View("LandmarkDetail", model);
        }

        public ActionResult AddItinerary(int id)
        {
            ItineraryModel newItinModel = new ItineraryModel();
            newItinModel.User_Id = id;
            bool itinInserted = new ItinerarySQLDAL().InsertNewItinerary(newItinModel);
            DashboardModel dashboardNewView = new DashboardModel();
            if (itinInserted)
            {
                dashboardNewView.Itineraries = new ItinerarySQLDAL().GetAllItineraries(newItinModel.User_Id);
            }
            return RedirectToAction("Dashboard", "Dashboard", new { id = newItinModel.User_Id });
        }

        public ActionResult DeleteItinerary(int id)
        {
            ItineraryModel postDeletedModel = new ItinerarySQLDAL().GetItinerary(id);
            postDeletedModel.Itinerary_id = id;
            bool itinDeleted = new ItinerarySQLDAL().DeleteItinerary(postDeletedModel);
            DashboardModel dashboardNewView = new DashboardModel();
            if (itinDeleted)
            {
                dashboardNewView.Itineraries = new ItinerarySQLDAL().GetAllItineraries(postDeletedModel.User_Id);
            }
            return RedirectToAction("Dashboard", "Dashboard", new { id = postDeletedModel.User_Id });
        }


        public void UserSession()
        {
            if (Session["sid"] == null)
            {
                int id = 0;
                Session["sid"] = id;
                id = (int)Session["sid"];
            }
        }
    }
}
