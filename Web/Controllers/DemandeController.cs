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
        [HttpPost]
        public ActionResult Demande(user u)
        {
            HttpClient user = new HttpClient();
            user.BaseAddress = new Uri("http://localhost:2663");
            user.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = user.GetAsync("api/user").Result;
            if(response.IsSuccessStatusCode)
            {
               
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
