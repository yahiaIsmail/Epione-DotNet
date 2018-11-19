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
        //Context db = new Context();
        static IDatabaseFactory dbf = new DatabaseFactory();

        static IUnitOfWork uow = new UnitOfWork(dbf);

        ServicePatientStat statRessource = new ServicePatientStat();
        Context db = new Context();

        // GET: Stat
        public ActionResult Index()
        {
            
            // double unixTimeStamp = 1540990800;
            // System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            // dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            // System.Diagnostics.Debug.WriteLine(dtDateTime);

            //  DateTime d = new DateTime();
            //    System.Diagnostics.Debug.WriteLine(d);
            var queryConfirmed = (from m in db.rdv
                         where (m.status == 0)
                         select m);
            var queryCancled = (from m in db.rdv
                         where (m.status == 2)
                         select m);
            //  var query1 = statRessource.GetAll();

            ViewBag.confirmed = queryConfirmed.Count();
            ViewBag.cancled= queryCancled.Count();
           // System.Diagnostics.Debug.WriteL2ne(ViewBag.REP);
            return View();
        }
        public ActionResult pdfConverter()
        {
            // Create a new PDF document
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Created with PDFsharp";

            // Create an empty page
            PdfPage page = document.AddPage();

            // Get an XGraphics object for drawing
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Create a font
            XFont font = new XFont("Verdana", 20, XFontStyle.BoldItalic);
            XFont medecin = new XFont("Verdana", 10, XFontStyle.BoldItalic);

            


            int y = 90;
            int x = 50;
            //select name and last name of the doctor from his email
            var queryNomMedecin = (from u in db.user
                                   where (u.email.Equals("moez.haddad@esprit.tn"))
                                   select new
                                   {
                                       firstName = u.firstName,
                                       lastName = u.lastName
                                   }).First();
            //Write the name and last name in PDF
            gfx.DrawString("Doctor : " + queryNomMedecin.firstName + " " + queryNomMedecin.lastName,
            font, XBrushes.Black, x, y);

            //Write today's date
            y += 30;
            DateTime today = DateTime.Today;
            gfx.DrawString("date : " + today.ToString("dd/MM/yyyy"),
            font, XBrushes.Black, x, y);

            
            // get patient of today
            var queryPatient = (from m in db.rdv
                                join u in db.user on m.doctors_id equals u.id
                                join p in db.user on m.users_id equals p.id
                                where (u.email.Equals("moez.haddad@esprit.tn"))
                                where (m.dateRDV.CompareTo(today)==0)
                                        select new
                                        {
                                            firstName = p.firstName,
                                            lastName = p.lastName,
                                            phoneNumber = p.phoneNumber
                                        }).ToList();
                    y += 30;
                    //Write the patient of today 
                    gfx.DrawString("Today's patient rdv : ",
                    font, XBrushes.Black, x, y);
                    XFont fontList = new XFont("Verdana", 7, XFontStyle.BoldItalic);

                    foreach (object e in queryPatient)
                    {
                        System.Diagnostics.Debug.WriteLine(e);
                        y += 20;

                        gfx.DrawString("" + e,
                        fontList, XBrushes.Black, x + 40, y);
                    }


                    // get medical path of today
                    var queryPath = (from m in db.rdv
                                     join u in db.user on m.doctors_id equals u.id
                                     join mp in db.medicalpaths on m.id equals mp.rendezVous_id
                                     where (u.email.Equals("moez.haddad@esprit.tn") )
                                     where (m.dateRDV.CompareTo(today) == 0)
                                     select mp.justification).ToList();
                    //    select );

                    y += 30;
                    //Write the medical paths of today 
                    gfx.DrawString("Today's medical paths : ",
                    font, XBrushes.Black, x, y);

                    foreach (object e in queryPath)
                    {
                        System.Diagnostics.Debug.WriteLine(e);
                        y += 20;

                        gfx.DrawString("" + e,
                        fontList, XBrushes.Black, x + 40, y);
                    }
                    // System.Diagnostics.Debug.WriteLine(query.patientFirstName);
                    
            




            // Save the document...
            const string filename = "HelloWorld.pdf";
            document.Save(@"\\Mac\Home\Desktop\helloPDF.pdf");


            // ...and start a viewer.
           // Process.Start(filename);

            return RedirectToAction("Index");
            // return View();
        }



    }
}