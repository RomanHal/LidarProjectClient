using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lidar.Data
{
    class RawData
    {
        public List<Measurement> Measurements => measurements;
        List<Measurement> measurements = new List<Measurement>();
        public RawData() { }
        public void AddData(int distance, ushort angle, sbyte deviation)
        {
            measurements.Add(new Measurement(distance, angle, deviation));
        }
        
    }
}
