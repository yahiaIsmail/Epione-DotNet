using Data;
using Data.Infrastructure;
using Service.Stats;
using System;
using System.Collections.Generic;
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
            
            var query = (from m in db.user

                         select m);
          //  var query1 = statRessource.GetAll();

           // ViewBag.REP = query.Count();
            System.Diagnostics.Debug.WriteLine("************");
            System.Diagnostics.Debug.WriteLine(query.Count());
            return View();
        }
       
    }
}