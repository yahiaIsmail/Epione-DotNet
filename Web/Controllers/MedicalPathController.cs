using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Data.Models;
using Newtonsoft.Json.Linq;
using Service;
using Web.Models;
using WebGrease.Css.Extensions;

namespace Web.Controllers
{
    public class MedicalPathController : Controller
    {
        MedicalPathService medipath=new MedicalPathService();
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
        
        // GET: MedicalPath/Details/5
        public ActionResult Details(int id)
        {
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
        public ActionResult  addNewPath(string justifi,int idrdv)
        {       MedicalPathViewModel path=new MedicalPathViewModel();
                path.justification = justifi;
                     path.active=true;
                     path.status=false;
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
            HttpResponseMessage response = client.GetAsync("/JAVAEE-web/rest/medicalPath/getPathById/"+id).Result;
             ViewBag.result = response.Content.ReadAsAsync<IEnumerable<MedicalPathViewModel>>().Result;
           
            return View();
        }
        public ActionResult DisplayListOfDoctorsInMap(int id)
        {
           /* medicalpath p = medipath.Get(a => a.id == id);
            MedicalPathViewModel pa=new MedicalPathViewModel();
            RdvForMedicalViewModel r=new RdvForMedicalViewModel();
            DoctorPathViewModel docpath=new DoctorPathViewModel();
            List<DoctorPathViewModel> doc=new List<DoctorPathViewModel>();
            //doc.id = (int) p.pathdoctors.ElementAt(0).id;
            //pa.doctorPath.ElementAt(0).id = doc.id;
            r.id =(int) p.rendezVous_id;
           
            pa.rendezVous = r;
            foreach (var pathdoctor in p.pathdoctors)
            {
                doc.Add(pathdoctor);
            }
                
    */
           
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
