using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lidar.Data
{
    public class XYZCoordsData
    {
        public XYZCoordsData(double x,double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public double X { get; }
        public double Y { get; }
        public double Z { get; }
        public override string ToString()
        {
            return X + ";"+ Y+ ";"+ Z + ";";
        }
    }
}
