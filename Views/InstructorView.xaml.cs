using System.Windows;
using Kalum2020v1.ModelViews;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;


namespace Kalum2020v1.Views
{
    public partial class InstructorView : MetroWindow
    {
        private InstructorViewModel model;
        public InstructorView()
        {
        InitializeComponent();
        model = new InstructorViewModel(DialogCoordinator.Instance);
        this.DataContext = model;
        } 
        
    }
}