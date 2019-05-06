using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lidar.Data
{
    class DataHelper
    {
        public static List<SphericalData> GetSphericalData(RawData data,double angleMultiplier,
            double deviationMultiplier)
        {
            return data.Measurements.Select(d =>
            {
                double newAngle = d.Angle * angleMultiplier;
                double newDeviation = d.Deviation * deviationMultiplier+90;
                double newDistnce = d.Distance;
                return new SphericalData(newAngle, newDeviation, newDistnce);
            }).ToList();
        }
        public static List<XYZCoordsData> GetXYZCoordsData(List<SphericalData> data)
        {
            return data.Select(d =>
            {
                double x = d.R * Math.Sin(DegreeToRadians(d.Omega)) * Math.Cos(DegreeToRadians(d.Fi));
                double y = d.R * Math.Sin(DegreeToRadians(d.Omega)) * Math.Sin(DegreeToRadians(d.Fi));
                double z = d.R * Math.Cos(DegreeToRadians(d.Omega));
                return new XYZCoordsData(x, y, z);
            }).ToList();
        }
        public static List<XYZCoordsData> GetXYZCoordsData(RawData data, double angleMultiplier,
            double deviationMultiplier)
        {
            return GetXYZCoordsData(GetSphericalData(data,angleMultiplier,deviationMultiplier));
        }
        static double DegreeToRadians(double degree)
        {
            return degree * Math.PI / 180.0;
        }

    }
}
