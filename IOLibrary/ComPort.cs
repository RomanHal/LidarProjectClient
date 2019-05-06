using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
namespace IOLibrary
{
    public class ComPort
    {
        SerialPort port = new SerialPort();
        public bool IsOpen => port.IsOpen;
        public Action<byte[]> ReceiveData { private get; set; }
        public ComPort()
        {
            port.DataReceived += Port_DataReceived;
        }
        public bool ConnectToPort(string name,int baudRate)
        {
            port.PortName = name;
            port.BaudRate = baudRate;
            port.Open();
            if(port.IsOpen)
            return true;
            return false;
        }


        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort port = (SerialPort)sender;
            var bytesToRead = port.BytesToRead;
            var recievedBytes = new byte[bytesToRead] ;
             port.Read(recievedBytes, 0, bytesToRead);
            //for (int i=0;i<port.BytesToRead;i++)
            //{
            //    recievedBytes[i] =(byte) port.ReadByte();
            //}
          //  port.DiscardInBuffer();
            ReceiveData(recievedBytes);
        }
        public string[] AvaliblePorts()
        {
            return SerialPort.GetPortNames();
        }
        
        public void Send(byte[] data)
        {
            port.Write(data,0,data.Length);
        }

    }
}
