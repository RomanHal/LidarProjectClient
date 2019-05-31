using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lidar.Services
{
    class DataSaver
    {
        public void SaveAsCsv(string patch,string[] lines)
        {
            File.WriteAllLines(patch, lines);
        }
    }
}
