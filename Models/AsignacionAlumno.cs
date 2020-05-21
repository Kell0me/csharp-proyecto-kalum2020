using System;

namespace Kalum2020v1.Models
{
    public class AsignacionAlumno
    {
        public int AsignacionAlumnoId {get;set;}

        public int ClaseId {get;set;}

        public int AsAlumnoID {get;set;}

        public DateTime FechaAsignacion{get;set;}

        public string Observaciones{get;set;}

         public int AlumnoID {get;set;}

         public virtual Alumno Alumno {get;set;}

         public virtual Clase Clase {get;set;}

         //public virtual CarretaTecnica CarretaTecnica {get;set;}






        
    }
}