﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Demande()
        {
            return View();
        }
        public ActionResult allDoctors()
        {
            return View();
        }

        public ActionResult singleDoctor()
        {
            return View();
        }


        /*

           public ActionResult About()
           {
               ViewBag.Message = "Your application description page.";

               return View();
           }

           public ActionResult Contact()
           {
               ViewBag.Message = "Your contact page.";

               return View();
           }
        */
    }
}