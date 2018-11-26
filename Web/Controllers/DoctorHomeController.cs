using Newtonsoft.Json;
using Service.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class DoctorHomeController : Controller
    {
        ServiceStat statService = new ServiceStat();
        ServicePDF pdfService = new ServicePDF();

        // GET: DoctorHome
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
            List<rankdoc> rankdoclist = JsonConvert.DeserializeObject<List<rankdoc>>(output);
            ViewBag.rankDoc = rankdoclist;


            

            return View();
        }
        public ActionResult pdfConverter()
        {
            string email = "moez.haddad@esprit.tn";
            pdfService.convertPDF(email);
            return RedirectToAction("Index");
            // return View();
        }
    }
}