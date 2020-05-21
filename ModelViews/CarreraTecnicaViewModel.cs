using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Kalum2020v1.DataContext;
using Kalum2020v1.Models;
using System.Linq;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using MahApps.Metro.Controls.Dialogs;

namespace Kalum2020v1.ModelViews
{
    enum ACCIONES
    {
        NINGUNO,
        NUEVO,
        MODIFICAR

    }
    public class CarreraTecnicaViewModel : INotifyPropertyChanged, ICommand
    {
        private ACCIONES _accion = ACCIONES.NINGUNO;
        private KalumDbContext dbcontext; 
        private CarreraTecnicaViewModel _Instancia;

        private IDialogCoordinator dialogCoordinator;

        private bool _IsGuardar = false;
        private bool _IsCancelar = false;
        private bool _IsNuevo = true;
        private bool _IsModificar = true;

        private bool _IsEliminar = true;
        private int _Posicion;

        public int Posicion
        {
            get { return _Posicion; }
            set { _Posicion = value;}
        }

        private CarreraTecnica _Update;
        public CarreraTecnica Update
        {
            get { return _Update; }
            set { _Update = value; }
        }

        private bool _IsReadOnlyNombreCarrera = true;
        public bool IsReadOnlyNombreCarrera
        {
            get { return _IsReadOnlyNombreCarrera; }
            set { _IsReadOnlyNombreCarrera = value; NotificarCambio("IsReadOnlyNombreCarrera"); }
        }

        public bool IsEliminar
        {
            get
            {
                return this._IsEliminar;
            }
            set
            {
                this._IsEliminar = value;
                NotificarCambio("IsEliminar");
            }
        }

        public bool IsModificar
        {
            get
            {
                return this._IsModificar;
            }
            set
            {
                this._IsModificar = value;
                NotificarCambio("IsModificar");
            }
        }

        public bool IsNuevo
        {
            get
            {
                return this._IsNuevo;
            }
            set
            {
                this._IsNuevo = value;
                NotificarCambio("IsNuevo");
            }
        }

        public bool IsCancelar
        {
            get
            {
                return this._IsCancelar;
            }
            set
            {
                this._IsCancelar = value;
                NotificarCambio("IsCancelar");
            }
        }

        public bool IsGuardar
        {
            get
            {
                return this._IsGuardar;
            }
            set
            {
                this._IsGuardar = value;
                NotificarCambio("IsGuardar");
            }
        }

        public CarreraTecnicaViewModel Instancia
        {
            get
            {
                return this._Instancia;
            }
            set
            {
                this._Instancia = value;
                NotificarCambio("Instancia");
            }
        }

        private CarreraTecnica _ElementoSeleccionado;

        public CarreraTecnica ElementoSeleccionado
        {
            get
            {
                return this._ElementoSeleccionado;
            }
            set
            {
                this._ElementoSeleccionado = value;
                NotificarCambio("ElementoSeleccionado");
            }
        }
        private ObservableCollection<CarreraTecnica> _ListaCarreraTecnicas;

        public ObservableCollection<CarreraTecnica> ListaCarreraTecnicas
        {
            get
            {
                if(_ListaCarreraTecnicas == null)
                {
                    _ListaCarreraTecnicas = new ObservableCollection<CarreraTecnica>(dbcontext.CarreraTecnicas.ToList()); // equivale a select * from alumnos

                }
                return _ListaCarreraTecnicas;

            }
            set
            {
                _ListaCarreraTecnicas = value;

            }
        }

        public CarreraTecnicaViewModel(IDialogCoordinator instance)
        {
            this.dialogCoordinator = instance;
            this.dbcontext = new KalumDbContext();
            this.Instancia = this;
        }

        public event EventHandler CanExecuteChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        public bool CanExecute(object parametro)
        {
            return true;
        }

