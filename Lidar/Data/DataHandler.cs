using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lidar.Data
{
    public class DataHandler
    {
        RawData rawData = new RawData();
        private double deviationMultiplier=0.9;
        private double angleMultiplier=0.9;

        public void GetData(byte[] bytes)
        {
            var dataAmount= bytes.Length/7;
            for(int i=0;i<dataAmount;i++)
            {
                sbyte deviation =unchecked((sbyte)((sbyte) bytes[7 * i]));
                ushort angle =(ushort)((ushort) (bytes[7 * i + 1] << 8) |(bytes[7 * i + 2]));
                int distance = bytes[7 * i + 3] << 24 | bytes[7 * i + 4]<<8
                    | (bytes[7 * i + 5] << 8) | (bytes[7 * i + 6]);
                rawData.AddData(distance, angle, deviation);
            }
        }
        public List<XYZCoordsData> GetDataXYZCoords()
        {
            return DataHelper.GetXYZCoordsData(rawData, angleMultiplier, deviationMultiplier);
        }
    }
}
