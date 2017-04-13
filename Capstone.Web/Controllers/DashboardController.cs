﻿using System;
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

        public ActionResult AddItinerary(DashboardModel model)
        {
            ItineraryModel newItinModel = new ItineraryModel();
            bool itinInserted = new ItinerarySQLDAL().InsertNewItinerary(newItinModel);

            return View("Dashboard", model);
        }

        public ActionResult DeleteItinerary(int id)
        {
            ItineraryModel postDeletedModel = new ItinerarySQLDAL().GetItinerary(id);
            bool itinDeleted = new ItinerarySQLDAL().DeleteItinerary(postDeletedModel);
            if (itinDeleted)
            {
                DashboardModel dashboardNewView = new DashboardModel();
                dashboardNewView.Itineraries = new ItinerarySQLDAL().GetAllItineraries(postDeletedModel.User_Id);
            }
            return View("Dashboard", postDeletedModel);
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
