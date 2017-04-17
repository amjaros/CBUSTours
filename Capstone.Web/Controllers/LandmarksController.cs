﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.DataAccess;
using Capstone.Web.Models;

namespace Capstone.Web.Controllers
{
    public class LandmarksController : Controller
    {
        // GET: Landmarks
        public ActionResult SearchLandmarks()
        {
            LandmarkSQLDAL DAL = new LandmarkSQLDAL();
            List<LandmarkModel> ApprovedLandmarks = DAL.GetApprovedLandmarks();
            ItineraryModel itinModel = new ItineraryModel();
            itinModel.Landmarks = ApprovedLandmarks;
            return View("SearchLandmarks", itinModel);
        }

        public ActionResult SearchLandmarksWithItin(int id)
        {
            LandmarkSQLDAL DAL = new LandmarkSQLDAL();
            List<LandmarkModel> ApprovedLandmarks = DAL.GetApprovedLandmarks();
            ItineraryModel itinModel = new ItineraryModel();
            itinModel.Itinerary_id = id;
            itinModel.Landmarks = ApprovedLandmarks;
            return View("SearchLandmarks", itinModel);
        }

        public ActionResult LandmarkDetails(string id)
        {
            LandmarkSQLDAL DAL = new LandmarkSQLDAL();
            LandmarkModel selectedLandmark = DAL.GetLandmarkById(id);
            return View("LandmarkDetails", selectedLandmark);
        }

        public ActionResult AddLandmarkToItinerary(int id)
        {
            int itineraryID = (int)(Session["itinId"]);
            if (itineraryID == 0)
            {
                return RedirectToAction("LoginOrRegister", "Home", id);
            }
            if (!(itineraryID == 0))
            {
                LandmarkSQLDAL DAL = new LandmarkSQLDAL();
                bool landmarkAdded = DAL.InsertLandmarkIntoItinerary(id, itineraryID);
                return RedirectToAction("Iti")

            }
        }
    }
}