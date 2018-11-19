using Data.Models;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Stats
{
    public interface IServiceStat :  IService<rdv>
    {
        List<int> getStat();
    }

}
