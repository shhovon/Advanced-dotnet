using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntroMVC.Controllers
{
    public class MyProfileController : Controller
    {
        // GET: MyProfile
        public ActionResult Homepage()
        {
            return View();
        }

        public ActionResult Education()
        {
            return View();
        }

        public ActionResult MyProjects()
        {
            return View();
        }
    }
}