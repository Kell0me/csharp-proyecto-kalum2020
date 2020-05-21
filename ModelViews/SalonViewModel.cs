using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Kalum2020v1.DataContext;
using Kalum2020v1.Models;

namespace Kalum2020v1.ModelViews
{
    
    public class SalonViewModel : INotifyPropertyChanged, ICommand
    {
        private KalumDbContext dbcontext; 

        private ObservableCollection<Salon> _ListaSalones;

        public ObservableCollection<Salon> ListaSalones
        {
            get
            {
                if(_ListaSalones == null)
                {
                    _ListaSalones = new ObservableCollection<Salon>(dbcontext.Salones.ToList()); // equivale a select * from alumnos

                }
                return _ListaSalones;

            }
            set
            {
                _ListaSalones = value;

            }
        }

        public SalonViewModel()
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