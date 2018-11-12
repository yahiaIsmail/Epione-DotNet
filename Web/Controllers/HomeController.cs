using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Data.Models;

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
        [HttpGet]
        public ActionResult Create()
        {
            return View("create");
        }

        [HttpPost]
        public ActionResult Create(user u)
        {
            System.Diagnostics.Debug.WriteLine(u.email);

            System.Diagnostics.Debug.WriteLine(u.password);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            // client.PostAsJsonAsync<DemandeViewModel>("Epione-web/rest/doctolib/ajoutDemande", demande).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());

            client.PostAsJsonAsync("JAVAEE-web/rest/users/auth", u);
            //.ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());

            return RedirectToAction("Index");
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