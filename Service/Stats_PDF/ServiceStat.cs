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
    }
}
