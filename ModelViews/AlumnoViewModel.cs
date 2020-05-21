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
    enum ACCION
    {
        NINGUNO,
        NUEVO,
        MODIFICAR

    }
    public class AlumnoViewModel : INotifyPropertyChanged, ICommand
    {
       private string _imgSystem = $"{Environment.CurrentDirectory}\\Images\\System.png";
        public string imgSystem
        {
            get{ return _imgSystem;} set{_imgSystem = value; NotificarCambio ("imgSystem"); }
        } 
        private ACCION _accion = ACCION.NINGUNO;
        private KalumDbContext dbContext;

        private AlumnoViewModel _Instancia;

        private IDialogCoordinator dialogCoordinator;

        private bool _IsGuardar = false;
        private bool _IsCancelar = false;
        private bool _IsNuevo = true;
        private bool _IsModificar = true;

        private bool _IsEliminar = true;
        private bool _IsReadOnlyApellidos = true;

        private int _Posicion;
        public int Posicion
        {
            get { return _Posicion; }
            set { _Posicion = value;}
        }
        
        private Alumno _Update;
        public Alumno Update
        {
            get { return _Update; }
            set { _Update = value; }
        }
        
        private bool _IsReadOnlyCarne = true;
        public bool IsReadOnlyCarne
        {
            get { return _IsReadOnlyCarne; }
            set { _IsReadOnlyCarne = value; NotificarCambio("IsReadOnlyCarne"); }
        }
                
        public bool IsReadOnlyApellidos { 
            get
            {
                return _IsReadOnlyApellidos;
            } 
            set
            {
                this._IsReadOnlyApellidos = value;
                NotificarCambio("IsReadOnlyApellidos");
            } 
        }
    
        private bool _IsReadOnlyNombres = true;
        public bool IsReadOnlyNombres
        {
            get { return _IsReadOnlyNombres; }
            set { this._IsReadOnlyNombres = value; NotificarCambio("IsReadOnlyNombres"); }
        }
        
        private bool _IsFechaNacimiento = false;
        public bool IsFechaNacimiento
        {
            get { return _IsFechaNacimiento; }
            set { this._IsFechaNacimiento = value; NotificarCambio("IsFechaNacimiento"); }
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
        public AlumnoViewModel Instancia
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
        private Alumno _ElementoSeleccionado;

        public Alumno ElementoSeleccionado
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
        private ObservableCollection<Alumno> _ListaAlumnos;

        public ObservableCollection<Alumno> ListaAlumnos
        {
            get
            {
                if (_ListaAlumnos == null)
                {
                    _ListaAlumnos = new ObservableCollection<Alumno>(dbContext.Alumnos.ToList()); // select * from Alumnos
                }
                return _ListaAlumnos;

            }
            set
            {
                _ListaAlumnos = value;
            }
        }

        public AlumnoViewModel(IDialogCoordinator instance)
        {
            this.dialogCoordinator = instance;
            this.dbContext = new KalumDbContext();
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
                this._accion = ACCION.NUEVO;
                this.ElementoSeleccionado = new Alumno();
                this.IsNuevo = false;
                this.IsEliminar = false;
                this.IsModificar = false;
                this.IsGuardar = true;
                this.IsCancelar = true;
                this.IsReadOnlyCarne = false;
                this.IsReadOnlyApellidos = false;
                this.IsReadOnlyNombres = false;
                this.IsFechaNacimiento = true;
            }
            else if (parametro.Equals("Modificar"))
            {
                if(this.ElementoSeleccionado != null)
                {
                    this._accion = ACCION.MODIFICAR;
                    this.IsNuevo = false;
                    this.IsEliminar = false;
                    this.IsModificar = false;
                    this.IsGuardar = true;
                    this.IsCancelar = true;
                    this.IsReadOnlyApellidos = false;
                    this.IsReadOnlyNombres = false;
                    this.IsFechaNacimiento = true;
                    this.Posicion = this.ListaAlumnos.IndexOf(this.ElementoSeleccionado);
                    this.Update = new Alumno();
                    this.Update.AlumnoId = this.ElementoSeleccionado.AlumnoId;
                    this.Update.Carne = this.ElementoSeleccionado.Carne;
                    this.Update.Apellidos = this.ElementoSeleccionado.Apellidos;
                    this.Update.Nombres = this.ElementoSeleccionado.Nombres;
                    this.Update.FechaNacimiento = this.ElementoSeleccionado.FechaNacimiento;
                }
                else
                {
                    await this.dialogCoordinator.ShowMessageAsync(this,"Alumno",
                        "Debe seleccionar un elemento");
                }
            }
            else if (parametro.Equals("Guardar"))
            {
                switch (this._accion)
                {
                    case ACCION.NUEVO:
                        try
                        {
                            Religion r = this.dbContext.Religiones.Find(1); // Select * from Religiones where ReligionId = 1                      
                            this.ElementoSeleccionado.Religion = r;
                            this.dbContext.Alumnos.Add(this.ElementoSeleccionado); // insert into Alumno values(...)
                            this.dbContext.SaveChanges();
                            this.ListaAlumnos.Add(this.ElementoSeleccionado);
                            await this.dialogCoordinator.ShowMessageAsync(this,"Alumno",
                            "Datos actualizados!!!");
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message);
                        }
                        break;
                    case ACCION.MODIFICAR:
                        if (this.ElementoSeleccionado != null)
                        {                            
                            this.dbContext.Entry(this.ElementoSeleccionado).State = EntityState.Modified;
                            this.dbContext.SaveChanges();
                            await this.dialogCoordinator.ShowMessageAsync(this,"Alumno",
                            "Datos actualizados!!!");
                            this.IsNuevo = true;
                            this.IsEliminar = true;
                            this.IsModificar = true;
                            this.IsGuardar = false;
                            this.IsCancelar = false;

                        }
                        else
                        {
                        await this.dialogCoordinator.ShowMessageAsync(this,"Alumno",
                            "Debe seleccionar un elemento");
                        }
                        break;
                }
            }            
            else if (parametro.Equals("Cancelar"))
            {
                if(this._accion == ACCION.MODIFICAR)
                {
                    this.ListaAlumnos.RemoveAt(this.Posicion);
                    ListaAlumnos.Insert(this.Posicion,this.Update);
                }
                this.IsNuevo = true;
                this.IsEliminar = true;
                this.IsModificar = true;
                this.IsGuardar = false;
                this.IsCancelar = false;
                this.IsReadOnlyApellidos = true;
                this.IsReadOnlyNombres = true;
                this.IsFechaNacimiento = false;
            }
            else if(parametro.Equals("Eliminar"))
            {
                if(this.ElementoSeleccionado != null)
                {
                    MessageDialogResult resultado = await this.dialogCoordinator.ShowMessageAsync(this,
                        "Eliminar Alumno",
                        "Esta seguro de eliminar el registro?",
                        MessageDialogStyle.AffirmativeAndNegative);
                    if(resultado == MessageDialogResult.Affirmative)
                    {
                        this.dbContext.Remove(this.ElementoSeleccionado);
                        this.dbContext.SaveChanges();
                        this.ListaAlumnos.Remove(this.ElementoSeleccionado);
                        await this.dialogCoordinator.ShowMessageAsync(this,"Alumno",
                        "Registro eliminado");
                    }
                }
                else
                {
                    await this.dialogCoordinator.ShowMessageAsync(this,"Alumno",
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