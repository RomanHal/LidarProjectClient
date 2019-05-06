
using IOLibrary;
using Lidar.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Visualisation;

namespace Lidar
{
    public class ModelMainWindow : INotifyPropertyChanged
    {
        private const string _isOpen = "is Open";
        private const string _Started = "Started";
        ComPort comPort = new ComPort();
        DataHandler dataHandler = new DataHandler();

        int packetCounter;
        List<XYZCoordsData> coordsData = new List<XYZCoordsData>();
        public string MeasurementStatus
        {
            get => _measurementStatus; set
            {
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(MeasurementStatus)));
                _measurementStatus = value;
            }
        }
        public string ComStatus
        {
            get => _comStatus; set
            {
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(ComStatus)));
                _comStatus = value;
            }
        }

        private string _comStatus = "SAD";
        private string _measurementStatus = "aaa";
        private string _selectedPort;

        public string SelectedPort { get => _selectedPort; set {
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(SelectedPort)));

                _selectedPort = value; } }

        public event PropertyChangedEventHandler PropertyChanged;

        public ModelMainWindow()
        {
            comPort.ReceiveData = DataReceivedHandler;
        }



        public string[] AvalibleComs => GetComs();

        public string[] GetComs()
        {
            return comPort.AvaliblePorts();
        }

        public void TryMeasure()
        {
            var a = 'a';
            comPort.Send(new byte[] { Convert.ToByte(a) });
            MeasurementStatus = "Start";
        }

        public void TryOpenCom()
        {
            if (comPort.IsOpen) ComStatus = _isOpen;
            else
            {
                comPort.ConnectToPort(SelectedPort,57600);
                ComStatus = _isOpen;
            }
        }
        void DataReceivedHandler(byte[] data)
        {
            if (data.Length == 2)
            {
                MeasurementStatus = _Started;
            }
            else if (data.Length != 5)
            {
                dataHandler.GetData(data);
                coordsData = dataHandler.GetDataXYZCoords();
            }
            else
            {
                ComStatus = _isOpen;
            }
        }

        public void Visualize()
        {
            Task task = new Task(() =>
            {
                Window window = new Window(coordsData.Select(x=>
                { return new Tuple<double, double, double>(x.X, x.Y, x.Z); }).ToList());
                window.ShowWindow();
            });
            task.Start();
        }


    }


}