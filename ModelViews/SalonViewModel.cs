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
    enum ACIONESS
    {
        NINGUNO,
        NUEVO,
        MODIFICAR

    }
    
    public class SalonViewModel : INotifyPropertyChanged, ICommand
    {
        private ACIONESS _accion = ACIONESS.NINGUNO;
        private KalumDbContext dbcontext; 
        private SalonViewModel _Instancia;

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

        private Salon _Update;
        public Salon Update
        {
            get { return _Update; }
            set { _Update = value; }
        }

        private bool _IsReadOnlyNombreSalones = true;
        public bool IsReadOnlyNombreSalones
        {
            get { return _IsReadOnlyNombreSalones; }
            set { _IsReadOnlyNombreSalones = value; NotificarCambio("IsReadOnlysalon"); }
        }

        private bool _IsReadOnlyDescripciones = true;
        public bool IsReadOnlyDescripciones
        {
            get { return _IsReadOnlyDescripciones; }
            set { _IsReadOnlyDescripciones = value; NotificarCambio("IsReadOnlyDescripcion"); }
        }

        private bool _IsReadOnlyCapacidades = true;
        public bool IsReadOnlyCapacidades
        {
            get { return _IsReadOnlyCapacidades; }
            set { _IsReadOnlyCapacidades = value; NotificarCambio("IsReadOnlyCapacidad"); }
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

        public SalonViewModel Instancia
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

        private Salon _ElementoSeleccionado;

        public Salon ElementoSeleccionado
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

        public SalonViewModel(IDialogCoordinator instance)
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
                this._accion = ACIONESS.NUEVO;
                this.ElementoSeleccionado = new Salon();
                this.IsNuevo = false;
                this.IsEliminar = false;
                this.IsModificar = false;
                this.IsGuardar = true;
                this.IsCancelar = true;
                this.IsReadOnlyNombreSalones = false;
                this.IsReadOnlyDescripciones = false;
                this.IsReadOnlyCapacidades = false;
            }
            else if (parametro.Equals("Modificar"))
            {
                if(this.ElementoSeleccionado != null)
                {
                    this._accion = ACIONESS.MODIFICAR;
                    this.IsNuevo = false;
                    this.IsEliminar = false;
                    this.IsModificar = false;
                    this.IsGuardar = true;
                    this.IsCancelar = true;
                    this.IsReadOnlyNombreSalones = false;
                    this.IsReadOnlyDescripciones = false;
                    this.IsReadOnlyCapacidades = false;
                    this.Posicion = this.ListaSalones.IndexOf(this.ElementoSeleccionado);
                    this.Update = new Salon();
                    this.Update.NombreSalon = this.ElementoSeleccionado.NombreSalon;
                    this.Update.Descripcion = this.ElementoSeleccionado.Descripcion;
                    this.Update.Capacidad = this.ElementoSeleccionado.Capacidad;
                }
                else
                {
                    await this.dialogCoordinator.ShowMessageAsync(this,"Salon",
                        "Debe seleccionar un elemento");
                }
            }
            else if (parametro.Equals("Guardar"))
            {
                switch (this._accion)
                {
                    case ACIONESS.NUEVO:
                        try
                        {
                            //Religion r = this.dbcontext.Religiones.Find(1); // Select * from Religiones where ReligionId = 1                      
                            //this.ElementoSeleccionado.Religion = r;
                            this.dbcontext.Salones.Add(this.ElementoSeleccionado); // insert into Alumno values(...)
                            this.dbcontext.SaveChanges();
                            this.ListaSalones.Add(this.ElementoSeleccionado);
                            await this.dialogCoordinator.ShowMessageAsync(this,"Salon",
                            "Datos actualizados!!!");
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message);
                        }
                        break;
                    case ACIONESS.MODIFICAR:
                        if (this.ElementoSeleccionado != null)
                        {                            
                            this.dbcontext.Entry(this.ElementoSeleccionado).State = EntityState.Modified;
                            this.dbcontext.SaveChanges();
                            await this.dialogCoordinator.ShowMessageAsync(this,"Salon",
                            "Datos actualizados!!!");
                            this.IsNuevo = true;
                            this.IsEliminar = true;
                            this.IsModificar = true;
                            this.IsGuardar = false;
                            this.IsCancelar = false;

                        }
                        else
                        {
                        await this.dialogCoordinator.ShowMessageAsync(this,"Salon",
                            "Debe seleccionar un elemento");
                        }
                        break;
                }
            }            
            else if (parametro.Equals("Cancelar"))
            {
                if(this._accion == ACIONESS.MODIFICAR)
                {
                    this.ListaSalones.RemoveAt(this.Posicion);
                    ListaSalones.Insert(this.Posicion,this.Update);
                }
                this.IsNuevo = true;
                this.IsEliminar = true;
                this.IsModificar = true;
                this.IsGuardar = false;
                this.IsCancelar = false;
                this.IsReadOnlyNombreSalones = false;
                this.IsReadOnlyDescripciones = false;
                this.IsReadOnlyCapacidades = false;
            }
            else if(parametro.Equals("Eliminar"))
            {
                if(this.ElementoSeleccionado != null)
                {
                    MessageDialogResult resultado = await this.dialogCoordinator.ShowMessageAsync(this,
                        "Eliminar Salon",
                        "Esta seguro de eliminar el registro?",
                        MessageDialogStyle.AffirmativeAndNegative);
                    if(resultado == MessageDialogResult.Affirmative)
                    {
                        this.dbcontext.Remove(this.ElementoSeleccionado);
                        this.dbcontext.SaveChanges();
                        this.ListaSalones.Remove(this.ElementoSeleccionado);
                        await this.dialogCoordinator.ShowMessageAsync(this,"Salon",
                        "Registro eliminado");
                    }
                }
                else
                {
                    await this.dialogCoordinator.ShowMessageAsync(this,"Salon",
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