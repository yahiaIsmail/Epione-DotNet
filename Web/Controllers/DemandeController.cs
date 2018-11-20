using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Web.Models;

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
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<DemandViewModel>>().Result;
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

            DemandViewModel d = new DemandViewModel();

            d.email = collection["email"];
            d.firstName = collection["firstName"];
            d.lastName = collection["lastName"];
            d.speciality = collection["speciality"];
            d.state = collection["state"];

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:18080/");

                HttpResponseMessage response = client.PostAsJsonAsync<DemandViewModel>("JAVAEE-web/rest/admin/adddemande", d).Result;
                if (response.IsSuccessStatusCode)
                {
             
               
                    
                    ViewBag.succ = "Demand succesfully created";
            }
                else
                {
               
                ViewBag.fail = "Demand already exist";
            }


           
            return View();
        

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

            DemandViewModel d = new DemandViewModel();

            d.email = email;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080/");

            HttpResponseMessage response = client.PostAsJsonAsync<DemandViewModel>("JAVAEE-web/rest/admin/deletedemande", d).Result;
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
