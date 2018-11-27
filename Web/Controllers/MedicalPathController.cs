﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using Data.Infrastructure;
using Data.Models;

using Newtonsoft.Json.Linq;
using Service;
using Web.Models;
using WebGrease.Css.Extensions;

namespace Web.Controllers
{
    public class MedicalPathController : Controller
    {

        public MedicalPathController()
        {

            //RecurringJob.AddOrUpdate(() => System.Diagnostics.Debug.WriteLine("1", "AUTHORCLASS id"), Cron.Daily);
        }

        MedicalPathService medipath = new MedicalPathService();
        
        // GET: MedicalPath
        public ActionResult Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("/JAVAEE-web/rest/medicalPath/AllPathsForoneDoc/1").Result;
            var b = response.Content.ReadAsAsync<IEnumerable<MedicalPathViewModel>>().Result;
            foreach (var i in b)
            {
                foreach (var j in i.doctorPath)
                {
                    j.medicalVisit.des = j.medicalVisit.description;
                }
            }

            ViewBag.result = b;



            return View();

        }

        // GET: MedicalPath/Create
        public ActionResult Create()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("/JAVAEE-web/rest/medicalPath/RdvsDoc/2").Result;
            ViewBag.result = response.Content.ReadAsAsync<IEnumerable<RdvForMedicalViewModel>>().Result;
            return View();
        }

        // POST: MedicalPath/Create
        [HttpPost]
        public ActionResult addNewPath(string justifi, int idrdv)
        {
            MedicalPathViewModel path = new MedicalPathViewModel();
            path.justification = justifi;
            path.active = true;
            path.status = false;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            var x = client
                .PostAsJsonAsync<MedicalPathViewModel>("/JAVAEE-web/rest/medicalPath/CreatePath/" + idrdv, path)
                .Result;
            return Json(new { success = true, message = Convert.ToInt32(x.Content.ReadAsStringAsync().Result) }, JsonRequestBehavior.AllowGet);

        }

        // GET: list of doctors and visit
        public ActionResult addDoctorsTo(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("/JAVAEE-web/rest/medicalPath/getPathById/" + id).Result;
            ViewBag.result = response.Content.ReadAsAsync<IEnumerable<MedicalPathViewModel>>().Result;

            return View();
        }


        public ActionResult DisplayListOfDoctorsInMap(int id)
        {
            ViewBag.idPath = id;

            List<DoctorViewModel> listofdoctors = new List<DoctorViewModel>();
            IDatabaseFactory dbf = new DatabaseFactory();
            //user
            string qr =
                " SELECT u.`id`,u.`UrlPhoto`,u.`email`,u.`firstName`,u.`lastName`,u.`phoneNumber`,u.`address_id`,u.state from user u,medicalpath m, " +
                "rdv r WHERE m.id =" + id + " and m.`rendezVous_id`= r.id and u.id = r.users_id";
            IEnumerable<PatientForMedicalPathViewModel> dataforpat = dbf.DataContext.Database.SqlQuery<PatientForMedicalPathViewModel>(qr);


            //address user
            string addresseForPatient = "select `id`,`fullAddress`,`latitude`,`longit`  "
                + "FROM address u "
                + "WHERE u.id=" + dataforpat.ElementAt(0).address_id;
            IEnumerable<AddressViewModel> dataforadd = dbf.DataContext.Database.SqlQuery<AddressViewModel>(addresseForPatient);


            //patient data

            PatientForMedicalPathViewModel patient = new PatientForMedicalPathViewModel();
            patient = dataforpat.ElementAt(0);
            patient.address = dataforadd.ElementAt(0);

            //doctors data
            string query = "SELECT id,UrlPhoto,email,firstName,lastName,paimentMethode,speciality,address_id,tariff,username  "
                           + "FROM user u "
                           + "WHERE u.role=2 AND u.id NOT IN (SELECT doctor_id from pathdoctors p WHERE p.path_id=" + id + ")";




            IEnumerable<DoctorViewModel> data = dbf.DataContext.Database.SqlQuery<DoctorViewModel>(query).ToList();
            foreach (var i in data)
            {
                string addressquery = "select `id`,`fullAddress`,`latitude`,`longit`  "
                               + "FROM address u "
                               + "WHERE u.id=" + i.address_id;
                IEnumerable<AddressViewModel> data2 = dbf.DataContext.Database.SqlQuery<AddressViewModel>(addressquery);
                foreach (var j in data2)
                {
                    if (j.id == i.address_id)
                    {
                        AddressViewModel ad = new AddressViewModel();

                        ad.id = j.id;
                        ad.fullAddress = j.fullAddress;
                        ad.longit = j.longit;
                        ad.latitude = j.latitude;
                        i.address = ad;


                    }
                }



            }
            listofdoctors.AddRange(data);




            ViewBag.result = listofdoctors;
            ViewBag.patient = patient;

            return View();
        }

        // GET: MedicalPath/Details/5
        public ActionResult addDoctorToPath(int idDoc, int idpath, string desc)
        {
            IDatabaseFactory dbf = new DatabaseFactory();
            //add new pathdoc
            string query = "INSERT INTO `pathdoctors` (`id`, `ordre`, `doctor_id`, `path_id`) VALUES (NULL, '3', '" +
                           idDoc + "', '" + idpath + "');";
            int gentId = dbf.DataContext.Database.ExecuteSqlCommand(query);


            //get the generated id
            string genId = "SELECT id FROM `pathdoctors` u WHERE u.`doctor_id`=" + idDoc + " AND u.`path_id`=" + idpath;
            IEnumerable<Int32> generatedId = dbf.DataContext.Database.SqlQuery<Int32>(genId);
            System.Diagnostics.Debug.WriteLine(generatedId.ElementAt(0), "AUTHORCLASS id");


            // add new medical visit
            DateTime dateTime = DateTime.Now;
            var sqlFormattedDate = dateTime.Date.ToString("yyyy-MM-dd HH:mm:ss");
            string qr =
                "INSERT INTO `medicalvisit` (`id`, `createdAt`, `description`, `medicalState`, `rating`, `pathDoctors_id`) " +
                "VALUES (NULL, '" + sqlFormattedDate + "', '" + desc + "', b'0', '0', '" + generatedId.ElementAt(0) + "');";
            dbf.DataContext.Database.ExecuteSqlCommand(qr);


            return Json(new { success = true }, JsonRequestBehavior.AllowGet);

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
