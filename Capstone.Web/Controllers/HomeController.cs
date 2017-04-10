using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DataAccess;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View("Register");
        }

        [HttpGet]
        public ActionResult Login()
        {
            UserModel model = new UserModel();
            return View("Login", model);
        }

        [HttpPost]
        public ActionResult LoginHome(UserModel model)
        {
            //DAL method call to verify User and Return HomePageModel goes here. Just creating a true boolean for now
            bool userIsValid = false;
            if (!userIsValid)
            {
                model.EnteredInvalidLogin = true;
                return View("Login", model);
            }

            //Bring the signed in user to the homepage *Still may need to create the HomePageModel
            //*******Perform operations to return the right homepagemodel
            return View("HomePage");
        }

        [HttpPost]
        public ActionResult RegisterHome(UserModel model)
        {
            //DAL Method which returns a boolean if the user was properly registered in the database. Just putting a sample boolean for now.
            bool wasNewUserRegisteredSuccessfully = false;
            if(!wasNewUserRegisteredSuccessfully)
            {
                //This is assuming the model used for the register page is a simple boolean.
                model.EnteredInvalidLogin = true;
                return View("Register", model);
            }

            //Bring the newly registered user to his or her homepage. We'll need to create a HomePageModel to pass in.
            //*******Perform operations to return the right homepagemodel
            return View("HomePage");
        }
    }
}