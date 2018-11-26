using Data.Infrastructure;
using Data.Models;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Stats
{
    public class ServiceStat: Service<rdv>, IServiceStat
    {
        static IDatabaseFactory dbf = new DatabaseFactory();

        static IUnitOfWork uow = new UnitOfWork(dbf);

        public ServiceStat() : base(uow)
        {

        }
        public List<int> getStat()
        {
            //get confirmed and cancled rdv
            List<int> stat = new List<int>();
            var queryConfirmed = (from m in dbf.DataContext.rdv
                                  where (m.status == 0)
                                  select m);
            var queryCancled = (from m in dbf.DataContext.rdv
                                where (m.status == 2)
                                select m);
            stat.Add(queryConfirmed.Count());
            stat.Add(queryCancled.Count());
            return stat;
        }

        //get doctors number
        public int getdoctornumber()
        {
            int docnumber = 0;
        
            var querydoctornum = (from m in dbf.DataContext.user
                                  where (m.role.Equals("2"))
                                  select m);
            docnumber = querydoctornum.Count();

            return docnumber;
        }

        //get patient number
        public int getpatientnumber()
        {
            int patientnumber = 0;
            var querypatientnum = (from m in dbf.DataContext.user
                                   where (m.role.Equals("1"))
                                   select m);
            patientnumber = querypatientnum.Count();
            return patientnumber;
        }

        //get rdv number
        public int getrdvnumber()
        {
            int rdvnumber = 0;
            var queryrdvnum = (from m in dbf.DataContext.rdv
                               select m);
            rdvnumber = queryrdvnum.Count();
            return rdvnumber;
        }

        //get medicalpath number
        public int getmedicalpathnumber()
        {
            int medicalpathnum = 0;
            var querymedicalpathnum = (from m in dbf.DataContext.medicalpath
                                       select m);
            medicalpathnum = querymedicalpathnum.Count();
            return medicalpathnum;
        }

        public List<object> getrankdoc()
        {
            List<object> listuser = new List<object>();

            //var query = (from m in dbf.DataContext.medicalvisit
            //             select m).ToList();

            //foreach(medicalvisit e in query)
            //{
            //    System.Diagnostics.Debug.WriteLine("*************");

            //    System.Diagnostics.Debug.WriteLine(e);
            //}

            var queryrank = (from m in dbf.DataContext.medicalvisit
                             join p in dbf.DataContext.pathdoctors on m.pathDoctors_id equals p.id
                             join u in dbf.DataContext.user on p.doctor_id equals u.id
                             orderby m.rating descending
                                       select new {
                                            firstname = u.firstName,
                                            lastname = u.lastName,
                                            speciality = u.speciality,
                                            rating = m.rating,
                                            url = u.UrlPhoto

                                       } )
                                       //.GroupBy( u => u.rating)
                                       .Take(3)
                                       .ToList();
            foreach(var element in queryrank)
            {
                listuser.Add(element);
            }
          //  listuser.Sort();
            return listuser;
        }
    }
}
