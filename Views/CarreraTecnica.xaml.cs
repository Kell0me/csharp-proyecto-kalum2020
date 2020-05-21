using System.Windows;
using Kalum2020v1.ModelViews;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace Kalum2020v1.Views
{
    public  partial class CarreraTecnicaView : MetroWindow
    {
        
        private CarreraTecnicaViewModel model;
        public CarreraTecnicaView()
        {
        InitializeComponent();
        model = new CarreraTecnicaViewModel(DialogCoordinator.Instance);
        this.DataContext = model;
        } 
    }
}