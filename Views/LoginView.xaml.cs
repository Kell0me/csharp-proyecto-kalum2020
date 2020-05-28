using Kalum2020v1.Models;
using Kalum2020v1.ModelViews;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace Kalum2020v1.Views
{
    public partial class LoginView : MetroWindow
    {
        private LoginModelView _ModelView;
        public LoginView(MainViewModel mainViewModel)
        {
            InitializeComponent();
            _ModelView = new LoginModelView(DialogCoordinator.Instance,mainViewModel);
            this.DataContext = _ModelView;
        }
        
    }
}