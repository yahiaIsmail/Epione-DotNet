﻿using Data.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using Web.Models;

namespace Web.Controllers
{
    public class RdvController : Controller
    {
        public ActionResult notFound()
        {
            return View("~/Views/notFound.cshtml");
        }
        // GET: Rdv
        public ActionResult Index()
        {
            return View();
        }

        // GET: Rdv/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Rdv/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Rdv/doctor/{id}
        public ActionResult Doctor(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("notFound", "Rdv");
            // data mta3 docteur
            //HttpClient clientDoc = new HttpClient();
            //clientDoc.BaseAddress = new Uri("http://localhost:18080/");
            //HttpResponseMessage responseDoc;
            //responseDoc = clientDoc.GetAsync("JAVAEE-web/rest/users/doctors/get/"+ id).Result;
            //var docResponse = responseDoc.Content.ReadAsStringAsync();
            //string DataString = docResponse.Result;
            //XDocument xmlDoc = new XDocument();
            //xmlDoc = XDocument.Parse(DataString);

            // end data mta3 docteur
            HttpClient clientMotif = new HttpClient();
            clientMotif.BaseAddress = new Uri("http://localhost:18080/");
            clientMotif.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage responseMotif = clientMotif.GetAsync("JAVAEE-web/rest/rdv/motifDoctor/" + id).Result;

            if (responseMotif.IsSuccessStatusCode)
            {
                ViewBag.motifs = responseMotif.Content.ReadAsAsync<IEnumerable<DemandViewModel>>().Result;
            }
            else
            {
                ViewBag.motifs = "error";
            }
            return View();
            //bech najouti function fi moif jee traja3 motifs by id docteur
            //w nafichiehom fi drop down list w el chosit na5edh el id mta3ha
            //w nbadel fazt dateRDv w na9ssmh y/mm/d  h:m:s
            //w nzid njib mail de docteur
        }

        // POST: Rdv/Create
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

        // GET: Rdv/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Rdv/Edit/5
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

        // GET: Rdv/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Rdv/Delete/5
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
