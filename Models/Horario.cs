using System;
using System.Collections.Generic;

namespace Kalum2020v1.Models
{
    public class Horario
    {
        public int HorarioId {get;set;}
        public DateTime HorarioInicio{get;set;}
        public DateTime HorarioFinal{get;set;}

        public virtual List<Horario> Horarios {get;set;}
        
    }
}