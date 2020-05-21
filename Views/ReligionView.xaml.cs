using System.Windows;
using Kalum2020v1.ModelViews;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace Kalum2020v1.Views
{
    public partial class ReligionView : MetroWindow
    {
        private ReligionViewModel model;
        public ReligionView()
        {
        InitializeComponent();
        model = new ReligionViewModel(DialogCoordinator.Instance);
        this.DataContext = model;
        } 
        
    }
}