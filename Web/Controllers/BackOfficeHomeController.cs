using Data.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Service.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Web.Models;

namespace Web.Controllers
{
    public class BackOfficeHomeController : Controller
    {
        ServiceStat statService = new ServiceStat();
        ServicePDF pdfService = new ServicePDF();

        // GET: BackOfficeHome
        public ActionResult Index()
        {
            //get doctors number 
            ViewBag.doctornumber = statService.getdoctornumber();
            

            //get patient number
            ViewBag.patientnumber = statService.getpatientnumber();

            //get rdv number
            ViewBag.rdvnumber = statService.getrdvnumber();

            //get medicalpath number
            ViewBag.medicalpathnumber = statService.getmedicalpathnumber();

            //the confirmed and cancled rdv
            List<int> confirmedCancledRDV = new List<int>();
            confirmedCancledRDV = statService.getStat();
            ViewBag.confirmed = confirmedCancledRDV[0];
            ViewBag.cancled = confirmedCancledRDV[1];

            //get top rank doctors 
            List<object> listuser = statService.getrankdoc();
            string output = JsonConvert.SerializeObject(listuser);
            List<rankdoc> rankdoclist= JsonConvert.DeserializeObject<List<rankdoc>>(output);
            ViewBag.rankDoc = rankdoclist;

            //foreach(rankdoc e in rankdoclist)
            //{
            //    System.Diagnostics.Debug.WriteLine(e.firstName);
            //    System.Diagnostics.Debug.WriteLine(e.lastName);
            //    System.Diagnostics.Debug.WriteLine(e.speciality);
            //    System.Diagnostics.Debug.WriteLine(e.rating);
            //}




            //get all demands 
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("JAVAEE-web/rest/admin/demandes").Result;

            if (response.IsSuccessStatusCode)
            {
                ViewBag.demands = response.Content.ReadAsAsync<IEnumerable<DemandViewModel>>().Result;
            }
            else
            {
                ViewBag.demands = "error";
            }

            return View();
        }
        public ActionResult Delete(String email)
        {
            System.Diagnostics.Debug.WriteLine("******* email ********");
            System.Diagnostics.Debug.WriteLine(email);

            DemandViewModel d = new DemandViewModel();
            d.email = email;


            string str;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080/");
            HttpResponseMessage response = client.PostAsJsonAsync<DemandViewModel>("JAVAEE-web/rest/admin/getonedemand", d).Result;
            if (response.IsSuccessStatusCode)
            {
                str = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<DemandViewModel>(str);
                ViewBag.email = result.email;
                ViewBag.firstName = result.firstName;
                ViewBag.lastName = result.lastName;
                ViewBag.speciality = result.speciality;
                ViewBag.state = result.state;

            }
            else
            {
                ViewBag.result = "Not found !";
            }

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
                return RedirectToAction("index");
            }
            else
            {

                ViewBag.result = "Demand does not exist";
            }
            return View();


        }
        public ActionResult Logout()
        {
            Session.Clear();
            return Redirect("../Home/Index");
        }


    }
}