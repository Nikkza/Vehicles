using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    public class VehicleParser
    {
        public List<string> ParseVehicleString(List<string> unparsedList) 
        {
            List<string> parsedList = new List<string>();

            foreach (var item in unparsedList)
            {
                var parsedString = item.Split(';').ToList();
                parsedList.AddRange(parsedString);
            }

            return parsedList;
        }
    }
}
