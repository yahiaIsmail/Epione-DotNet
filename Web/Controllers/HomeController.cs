using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Data.Models;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
          //  HttpClient Client = new HttpClient();
           // Client.BaseAddress = new Uri("http://localhost:18080/");
           // Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
           // HttpResponseMessage response = Client.GetAsync("JAVAEE-web/rest/users/registereddoctors").Result;
            
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {

            UserViewModel u = new UserViewModel();

            u.email = collection["email"];
            u.password = collection["password"];


            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080/");

            HttpResponseMessage response = client.PostAsJsonAsync<UserViewModel>("JAVAEE-web/rest/users/auth", u).Result;
            if (response.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            else
            {

                ViewBag.result = "failed authetication";
            }
            return View();
        }



        public ActionResult Register()
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