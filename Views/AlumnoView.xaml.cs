using System.Windows;
using Kalum2020v1.ModelViews;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;



namespace Kalum2020v1.Views
{
    public partial class AlumnoView : MetroWindow
    {
        private AlumnoViewModel model;
        public AlumnoView()
        {
        InitializeComponent();
        model = new AlumnoViewModel(DialogCoordinator.Instance);
        this.DataContext = model;
        } 
        
    }
}