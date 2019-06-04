using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lidar
{
    public class MainWindowViewModel : BindableBase
    {
        public Func<string> SelectPath { get; set; }
        public Action<string, IEnumerable<string>> SaveAs { get; set; }
        ModelMainWindow _model = new ModelMainWindow();
        public CommandClass OpenVisualisation { get; set; }
        public DelegateCommand RefreshCom { get; set; }
        public DelegateCommand SaveAsCommand { get; set; }
        public CommandClass StartMeasurement { get; set; }
        public CommandClass OpenCom { get; set; }
        private string _selectedCom;

        public ObservableCollection<string> Coms { get; set; }  
        public string ComStatus => _model.ComStatus;
        public string SelectedCom { get => _selectedCom; set {
                _model.SelectedPort = value;
                _selectedCom = value;
                RaisePropertyChanged(nameof(SelectedCom));
            }
        }
        public string MeasurementStatus => _model.MeasurementStatus;
        public MainWindowViewModel()
        {
            RefreshCom = new DelegateCommand(RefreshComCommand);
            SaveAsCommand = new DelegateCommand(SaveMethod);
            OpenVisualisation = new CommandClass(VisualiseThis);
            StartMeasurement = new CommandClass(_model.TryMeasure);
            OpenCom = new CommandClass(_model.TryOpenCom);
            _model.PropertyChanged += _model_PropertyChanged;
            Coms = new ObservableCollection<string>(_model.AvalibleComs);
        }

        private void RefreshComCommand()
        {
            _model.RefreshComsList();
            Coms.Clear();
            Coms.AddRange(_model.AvalibleComs);
            
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
        public void SaveMethod()
        {
            SaveAs(SelectPath(), _model.GetCords());
        }

    }
}
