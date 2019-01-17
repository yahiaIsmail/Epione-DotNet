using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Data.Models;
using Web.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

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
            string str;
            user us= new user();
            JObject json;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080/");

            HttpResponseMessage response = client.PostAsJsonAsync<UserViewModel>("JAVAEE-web/rest/users/auth", u).Result;
            if (response.IsSuccessStatusCode)
            {


                str = response.Content.ReadAsStringAsync().Result;
                json= JObject.Parse(str);
                var result = JsonConvert.DeserializeObject<user>(str);
                Session["id"] = result.id;
                Session["firstName"] = result.firstName;
                Session["lastName"] = result.lastName;
                Session["username"] = result.username;
                Session["email"] = result.email;
                Session["role"] = result.role;
                Session["url"] = result.UrlPhoto;

                ViewBag.result = Session["role"];
                if (result.role.Equals("Admin"))
                {
                    return Redirect("../BackOfficeHome/Index");
                }
                else if (result.role.Equals("Patient"))
                {
                    return RedirectToAction("Index");
                }
                else if (result.role.Equals("Doctor"))
                {
                    return Redirect("../DoctorHome/Index");
                }
                //ViewBag.result = Session["role"];

            }
            else
            {

                ViewBag.result = "failed authetication";
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
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