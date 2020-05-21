using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Kalum2020v1.ModelViews;
using Kalum2020v1.Views;
using MahApps.Metro.Controls;

namespace Kalum2020v1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private MainViewModel Modelo;
                
        public MainWindow()
        {
            InitializeComponent();
            Modelo = new MainViewModel();
            this.DataContext = Modelo;

        }
    }
}
