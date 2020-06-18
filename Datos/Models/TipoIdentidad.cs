using System;
using System.Collections.Generic;

namespace Datos.Models
{
    public partial class TipoIdentidad
    {
        public TipoIdentidad()
        {
            Instalacion = new HashSet<Instalacion>();
            Persona = new HashSet<Persona>();
        }

        public int Oid { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? Gcrecord { get; set; }

        public virtual ICollection<Instalacion> Instalacion { get; set; }
        public virtual ICollection<Persona> Persona { get; set; }
    }
}
