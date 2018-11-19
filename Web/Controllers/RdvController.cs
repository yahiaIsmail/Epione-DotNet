using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace Web.Controllers
{
    public class RdvController : Controller
    {
        public ActionResult notFound()
        {
            return View("~/Views/notFound.cshtml");
        }
        // GET: Rdv
        public ActionResult Index()
        {
            return View();
        }

        // GET: Rdv/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Rdv/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Rdv/doctor/{id}
        public ActionResult Doctor(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("notFound","Rdv");
            //requesting the particular web page
            string url = "http://localhost:18080/JAVAEE-web/rest/users/doctors/get/" + id;
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);

            //geting the response from the request url
            var response = (HttpWebResponse)httpRequest.GetResponse();

            //create a stream to hold the contents of the response (in this case it is the contents of the XML file
            var receiveStream = response.GetResponseStream();

            //creating XML document
            var mySourceDoc = new XmlDocument();

            //load the file from the stream
            mySourceDoc.Load(receiveStream);

            //close the stream
            receiveStream.Close();
            Debug.WriteLine(mySourceDoc);
            return View();
            //bech najouti function fi moif jee traja3 motifs by id docteur
            //w nafichiehom fi drop down list w el chosit na5edh el id mta3ha
            //w nbadel fazt dateRDv w na9ssmh y/mm/d  h:m:s
            //w nzid njib mail de docteur
        }

        // POST: Rdv/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Rdv/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Rdv/Edit/5
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

        // GET: Rdv/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Rdv/Delete/5
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
