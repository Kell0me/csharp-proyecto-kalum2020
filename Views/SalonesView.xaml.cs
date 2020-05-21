using System.Windows;
using Kalum2020v1.ModelViews;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace Kalum2020v1.Views
{
    public  partial class SalonView : MetroWindow
    {
        
        private SalonViewModel model;
        public SalonView()
        {
        InitializeComponent();
        model = new SalonViewModel(DialogCoordinator.Instance);
        this.DataContext = model;
        } 
    }
}