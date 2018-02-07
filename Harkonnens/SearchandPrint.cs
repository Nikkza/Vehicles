using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Levis
{
    class SearchandPrint
    {
        public static IEnumerable<IVehicle> SearchHandler(List<IVehicle> template, string UserIP)
        {
            var CollectedSearchResults = from p in template
                                         where p.GetName().ToUpper().Contains(UserIP.ToUpper()) 
                                         select p;

            return CollectedSearchResults;
        }
    }
}
