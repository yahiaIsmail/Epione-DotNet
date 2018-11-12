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

            try
            {
                // TODO: Add insert logic here
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:18080/");
                // client.PostAsJsonAsync<DemandeViewModel>("Epione-web/rest/doctolib/ajoutDemande", demande).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
                client.PostAsJsonAsync<demande>("JAVAEE-web/rest/admin/adddemande", d)
               .ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());


                return RedirectToAction("Demande");
            }
            catch
            {
                return View();
            }            
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
