using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Data.Models;
using Newtonsoft.Json.Linq;
using WebGrease.Css.Extensions;

namespace Web.Controllers
{
    public class MedicalPathController : Controller
    {
        // GET: MedicalPath
        public ActionResult Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("/JAVAEE-web/rest/medicalPath/getPathById/6").Result;
            

            ViewBag.result = response.Content.ReadAsAsync<IEnumerable<medicalpath>>().Result;
          
              
            return View();
           
        }

        // GET: MedicalPath/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MedicalPath/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedicalPath/Create
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

        // GET: MedicalPath/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MedicalPath/Edit/5
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

        // GET: MedicalPath/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MedicalPath/Delete/5
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
    }
}
