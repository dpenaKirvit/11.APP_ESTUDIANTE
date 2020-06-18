using System;
using System.Collections.Generic;

namespace Datos.Models
{
    public partial class Grado
    {
        public Grado()
        {
            Instalacion = new HashSet<Instalacion>();
            Persona = new HashSet<Persona>();
        }

        public int Oid { get; set; }
        public string Código { get; set; }
        public string TipoGrado { get; set; }
        public string Nombre { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? Gcrecord { get; set; }

        public virtual ICollection<Instalacion> Instalacion { get; set; }
        public virtual ICollection<Persona> Persona { get; set; }
    }
}
