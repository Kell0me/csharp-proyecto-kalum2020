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
     enum AACCIONES
    {
        NINGUNO,
        NUEVO,
        MODIFICAR
    }

    
    public class InstructorViewModel : INotifyPropertyChanged, ICommand
    {
        private AACCIONES _accion = AACCIONES.NINGUNO;
        private KalumDbContext dbcontext; 
        private InstructorViewModel _Instancia;

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

        private Instructor _Update;
        public Instructor Update
        {
            get { return _Update; }
            set { _Update = value; }
        }

        private bool _IsReadOnlyApellidos = true;
        public bool IsReadOnlyApellidos
        {
            get { return _IsReadOnlyApellidos; }
            set { _IsReadOnlyApellidos = value; NotificarCambio("IsReadOnlyApellidos"); }
        }

        private bool _IsReadOnlyNombres = true;
        public bool IsReadOnlyNombres
        {
            get { return _IsReadOnlyNombres; }
            set { _IsReadOnlyNombres = value; NotificarCambio("IsReadOnlyNombres"); }
        }
        private bool _IsReadOnlyDirecciones = true;
        public bool IsReadOnlyDirecciones
        {
            get { return _IsReadOnlyDirecciones; }
            set { _IsReadOnlyDirecciones = value; NotificarCambio("IsReadOnlyDireccion"); }
        }
        private bool _IsReadOnlyTelefonos = true;
        public bool IsReadOnlyTelefonos
        {
            get { return _IsReadOnlyTelefonos; }
            set { _IsReadOnlyTelefonos = value; NotificarCambio("IsReadOnlyTelefono"); }
        }
        private bool _IsReadOnlyComentarios = true;
        public bool IsReadOnlyComentarios
        {
            get { return _IsReadOnlyComentarios; }
            set { _IsReadOnlyComentarios = value; NotificarCambio("IsReadOnlyComentario"); }
        }
        private bool _IsReadOnlyStatus = true;
        public bool IsReadOnlyStatus
        {
            get { return _IsReadOnlyStatus; }
            set { _IsReadOnlyStatus = value; NotificarCambio("IsReadOnlyStatus"); }
        }
        private bool _IsReadOnlyFotografias = true;
        public bool IsReadOnlyFotografias
        {
            get { return _IsReadOnlyFotografias; }
            set { _IsReadOnlyFotografias = value; NotificarCambio("IsReadOnlyFotografia"); }
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

        public InstructorViewModel Instancia
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

        private Instructor _ElementoSeleccionado;

        public Instructor ElementoSeleccionado
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
        

        private ObservableCollection<Instructor> _ListaInstructores;

        public ObservableCollection<Instructor> ListaInstructores
        {
            get
            {
                if(_ListaInstructores == null)
                {
                    _ListaInstructores = new ObservableCollection<Instructor>(dbcontext.Instructores.ToList()); // equivale a select * from alumnos

                }
                return _ListaInstructores;

            }
            set
            {
                _ListaInstructores = value;

            }
        }

        public InstructorViewModel(IDialogCoordinator instance)
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
                this._accion = AACCIONES.NUEVO;
                this.ElementoSeleccionado = new Instructor();
                this.IsNuevo = false;
                this.IsEliminar = false;
                this.IsModificar = false;
                this.IsGuardar = true;
                this.IsCancelar = true;
                this.IsReadOnlyApellidos = false;
                this.IsReadOnlyNombres = false;
                this.IsReadOnlyDirecciones = false;
                this.IsReadOnlyTelefonos = false;
                this.IsReadOnlyComentarios = false;
                this.IsReadOnlyStatus = false;
                this.IsReadOnlyFotografias = false;

            }
            else if (parametro.Equals("Modificar"))
            {
                if(this.ElementoSeleccionado != null)
                {
                    this._accion = AACCIONES.MODIFICAR;
                    this.IsNuevo = false;
                    this.IsEliminar = false;
                    this.IsModificar = false;
                    this.IsGuardar = true;
                    this.IsCancelar = true;
                    this.IsReadOnlyApellidos = false;
                    this.IsReadOnlyNombres = false;
                    this.IsReadOnlyDirecciones = false;
                    this.IsReadOnlyTelefonos = false;
                    this.IsReadOnlyComentarios = false;
                    this.IsReadOnlyStatus = false;
                    this.IsReadOnlyFotografias = false;
                    this.Posicion = this.ListaInstructores.IndexOf(this.ElementoSeleccionado);
                    this.Update = new Instructor();
                    this.Update.Apellidos = this.ElementoSeleccionado.Apellidos;
                    this.Update.Nombres = this.ElementoSeleccionado.Nombres;
                    this.Update.Direccion = this.ElementoSeleccionado.Direccion;
                    this.Update.Telefono = this.ElementoSeleccionado.Telefono;
                    this.Update.Comentario = this.ElementoSeleccionado.Comentario;
                    this.Update.Estatus = this.ElementoSeleccionado.Estatus;
                    this.Update.Foto = this.ElementoSeleccionado.Foto;

                }
                else
                {
                    await this.dialogCoordinator.ShowMessageAsync(this,"Instructor",
                        "Debe seleccionar un elemento");
                }
            }
            else if (parametro.Equals("Guardar"))
            {
                switch (this._accion)
                {
                    case AACCIONES.NUEVO:
                        try
                        {
                            //Religion r = this.dbcontext.Religiones.Find(1); // Select * from Religiones where ReligionId = 1                      
                            //this.ElementoSeleccionado.Religion = r;
                            this.dbcontext.Instructores.Add(this.ElementoSeleccionado); // insert into Alumno values(...)
                            this.dbcontext.SaveChanges();
                            this.ListaInstructores.Add(this.ElementoSeleccionado);
                            await this.dialogCoordinator.ShowMessageAsync(this,"Intructor",
                            "Datos actualizados!!!");
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message);
                        }
                        break;
                    case AACCIONES.MODIFICAR:
                        if (this.ElementoSeleccionado != null)
                        {                            
                            this.dbcontext.Entry(this.ElementoSeleccionado).State = EntityState.Modified;
                            this.dbcontext.SaveChanges();
                            await this.dialogCoordinator.ShowMessageAsync(this,"Instructor",
                            "Datos actualizados!!!");
                            this.IsNuevo = true;
                            this.IsEliminar = true;
                            this.IsModificar = true;
                            this.IsGuardar = false;
                            this.IsCancelar = false;

                        }
                        else
                        {
                        await this.dialogCoordinator.ShowMessageAsync(this,"Instructor",
                            "Debe seleccionar un elemento");
                        }
                        break;
                }
            }            
            else if (parametro.Equals("Cancelar"))
            {
                if(this._accion == AACCIONES.MODIFICAR)
                {
                    this.ListaInstructores.RemoveAt(this.Posicion);
                    ListaInstructores.Insert(this.Posicion,this.Update);
                }
                this.IsNuevo = true;
                this.IsEliminar = true;
                this.IsModificar = true;
                this.IsGuardar = false;
                this.IsCancelar = false;
                this.IsReadOnlyApellidos = false;
                    this.IsReadOnlyNombres = false;
                    this.IsReadOnlyDirecciones = false;
                    this.IsReadOnlyTelefonos = false;
                    this.IsReadOnlyComentarios = false;
                    this.IsReadOnlyStatus = false;
                    this.IsReadOnlyFotografias = false;
            }
            else if(parametro.Equals("Eliminar"))
            {
                if(this.ElementoSeleccionado != null)
                {
                    MessageDialogResult resultado = await this.dialogCoordinator.ShowMessageAsync(this,
                        "Eliminar Instructor",
                        "Esta seguro de eliminar el registro?",
                        MessageDialogStyle.AffirmativeAndNegative);
                    if(resultado == MessageDialogResult.Affirmative)
                    {
                        this.dbcontext.Remove(this.ElementoSeleccionado);
                        this.dbcontext.SaveChanges();
                        this.ListaInstructores.Remove(this.ElementoSeleccionado);
                        await this.dialogCoordinator.ShowMessageAsync(this,"Instructor",
                        "Registro eliminado");
                    }
                }
                else
                {
                    await this.dialogCoordinator.ShowMessageAsync(this,"Instructor",
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