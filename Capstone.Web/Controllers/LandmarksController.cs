using System;
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
            return View("SearchLandmarks", ApprovedLandmarks);
        }

        public ActionResult LandmarkDetails(string landmarkID)
        {
            LandmarkSQLDAL DAL = new LandmarkSQLDAL();
            LandmarkModel selectedLandmark = DAL.GetLandmarkById(landmarkID);
            return View("LandmarkDetails", selectedLandmark);
        }
    }
}