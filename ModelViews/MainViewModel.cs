using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Kalum2020v1.Models;
using Kalum2020v1.Views;

namespace Kalum2020v1.ModelViews
{

    public class MainViewModel : INotifyPropertyChanged, ICommand
    {
        private string _ImgHome = $"{Environment.CurrentDirectory}\\Images\\home.png";
        public string ImgHome
        {
            get { return _ImgHome; }
            set { _ImgHome = value; }
        }
        private string _ImgFoto = $"{Environment.CurrentDirectory}\\Images\\System.jpg";
        public string ImgFoto
        {
            get { return _ImgFoto; }
            set { _ImgFoto = value; }
        }

        
        private Usuario _Usuario;
        public Usuario Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }
                
        private bool _IsMenuCatalogo = false;
        public bool IsMenuCatalogo
        {
            get { return _IsMenuCatalogo; }
            set { _IsMenuCatalogo = value; NotificarCambio("IsMenuCatalogo");}
        }

        private bool _IsMenuLogin = true;
        public bool IsMenuLogin
        {
            get { return _IsMenuLogin; }
            set { _IsMenuLogin = value; NotificarCambio("IsMenuLogin");}
        }

        
        public MainViewModel _Instancia;
        public MainViewModel Instancia
        {
            get{
                return this._Instancia;
            }
            set{
                this._Instancia = value;
                NotificarCambio("Instancia");
            }

        }
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parametro)
        {
            if(parametro.Equals("AlumnosView"))
            {
                AlumnoView view = new AlumnoView();
                view.ShowDialog();
            }
            else if(parametro.Equals("Login"))
            {
                LoginView view = new LoginView(this);
                view.ShowDialog();

            }
            else if(parametro.Equals("CarrerasTecnicas"))
            {
                new CarreraTecnicaView().ShowDialog();
            }
            else if(parametro.Equals("Horarios"))
            {
                new HorarioView().ShowDialog();
            }
            else if(parametro.Equals("Instructores"))
            {
                new InstructorView().ShowDialog();
            }
            else if(parametro.Equals("Religiones"))
            {
                new ReligionView().ShowDialog();                
            }
            else if(parametro.Equals("Salones"))
            {
                new SalonView().ShowDialog();
            }
            else if(parametro.Equals("Salir"))
            {
                Application.Current.Shutdown();
            }
           
        }
        public MainViewModel()
        {
            this.Instancia = this;
        }
        public void NotificarCambio(string propiedad)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this,new PropertyChangedEventArgs(propiedad));
            }
        }
    }
}