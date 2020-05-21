using Kalum2020v1.ModelViews;
using MahApps.Metro.Controls;
namespace Kalum2020v1.Views
{
    public partial class LoginView : MetroWindow
    {
        private LoginModelView _ModelView;
        public LoginView()
        {
            InitializeComponent();
            _ModelView = new LoginModelView();
            this.DataContext = _ModelView;
        }
        
    }
}