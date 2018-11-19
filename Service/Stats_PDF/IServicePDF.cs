using Data.Models;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Stats
{
    public interface IServicePDF : IService<user>
    {
        void convertPDF(string email);
         
    }
}
