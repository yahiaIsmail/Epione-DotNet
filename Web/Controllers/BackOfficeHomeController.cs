using Service.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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


            return View();
        }

    }
}