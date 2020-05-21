using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Kalum2020v1.DataContext;
using Kalum2020v1.Models;

namespace Kalum2020v1.ModelViews
{
    
    public class ReligionViewModel : INotifyPropertyChanged, ICommand
    {
        private KalumDbContext dbcontext; 

        private ObservableCollection<Religion> _ListaReligiones;

        public ObservableCollection<Religion> ListaReligiones
        {
            get
            {
                if(_ListaReligiones == null)
                {
                    _ListaReligiones = new ObservableCollection<Religion>(dbcontext.Religiones.ToList()); // equivale a select * from alumnos

                }
                return _ListaReligiones;

            }
            set
            {
                _ListaReligiones = value;

            }
        }

        public ReligionViewModel()
        {
            this.dbcontext = new KalumDbContext();
        }

        public event EventHandler CanExecuteChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            
        }
    }
}