using System;
using System.Collections.Generic;

namespace Kalum2020v1.Models
{
    public class CarreraTecnica
    {
        public int CarreraTecnicaId {get;set;}
        public string NombreCarrera{get;set;}
        public virtual List<Clase> Clases {get;set;}
        //public virtual Religion Religion {get;set;}
        //public virtual List<AsignacionAlumno> AsignacionAlumnos {get;set;}
        

        

    }
}