using Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class PatientController : Controller
    {
        // GET: Patient
        public ActionResult Index()
        {
            return View();
        }

        // GET: Patient
        public ActionResult ConfirmRegister(string email)
        {
            ViewBag.email = email;
            return View();
        }


        // GET: Patient/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Patient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patient/Create
        [HttpPost]
        public ActionResult Create(PatientViewModel patient)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return PartialView(patient);
                }


                PatientViewModel usr = new PatientViewModel()
                {
                    email = patient.email,
                    username = patient.username,
                    password = patient.password,
                    firstName = patient.firstName,
                    lastName = patient.lastName
                };

                PatientModel patientModel = new PatientModel()
                {
                    email = patient.email,
                    username = patient.username,
                    password = patient.password,
                    firstName = patient.firstName,
                    lastName = patient.lastName
                };

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:18080/");
                HttpResponseMessage response;

                response = client.PostAsJsonAsync<PatientModel>("JAVAEE-web/rest/users/addPatient", patientModel).Result;
                Debug.Print(patient.ToString());
                Debug.Print(usr.ToString());
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("ConfirmRegister", new { email = patient.email });
                }
                else
                {
                    ViewBag.result = "An error occured please try again";
                    return View(patient);
                }
            }
            catch
            {
                return View(patient);
            }
        }

        // GET: Patient/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Patient/Edit/5
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

        // GET: Patient/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Patient/Delete/5
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
