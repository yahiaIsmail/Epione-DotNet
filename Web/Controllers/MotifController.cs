using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class MotifController : Controller
    {
        // GET: Motif
        public ActionResult Index()
        {
            return View();
        }

        // GET: Motif/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Motif/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Motif/Create
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

        // GET: Motif/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Motif/Edit/5
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

        // GET: Motif/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Motif/Delete/5
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
