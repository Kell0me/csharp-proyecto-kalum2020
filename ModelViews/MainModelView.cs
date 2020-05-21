using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Kalum2020v1.DataContext;
using Kalum2020v1.Models;

namespace Kalum2020v1.ModelViews
{
    public class MainModelView
    {
        private string _imgSystem = $"{Environment.CurrentDirectory}\\Images\\System.png";
        public string imgSystem
        {
            get{ return _imgSystem;} set{_imgSystem = value; NotificarCambio ("imgSystem"); }
        } 
        private string _imgAlumnos = $"{Environment.CurrentDirectory}\\Images\\Alumnos.png";
        public string imgAlumnos
        {
            get{ return _imgAlumnos;} set{_imgAlumnos = value; NotificarCambio ("imgAlumnos"); }
        } 

        public event EventHandler CanExecuteChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        public bool CanExecute(object parametro)
        {
            return true;
        }

        public void NotificarCambio(string propiedad)
        {
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propiedad));
            }
        }

        
    }
}