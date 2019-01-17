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
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;

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


                if (Request.Files == null)
                {
                    ViewBag.imageUpload = "Error, Please select another image where your face is seen clearly";
                    return View(patient);
                }

                Account account = new Account(
              "pidev",
              "187685892358282",
              "rL27N346tuXqVQyA5sR1oDLFJag");

                Cloudinary cloudinary = new Cloudinary(account);
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(Request.Files[0].FileName, Request.Files[0].InputStream)
                };
                var uploadResult = cloudinary.Upload(uploadParams);

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://127.0.0.1:5000/");
                HttpResponseMessage response;
                response = client.GetAsync("api/v1/face/url?img=" + uploadResult.SecureUri).Result;
                var imageResponse = response.Content.ReadAsStringAsync();
                var imageData = JObject.Parse(imageResponse.Result);
                
                if (!imageData["num_faces"].ToString().Equals("0"))
                {
                    HttpClient clientAdd = new HttpClient();
                    clientAdd.BaseAddress = new Uri("http://127.0.0.1:18080/");
                    HttpResponseMessage responseAdd;

                    PatientModel patientModel = new PatientModel()
                    {
                        email = patient.email,
                        username = patient.username,
                        password = patient.password,
                        firstName = patient.firstName,
                        lastName = patient.lastName,
                        urlPhoto = uploadResult.SecureUri.ToString()
                    };

                    responseAdd = clientAdd.PostAsJsonAsync<PatientModel>("JAVAEE-web/rest/users/addPatient", patientModel).Result;

                    if (responseAdd.IsSuccessStatusCode)
                    {
                        return RedirectToAction("ConfirmRegister", new { email = patient.email });
                    }
                    else
                    {
                        ViewBag.result = "An error occured please try again";
                        return View(patient);
                    }
                }
                ViewBag.imageUpload = "Please verify ,the image contains you face";
                return View(patient);
            }
            catch
            {
                return View(patient);
            }
        }

        public ActionResult showRdv(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://127.0.0.1:18080/");
            HttpResponseMessage response;
            response = client.GetAsync("JAVAEE-web/rest/rdv/patient?patientId=" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                 IEnumerable <RdvGetModel> rdvs = response.Content.ReadAsAsync<IEnumerable<RdvGetModel>>().Result;
                foreach(RdvGetModel rd in rdvs)
                {
                    rd.drv = new DateTime();
                    //DateTimeOffset dateTimeOffset = DateTimeOffset.(rd.DateRdv);

                    var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                    rd.drv = epoch.AddMilliseconds(rd.DateRdv);
                }

                ViewBag.rdvs = rdvs;
            }
            else
            {
                ViewBag.rdvs = null;
            }
            return View();
        }

        public ActionResult confirmRdvPatient(int idPatient, int idRdv)
        {
            string token = "eyJhbGciOiJIUzUxMiJ9.eyJzdWIiOiJweXRob24iLCJpc3MiOiJLYWlzIiwiaWF0IjoxNTQyNjcwOTk1LCJleHAiOjIxNzM4MjI5OTV9.eTIdO8NKW1cvRcqDuuofvV5fddeFbwG4BJz7AkBXyxbPgGZBJU5VQvGCKQa0_q57fvyNa8KBIMG1JKhvo4XMEQ";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://127.0.0.1:18080/");
            HttpResponseMessage response;
            response = client.GetAsync("JAVAEE-web/rest/rdv/user/confirmRDV?Token=" + token + "&rdvId="+idRdv).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("showRdv", new { id = idPatient });
            }
            else
            {
                return RedirectToAction("showRdv", new { id = idPatient });
            }
           
        }

        public ActionResult cancelRdv(int idPatient, int idRdv)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://127.0.0.1:18080/");
            HttpResponseMessage response;
            response = client.GetAsync("JAVAEE-web/rest/rdv/cancel?rdvId=" + idRdv).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("showRdv", new { id = idPatient });
            }
            else
            {
                return RedirectToAction("showRdv", new { id = idPatient });
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
