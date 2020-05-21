using System.Collections.Generic;

namespace Kalum2020v1.Models
{
    public class Instructor
    {
        public int InstructorId {get;set;}
        public string Apellidos{get;set;}
        public string Nombres {get;set;}
        public string Direccion {get;set;}
        public string Telefono{get;set;}
        public string Comentario{get;set;}
        public string Estatus {get;set;}
        public string Foto {get;set;}

        public virtual List<Instructor> Instructores  {get;set;}
    }
}