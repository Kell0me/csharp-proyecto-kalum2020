using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Kalum2020v1.DataContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Kalum2020v1.Models;
using MahApps.Metro.Controls.Dialogs;

namespace Kalum2020v1.ModelViews
{
    public class LoginModelView : INotifyPropertyChanged, ICommand 
    {
         private string _ImgFoto = $"{Environment.CurrentDirectory}\\Images\\acceso.png";
        public string ImgFoto
       {
            get { return _ImgFoto;}
            set { _ImgFoto = value;}
        }
        private IDialogCoordinator _DialogCoordinator;
        private KalumDbContext _DbContext;
        private MainViewModel _MainViewModel;
        public MainViewModel MainViewModel
        {
            get { return _MainViewModel; }
            set { _MainViewModel = value; }
        }
        
        private string _Password;

        private Usuario _Usuario;
        private Usuario Usuario
        {
            get { return _Usuario;}
            set { _Usuario = value;}
        }
        public string Password
        {
            get { return _Password; }
            set { _Password = value; NotificarCambio("Password"); }
        }
        private string _Username;
        public string Username
        {
            get { return _Username; }
            set { _Username = value; NotificarCambio("Username"); }
        }

        private LoginModelView _Instancia;
        public LoginModelView Instancia
        {
            get { return _Instancia; }
            set { _Instancia = value; NotificarCambio("Instancia"); }
        }

        public LoginModelView(IDialogCoordinator instance, MainViewModel mainViewModel)
        {
            this.MainViewModel = mainViewModel;
            this.Instancia = this;
            this._DialogCoordinator = instance;
            this._DbContext = new KalumDbContext();

        }
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parametro)
        {
            return true;
        }
        public async void Execute(object parametro)
        {
            if (parametro is Window)
            {
                Password =
                ((PasswordBox)((Window)parametro).FindName("txtPassword")).Password;
                var UsernameParameter = new SqlParameter("@Username", Username);
                var PasswordParameter = new SqlParameter("@Password", Password);
                try{
                var Resultado = this._DbContext.UsuariosApp
                    .FromSqlRaw("sp_AutenticarUsuario @Username,@Password",
                        UsernameParameter, PasswordParameter).ToList();
                foreach (Object objeto in Resultado)
                {
                    this.Usuario = (Usuario)objeto;
                }
                if (this.Usuario != null)
                {
                    await this._DialogCoordinator.ShowMessageAsync(this,"Login",$"Bienvenido {_Usuario.Apellidos} {_Usuario.Nombres}");
                    this.MainViewModel.IsMenuCatalogo = true;
                    this.MainViewModel.IsMenuLogin = false;
                    this.MainViewModel.Usuario = this.Usuario;
                    ((Window)parametro).Close();
                }
                else
                {
                    MessageBox.Show("El usuario no existe");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        }
        public void NotificarCambio(string propiedad)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propiedad));
            }
        }

    }
}
