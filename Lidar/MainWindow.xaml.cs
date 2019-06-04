using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace Lidar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel()
            {
                SaveAs = File.WriteAllLines,
                SelectPath = SelectDirectory
            };
        }

        private string SelectDirectory()
        {
            var dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == true)
                return dialog.FileName;
            return "temp";
        }
    }
}
