using System;
using System.Collections.Generic;

namespace Datos.Models
{
    public partial class PersonaEstudiantesGrupoGruposEstudiantes
    {
        public int? GruposEstudiantes { get; set; }
        public Guid? Estudiantes { get; set; }
        public int Oid { get; set; }
        public int? OptimisticLockField { get; set; }

        public virtual Persona EstudiantesNavigation { get; set; }
        public virtual Grupo GruposEstudiantesNavigation { get; set; }
    }
}
