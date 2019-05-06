using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lidar.Data
{
    class Measurement
    {

        public Measurement(int distance, ushort angle, sbyte deviation)
        {
            Distance = distance;
            Deviation = deviation;
            Angle = angle;
        }

        public int Distance { get; set; }
        public ushort Angle { get; set; }
        public sbyte Deviation { get; set; }
    }
}
