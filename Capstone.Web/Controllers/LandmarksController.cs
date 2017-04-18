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

        public ActionResult LandmarkDetails(int id)
        {
            LandmarkSQLDAL DAL = new LandmarkSQLDAL();
            LandmarkModel selectedLandmark = DAL.GetLandmarkById(id);
            ReviewSQLDAL reviewDAL = new ReviewSQLDAL();
            selectedLandmark.Reviews = reviewDAL.GetAllReviews(id);
            return View("LandmarkDetails", selectedLandmark);
        }

        public ActionResult AddLandmarkToItinerary(int id)
        {
            int itineraryID = (int)(Session["itinId"]);
            if (!(itineraryID == 0))
            {
                LandmarkSQLDAL DAL = new LandmarkSQLDAL();
                if (!DAL.isLandmarkAlreadyInItinerary(id, itineraryID))
                {
                    bool landmarkAdded = DAL.InsertLandmarkIntoItinerary(id, itineraryID);
                }
                return RedirectToAction("ItineraryDetailForAddLandmark", "Itinerary", new { id = itineraryID });
            }
            else
            {
                return RedirectToAction("LoginOrRegister", "Home", new { id = id });
            }
        }

        public ActionResult EnterNewLandmarkSuggestion()
        {
            LandmarkModel newLandmarkSuggestion = new LandmarkModel();
            newLandmarkSuggestion.name = Request.Params["Name"];
            newLandmarkSuggestion.address = Request.Params["Address"];
            newLandmarkSuggestion.description = Request.Params["Description"];
            bool suggestionEntered = new LandmarkSQLDAL().InsertSuggestedLandmark(newLandmarkSuggestion);
            return View("LandmarkSuggestionAccepted", newLandmarkSuggestion);
        }

    }
}