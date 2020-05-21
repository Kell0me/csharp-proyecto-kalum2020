using System.Collections.Generic;

namespace Kalum2020v1.Models
{
    public class Salon
    {
        public int SalonId {get;set;}

        public string NombreSalon {get;set;}

        public string Descripcion{get;set;}

        public int Capacidad{get;set;}

        public virtual List<Salon> Salones {get;set;}
    }
}