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
    enum ACCIONESS
    {
        NINGUNO,
        NUEVO,
        MODIFICAR

    }

    public class HorarioViewModel : INotifyPropertyChanged, ICommand
    {
        private ACCIONESS _accion = ACCIONESS.NINGUNO;
        private KalumDbContext dbcontext; 

        private HorarioViewModel _Instancia;

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

        private Horario _Update;
        public Horario Update
        {
            get { return _Update; }
            set { _Update = value; }
        }

        private bool _IsReadOnlyHorarioInicio = true;
        public bool IsReadOnlyHorarioInicio
        {
            get { return _IsReadOnlyHorarioInicio; }
            set { _IsReadOnlyHorarioInicio = value; NotificarCambio("IsReadOnlyHorario"); }
        }

        private bool _IsReadOnlyHorarioFinal = true;
        public bool IsReadOnlyHorarioFinal
        {
            get { return _IsReadOnlyHorarioFinal; }
            set { _IsReadOnlyHorarioFinal = value; NotificarCambio("IsReadOnlyHorario"); }
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

        public HorarioViewModel Instancia
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

        private Horario _ElementoSeleccionado;

        public Horario ElementoSeleccionado
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


        private ObservableCollection<Horario> _ListaHorarios;

        public ObservableCollection<Horario> ListaHorarios
        {
            get
            {
                if(_ListaHorarios == null)
                {
                    _ListaHorarios = new ObservableCollection<Horario>(dbcontext.Horarios.ToList()); // equivale a select * from alumnos

                }
                return _ListaHorarios;

            }
            set
            {
                _ListaHorarios = value;

            }
        }

        public HorarioViewModel(IDialogCoordinator instance)
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
                this._accion = ACCIONESS.NUEVO;
                this.ElementoSeleccionado = new Horario();
                this.IsNuevo = false;
                this.IsEliminar = false;
                this.IsModificar = false;
                this.IsGuardar = true;
                this.IsCancelar = true;
                this.IsReadOnlyHorarioInicio = false;
                this.IsReadOnlyHorarioFinal = false;
            }
            else if (parametro.Equals("Modificar"))
            {
                if(this.ElementoSeleccionado != null)
                {
                    this._accion = ACCIONESS.MODIFICAR;
                    this.IsNuevo = false;
                    this.IsEliminar = false;
                    this.IsModificar = false;
                    this.IsGuardar = true;
                    this.IsCancelar = true;
                    this.IsReadOnlyHorarioInicio = true;
                    this.IsReadOnlyHorarioFinal = true;
                    this.Posicion = this.ListaHorarios.IndexOf(this.ElementoSeleccionado);
                    this.Update = new Horario();
                    this.Update.HorarioInicio = this.ElementoSeleccionado.HorarioInicio;
                    this.Update.HorarioFinal = this.ElementoSeleccionado.HorarioFinal;
                }
                else
                {
                    await this.dialogCoordinator.ShowMessageAsync(this,"Horario",
                        "Debe seleccionar un elemento");
                }
            }
            else if (parametro.Equals("Guardar"))
            {
                switch (this._accion)
                {
                    case ACCIONESS.NUEVO:
                        try
                        {
                            //Religion r = this.dbcontext.Religiones.Find(1); // Select * from Religiones where ReligionId = 1                      
                            //this.ElementoSeleccionado.Religion = r;
                            this.dbcontext.Horarios.Add(this.ElementoSeleccionado); // insert into Alumno values(...)
                            this.dbcontext.SaveChanges();
                            this.ListaHorarios.Add(this.ElementoSeleccionado);
                            await this.dialogCoordinator.ShowMessageAsync(this,"Horario",
                            "Datos actualizados!!!");
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message);
                        }
                        break;
                    case ACCIONESS.MODIFICAR:
                        if (this.ElementoSeleccionado != null)
                        {                            
                            this.dbcontext.Entry(this.ElementoSeleccionado).State = EntityState.Modified;
                            this.dbcontext.SaveChanges();
                            await this.dialogCoordinator.ShowMessageAsync(this,"Horario",
                            "Datos actualizados!!!");
                            this.IsNuevo = true;
                            this.IsEliminar = true;
                            this.IsModificar = true;
                            this.IsGuardar = false;
                            this.IsCancelar = false;

                        }
                        else
                        {
                        await this.dialogCoordinator.ShowMessageAsync(this,"Horario",
                            "Debe seleccionar un elemento");
                        }
                        break;
                }
            }            
            else if (parametro.Equals("Cancelar"))
            {
                if(this._accion == ACCIONESS.MODIFICAR)
                {
                    this.ListaHorarios.RemoveAt(this.Posicion);
                    ListaHorarios.Insert(this.Posicion,this.Update);
                }
                this.IsNuevo = true;
                this.IsEliminar = true;
                this.IsModificar = true;
                this.IsGuardar = false;
                this.IsCancelar = false;
                this.IsReadOnlyHorarioInicio = true;
                this.IsReadOnlyHorarioFinal = true;
            }
            else if(parametro.Equals("Eliminar"))
            {
                if(this.ElementoSeleccionado != null)
                {
                    MessageDialogResult resultado = await this.dialogCoordinator.ShowMessageAsync(this,
                        "Eliminar Horario",
                        "Esta seguro de eliminar el registro?",
                        MessageDialogStyle.AffirmativeAndNegative);
                    if(resultado == MessageDialogResult.Affirmative)
                    {
                        this.dbcontext.Remove(this.ElementoSeleccionado);
                        this.dbcontext.SaveChanges();
                        this.ListaHorarios.Remove(this.ElementoSeleccionado);
                        await this.dialogCoordinator.ShowMessageAsync(this,"Horario",
                        "Registro eliminado");
                    }
                }
                else
                {
                    await this.dialogCoordinator.ShowMessageAsync(this,"Horario",
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