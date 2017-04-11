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
            UserLoginModel model = new UserLoginModel();
            return View("Login", model);
        }

        [HttpPost]
        public ActionResult LoginHome(UserLoginModel model)
        {
            if (ModelState.IsValid)
            {
                //DAL method call to verify User and Return the user's 
                UserLoginModel thisUser = new UserSQLDAL().LoginUser(model.Username, model.Password);
                if (thisUser == null)
                {
                    model.EnteredInvalidLogin = true;
                    return View("Login", model);
                }
                else
                {
                    model = thisUser;
                }

                //Bring the signed in user to the homepage *Still may need to create the HomePageModel
                //*******Perform operations to return the right homepagemodel
                return View("HomePage");
            }
            else
            {
                ModelState.AddModelError("invalid-login", "the username and password combination is not valid.");
                return View("Login", model);
            }

        }

        [HttpPost]
        public ActionResult RegisterHome(UserRegisterModel model)
        {
            if(ModelState.IsValid)
            {
                //DAL Method which returns a boolean if the user was properly registered in the database. Just putting a sample boolean for now.
                bool wasNewUserRegisteredSuccessfully = new UserSQLDAL().RegisterUser(model);
                if (!wasNewUserRegisteredSuccessfully)
                {
                    //This is assuming the model used for the register page is a simple boolean.
                    model.EnteredInvalidLogin = true;
                    return View("Register", model);
                }

                //Bring the newly registered user to his or her homepage. We'll need to create a HomePageModel to pass in.
                //*******Perform operations to return the right homepagemodel
                return View("HomePage");
            }
            else
            {
                ModelState.AddModelError("invalid-registration", "Invalid email, username and password combination. Please try again.");
                return View("Register", model);
            }
            
        }
    }
}