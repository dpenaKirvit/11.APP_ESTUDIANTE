using System;
using System.Collections.Generic;

namespace Datos.Models
{
    public partial class EvaluacionPractica
    {
        public int Oid { get; set; }
        public int? SesiónPráctica { get; set; }
        public double? Calificación { get; set; }
        public string NoReporte { get; set; }
        public int? ChecklistEvaluado { get; set; }
        public string Observaciones { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? Gcrecord { get; set; }
        public Guid? PersonaEvaluado { get; set; }
        public int? MateriaPracticaEvaluado { get; set; }

        public virtual CheckList ChecklistEvaluadoNavigation { get; set; }
        public virtual MateriasPrácticas MateriaPracticaEvaluadoNavigation { get; set; }
        public virtual Persona PersonaEvaluadoNavigation { get; set; }
        public virtual SesionPractica SesiónPrácticaNavigation { get; set; }
    }
}
