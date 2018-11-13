using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class DemandeController : Controller
    {
        
        // GET: Demande
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult allDemands()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("JAVAEE-web/rest/admin/demandes").Result;

            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<demande>>().Result;
            }
            else
            {
                ViewBag.result = "error";
            }
            return View();
        }


        //Add demand

        public ActionResult Demande()
        {

            
            return View();
            
        }
        [HttpGet]
        public ActionResult CreateDemand()
        {

            return View();

        }

        [HttpPost]
        public ActionResult CreateDemand(FormCollection collection)
        {
            /*
            

            */


            demande d = new demande();

            d.email = collection["email"];
            d.firstName = collection["firstName"];
            d.lastName = collection["lastName"];
            d.speciality = collection["speciality"];
            d.state = collection["state"];



            System.Diagnostics.Debug.WriteLine(collection["email"]);
            System.Diagnostics.Debug.WriteLine(collection["firstName"]);
            System.Diagnostics.Debug.WriteLine(collection["lastName"]);
            System.Diagnostics.Debug.WriteLine(collection["speciality"]);
            System.Diagnostics.Debug.WriteLine(collection["state"]);



           // try
         //   {
                // TODO: Add insert logic here

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:18080/");

                HttpResponseMessage response = client.PostAsJsonAsync<demande>("JAVAEE-web/rest/admin/adddemande", d).Result;
                if (response.IsSuccessStatusCode)
                {
                //    client.PostAsJsonAsync<demande>("JAVAEE-web/rest/admin/adddemande", d);
                    // .ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
               
                    return RedirectToAction("Demande");
                }
                else
                {
               
                ViewBag.result = "Demand already exist";
              //  System.Diagnostics.Debug.WriteLine(ViewBag.result);
            }


           // client.PostAsJsonAsync<demande>("JAVAEE-web/rest/admin/adddemande", d);
                // .ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());

                

            //    return RedirectToAction("Demande");

          //  }
            //catch
            //{
                return View();
         //   }

        }

        public ActionResult Delete(String email)
        {
            System.Diagnostics.Debug.WriteLine("******* email ********");
            System.Diagnostics.Debug.WriteLine(email);
            return View();
        }

        [HttpPost]
        public ActionResult Delete(String email, FormCollection collection)
        {

            System.Diagnostics.Debug.WriteLine("******* email ********");
            System.Diagnostics.Debug.WriteLine(email);

            demande d = new demande();

            d.email = email;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080/");

            HttpResponseMessage response = client.PostAsJsonAsync<demande>("JAVAEE-web/rest/admin/deletedemande", d).Result;
            if (response.IsSuccessStatusCode)
            {
              //  client.PostAsJsonAsync<demande>("JAVAEE-web/rest/admin/deletedemande", d);
                // .ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());

                return RedirectToAction("allDemands");
            }
            else
            {

                ViewBag.result = "Demand does not exist";
            }
                return View();


        }



        /*
         // GET: Demande/Details/5
         public ActionResult Details(int id)
         {
             return View();
         }

         // GET: Demande/Create
         public ActionResult Create()
         {
             return View();
         }

         // POST: Demande/Create
         [HttpPost]
         public ActionResult Create(FormCollection collection)
         {
             try
             {
                 // TODO: Add insert logic here

                 return RedirectToAction("Index");
             }
             catch
             {
                 return View();
             }
         }

         // GET: Demande/Edit/5
         public ActionResult Edit(int id)
         {
             return View();
         }

         // POST: Demande/Edit/5
         [HttpPost]
         public ActionResult Edit(int id, FormCollection collection)
         {
             try
             {
                 // TODO: Add update logic here

                 return RedirectToAction("Index");
             }
             catch
             {
                 return View();
             }
         }

         // GET: Demande/Delete/5
         public ActionResult Delete(int id)
         {
             return View();
         }

         // POST: Demande/Delete/5
         [HttpPost]
         public ActionResult Delete(int id, FormCollection collection)
         {
             try
             {
                 // TODO: Add delete logic here

                 return RedirectToAction("Index");
             }
             catch
             {
                 return View();
             }
         }
        */
    }
}
