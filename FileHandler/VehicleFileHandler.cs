using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileHandler
{
    public class VehicleFileHandler
    {
        

        public void WriteToFile(List<string> vStringList, string dirPath)
        {
            using (var write = new StreamWriter(dirPath + "\\savedData.txt"))
            {
                foreach (var vString in vStringList)
                {
                    write.WriteLine(vString);
                }
            }
        }

        public List<string> GetFromFile(string dirPath)
        {
            List<string> vStringList = new List<string>();

            using (var read = new StreamReader(dirPath + "\\savedData.txt"))
            {
                while (!read.EndOfStream)
                {
                   vStringList.Add(read.ReadLine());
                }
            }

            return vStringList;
        }
    }
}
