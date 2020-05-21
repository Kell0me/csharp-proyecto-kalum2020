using System.Collections.Generic;

namespace Kalum2020v1.Models
{
    public class Religion
    {
        public int ReligionId{get;set;}
        public string Descripcion{get;set;}
        public virtual List<Alumno> Alumnos {get;set;}

        
    }
}