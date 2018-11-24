using Data.Infrastructure;
using Data.Models;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Stats
{
    public class ServicePDF : Service<user>, IServicePDF
    {
        static IDatabaseFactory dbf = new DatabaseFactory();

        static IUnitOfWork uow = new UnitOfWork(dbf);
        public ServicePDF() : base(uow)
        {
        }
        public void convertPDF(string email)
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
            var queryNomMedecin = (from u in dbf.DataContext.user
                                   where (u.email.Equals(email))
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
            var queryPatient = (from m in dbf.DataContext.rdv
                                join u in dbf.DataContext.user on m.doctors_id equals u.id
                                join p in dbf.DataContext.user on m.users_id equals p.id
                                where (u.email.Equals(email))
                                where (m.dateRDV.CompareTo(today) == 0)
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
            var queryPath = (from m in dbf.DataContext.rdv
                             join u in dbf.DataContext.user on m.doctors_id equals u.id
                             join mp in dbf.DataContext.medicalpath on m.id equals mp.rendezVous_id
                             where (u.email.Equals(email))
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
           // const string filename = "TodaySchedule.pdf";
            document.Save(@"\\Mac\Home\Desktop\TodaySchedule.pdf");


            // ...and start a viewer.
            // Process.Start(filename);
        }
    }
}
