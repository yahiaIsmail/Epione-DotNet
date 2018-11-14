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
    class ServicePatientStat: Service<user>, IServicePatientStat
    {
        static IDatabaseFactory dbf = new DatabaseFactory();

        static IUnitOfWork uow = new UnitOfWork(dbf);

        public ServicePatientStat() : base(uow)
        {

        }
    }
}
