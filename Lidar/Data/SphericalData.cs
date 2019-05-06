using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lidar.Data
{
    class SphericalData
    {
        public SphericalData( double fi, double omega, double r)
        {
            this.Fi = fi;
            this.Omega = omega;
            this.R = r;
        }

        public double Fi { get; }
        public double Omega { get; }
        public double R { get; }
    }
}
