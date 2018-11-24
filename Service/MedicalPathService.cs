using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Data.Models;
using Service.Pattern;

namespace Service
{
   public class MedicalPathService:Service<medicalpath>,IMedicalService
    {   
        private static IDatabaseFactory dbfactor = new DatabaseFactory();
        private static IUnitOfWork wow = new UnitOfWork(dbfactor);
        IDatabaseFactory dbfactory = null;
        public MedicalPathService():base(wow)
        {
            
        }

    }
}
