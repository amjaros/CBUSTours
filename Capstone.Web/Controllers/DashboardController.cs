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
        public ActionResult Dashboard(int id)
        {
            DashboardModel model = new DashboardModel();
            return View("Dashboard", model);
        }

        public ActionResult AddItinerary(DashboardModel model)
        {
            ItineraryModel newItinModel = new ItineraryModel();
            bool itinInserted = new ItinerarySQLDAL().InsertNewItinerary(newItinModel);

            return View("Dashboard", model);
        }

        public ActionResult DeleteItinerary(DashboardModel model, int itineraryId)
        {
            ItineraryModel postDeletedModel = new ItineraryModel();
            bool itinDeleted = new ItinerarySQLDAL().DeleteItinerary(postDeletedModel);

            return View("Dashboard", model);
        }
    }
}