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
    enum AACCIONESS
    {
        NINGUNO,
        NUEVO,
        MODIFICAR

    }
    
    public class ReligionViewModel : INotifyPropertyChanged, ICommand
    {
        private string _ImgReligiones = $"{Environment.CurrentDirectory}\\Images\\religiones.png";
        public string ImgReligiones
        {
            get { return _ImgReligiones; }
            set { _ImgReligiones = value; }
        }
        private AACCIONESS _accion = AACCIONESS.NINGUNO;
        private KalumDbContext dbcontext; 
        private ReligionViewModel _Instancia;

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

        private Religion _Update;
        public Religion Update
        {
            get { return _Update; }
            set { _Update = value; }
        }

        private bool _IsReadOnlyDescripciones = true;
        public bool IsReadOnlyDescripciones
        {
            get { return _IsReadOnlyDescripciones; }
            set { _IsReadOnlyDescripciones = value; NotificarCambio("IsReadOnlyDescripcion"); }
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

        public ReligionViewModel Instancia
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

        private Religion _ElementoSeleccionado;

        public Religion ElementoSeleccionado
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

        public ReligionViewModel(IDialogCoordinator instance)
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
                this._accion = AACCIONESS.NUEVO;
                this.ElementoSeleccionado = new Religion();
                this.IsNuevo = false;
                this.IsEliminar = false;
                this.IsModificar = false;
                this.IsGuardar = true;
                this.IsCancelar = true;
                this.IsReadOnlyDescripciones = false;
            }
            else if (parametro.Equals("Modificar"))
            {
                if (this.ElementoSeleccionado != null)
                {
                    this._accion = AACCIONESS.MODIFICAR;
                    this.IsNuevo = false;
                    this.IsEliminar = false;
                    this.IsModificar = false;
                    this.IsGuardar = true;
                    this.IsCancelar = true;
                    this.IsReadOnlyDescripciones = true;
                    this.Posicion = this.ListaReligiones.IndexOf(this.ElementoSeleccionado);
                    this.Update = new Religion();
                    this.Update.Descripcion = this.ElementoSeleccionado.Descripcion;
                }
                else
                {
                    await this.dialogCoordinator.ShowMessageAsync(this, "Religion",
                        "Debe seleccionar un elemento");
                }
            }
            else if (parametro.Equals("Guardar"))
            {
                switch (this._accion)
                {
                    case AACCIONESS.NUEVO:
                        try
                        {
                            //Religion r = this.dbcontext.Religiones.Find(1); // Select * from Religiones where ReligionId = 1                      
                            //this.ElementoSeleccionado.Religion = r;
                            this.dbcontext.Religiones.Add(this.ElementoSeleccionado); // insert into Alumno values(...)
                            this.dbcontext.SaveChanges();
                            this.ListaReligiones.Add(this.ElementoSeleccionado);
                            await this.dialogCoordinator.ShowMessageAsync(this, "Religion",
                            "Datos actualizados!!!");
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message);
                        }
                        break;
                    case AACCIONESS.MODIFICAR:
                        if (this.ElementoSeleccionado != null)
                        {
                            this.dbcontext.Entry(this.ElementoSeleccionado).State = EntityState.Modified;
                            this.dbcontext.SaveChanges();
                            await this.dialogCoordinator.ShowMessageAsync(this, "Religion",
                            "Datos actualizados!!!");
                            this.IsNuevo = true;
                            this.IsEliminar = true;
                            this.IsModificar = true;
                            this.IsGuardar = false;
                            this.IsCancelar = false;

                        }
                        else
                        {
                            await this.dialogCoordinator.ShowMessageAsync(this, "Religion",
                                "Debe seleccionar un elemento");
                        }
                        break;
                }
            }
            else if (parametro.Equals("Cancelar"))
            {
                if (this._accion == AACCIONESS.MODIFICAR)
                {
                    this.ListaReligiones.RemoveAt(this.Posicion);
                    ListaReligiones.Insert(this.Posicion, this.Update);
                }
                this.IsNuevo = true;
                this.IsEliminar = true;
                this.IsModificar = true;
                this.IsGuardar = false;
                this.IsCancelar = false;
                this.IsReadOnlyDescripciones = true;
            }
            else if (parametro.Equals("Eliminar"))
            {
                if (this.ElementoSeleccionado != null)
                {
                    MessageDialogResult resultado = await this.dialogCoordinator.ShowMessageAsync(this,
                        "Eliminar Religiones",
                        "Esta seguro de eliminar el registro?",
                        MessageDialogStyle.AffirmativeAndNegative);
                    if (resultado == MessageDialogResult.Affirmative)
                    {
                        this.dbcontext.Remove(this.ElementoSeleccionado);
                        this.dbcontext.SaveChanges();
                        this.ListaReligiones.Remove(this.ElementoSeleccionado);
                        await this.dialogCoordinator.ShowMessageAsync(this, "Religion",
                        "Registro eliminado");
                    }
                }
                else
                {
                    await this.dialogCoordinator.ShowMessageAsync(this, "Religion",
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