        public async void Execute(object parametro)
        {
             if (parametro.Equals("Nuevo"))
            {
                this._accion = ACCIONES.NUEVO;
                this.ElementoSeleccionado = new CarreraTecnica();
                this.IsNuevo = false;
                this.IsEliminar = false;
                this.IsModificar = false;
                this.IsGuardar = true;
                this.IsCancelar = true;
                this.IsReadOnlyNombreCarrera = false;
            }
            else if (parametro.Equals("Modificar"))
            {
                if(this.ElementoSeleccionado != null)
                {
                    this._accion = ACCIONES.MODIFICAR;
                    this.IsNuevo = false;
                    this.IsEliminar = false;
                    this.IsModificar = false;
                    this.IsGuardar = true;
                    this.IsCancelar = true;
                    this.IsReadOnlyNombreCarrera = false;
                    this.Posicion = this.ListaCarreraTecnicas.IndexOf(this.ElementoSeleccionado);
                    this.Update = new CarreraTecnica();
                    this.Update.NombreCarrera = this.ElementoSeleccionado.NombreCarrera;
                }
                else
                {
                    await this.dialogCoordinator.ShowMessageAsync(this,"Carrera Tecnica",
                        "Debe seleccionar un elemento");
                }
            }
            else if (parametro.Equals("Guardar"))
            {
                switch (this._accion)
                {
                    case ACCIONES.NUEVO:
                        try
                        {
                            //Religion r = this.dbcontext.Religiones.Find(1); // Select * from Religiones where ReligionId = 1                      
                            //this.ElementoSeleccionado.Religion = r;
                            this.dbcontext.CarreraTecnicas.Add(this.ElementoSeleccionado); // insert into Alumno values(...)
                            this.dbcontext.SaveChanges();
                            this.ListaCarreraTecnicas.Add(this.ElementoSeleccionado);
                            await this.dialogCoordinator.ShowMessageAsync(this,"Carrera Tecnica",
                            "Datos actualizados!!!");
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message);
                        }
                        break;
                    case ACCIONES.MODIFICAR:
                        if (this.ElementoSeleccionado != null)
                        {                            
                            this.dbcontext.Entry(this.ElementoSeleccionado).State = EntityState.Modified;
                            this.dbcontext.SaveChanges();
                            await this.dialogCoordinator.ShowMessageAsync(this,"Carrera Tecnica",
                            "Datos actualizados!!!");
                            this.IsNuevo = true;
                            this.IsEliminar = true;
                            this.IsModificar = true;
                            this.IsGuardar = false;
                            this.IsCancelar = false;

                        }
                        else
                        {
                        await this.dialogCoordinator.ShowMessageAsync(this,"Carrera Tecnica",
                            "Debe seleccionar un elemento");
                        }
                        break;
                }
            }            
            else if (parametro.Equals("Cancelar"))
            {
                if(this._accion == ACCIONES.MODIFICAR)
                {
                    this.ListaCarreraTecnicas.RemoveAt(this.Posicion);
                    ListaCarreraTecnicas.Insert(this.Posicion,this.Update);
                }
                this.IsNuevo = true;
                this.IsEliminar = true;
                this.IsModificar = true;
                this.IsGuardar = false;
                this.IsCancelar = false;
                this.IsReadOnlyNombreCarrera = true;
            }
            else if(parametro.Equals("Eliminar"))
            {
                if(this.ElementoSeleccionado != null)
                {
                    MessageDialogResult resultado = await this.dialogCoordinator.ShowMessageAsync(this,
                        "Eliminar Carrera Tecnica",
                        "Esta seguro de eliminar el registro?",
                        MessageDialogStyle.AffirmativeAndNegative);
                    if(resultado == MessageDialogResult.Affirmative)
                    {
                        this.dbcontext.Remove(this.ElementoSeleccionado);
                        this.dbcontext.SaveChanges();
                        this.ListaCarreraTecnicas.Remove(this.ElementoSeleccionado);
                        await this.dialogCoordinator.ShowMessageAsync(this,"Carrera Tecnica",
                        "Registro eliminado");
                    }
                }
                else
                {
                    await this.dialogCoordinator.ShowMessageAsync(this,"Carrera Tecnica",
                        "Debe seleccionar un elemento");
                }
            }
        }

        public void NotificarCambio(String propiedad)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propiedad));
            }

        }
    }
}
            
        
    
