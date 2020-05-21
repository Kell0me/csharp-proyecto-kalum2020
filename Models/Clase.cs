using System.Collections.Generic;

namespace Kalum2020v1.Models
{
    public class Clase
    {
        public int ClaseID{get;set;}
        public string Descripcion {get;set;}

        public int Ciclo {get;set;}

        public int CarreraTecnicaId {get;set;}
        public int SalonID{get;set;}
        public int HorarioID{get;set;}
        public string IsntructorId{get;set;}
        public string CarreraId{get;set;}
        public int CupoMinimo{get;set;}
        public int CupoMaximo{get;set;}
        public int CantidadAsignaciones{get;set;}

        public virtual CarreraTecnica CarreraTecnica {get;set;}
        
        public virtual Horario Horario {get;set;}

        public virtual Salon Salon {get;set;}

        public virtual Instructor Instructor {get;set;}
        
        public virtual List<AsignacionAlumno> AsignacionAlumnos {get;set;}

        
        //public virtual CarreraTecnica CarreraTecnica {get;set;}

    }
}