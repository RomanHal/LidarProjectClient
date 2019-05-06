using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lidar
{
    public class MainWindowViewModel : BindableBase
    {
        ModelMainWindow _model = new ModelMainWindow();
        public CommandClass OpenVisualisation { get; set; }
        public CommandClass RefreshCom { get; set; }
        public CommandClass StartMeasurement { get; set; }
        public CommandClass OpenCom { get; set; }
        private string _selectedCom;

        public string[] Coms => _model.AvalibleComs;
        public string ComStatus => _model.ComStatus;
        public string SelectedCom { get => _model.SelectedPort; set {
                RaisePropertyChanged(nameof(SelectedCom));
                _model.SelectedPort = value; } }
        public string MeasurementStatus => _model.MeasurementStatus;
        public MainWindowViewModel()
        {
            OpenVisualisation = new CommandClass(VisualiseThis);
            StartMeasurement = new CommandClass(_model.TryMeasure);
            OpenCom = new CommandClass(_model.TryOpenCom);
            _model.PropertyChanged += _model_PropertyChanged;
        }

        private void _model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            RaisePropertyChanged(e.PropertyName);
        }

        public static bool True()
        {
            return true;
        }
        public void VisualiseThis()
        {
            _model.Visualize();
        }

    }
}
