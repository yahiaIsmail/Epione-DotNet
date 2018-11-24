using Data;
using Data.Infrastructure;
using Data.Models;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using Service.Stats;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class StatController : Controller
    {
        
        ServiceStat statService = new ServiceStat();
        ServicePDF pdfService = new ServicePDF();

        // GET: Stat
        public ActionResult Index()
        {
            List<int> statList = new List<int>();
            statList = statService.getStat();
            ViewBag.confirmed = statList[0];
            ViewBag.cancled= statList[1];
           // System.Diagnostics.Debug.WriteLine(ViewBag.REP);
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