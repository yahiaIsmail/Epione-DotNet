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
    }
}
