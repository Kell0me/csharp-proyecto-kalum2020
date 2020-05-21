using System.Windows;
using Kalum2020v1.ModelViews;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace Kalum2020v1.Views
{
    public  partial class HorarioView : MetroWindow
    {
        
        private HorarioViewModel model;
        public HorarioView()
        {
        InitializeComponent();
        model = new HorarioViewModel(DialogCoordinator.Instance);
        this.DataContext = model;
        } 
    }
}