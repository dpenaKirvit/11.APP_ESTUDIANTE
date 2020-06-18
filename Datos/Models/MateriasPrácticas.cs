using System;
using System.Collections.Generic;

namespace Datos.Models
{
    public partial class MateriasPrácticas
    {
        public MateriasPrácticas()
        {
            CheckList = new HashSet<CheckList>();
            EvaluacionPractica = new HashSet<EvaluacionPractica>();
            HistorialAcademico = new HashSet<HistorialAcademico>();
            MateriasPrácticasMateriasPrácticasCursoCursos = new HashSet<MateriasPrácticasMateriasPrácticasCursoCursos>();
            MateriasPrácticasMateriasPrácticasMaterialApoyoMaterialApoyos = new HashSet<MateriasPrácticasMateriasPrácticasMaterialApoyoMaterialApoyos>();
            ParametroInicial = new HashSet<ParametroInicial>();
            SesionPractica = new HashSet<SesionPractica>();
        }

        public int Oid { get; set; }
        public string Título { get; set; }
        public string Descripción { get; set; }
        public int? AreaAcademica { get; set; }
        public double? IntensidadHoraria { get; set; }
        public Guid? Contenido { get; set; }
        public string Url { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? Gcrecord { get; set; }

        public virtual AreasAcademicas AreaAcademicaNavigation { get; set; }
        public virtual FileData ContenidoNavigation { get; set; }
        public virtual ICollection<CheckList> CheckList { get; set; }
        public virtual ICollection<EvaluacionPractica> EvaluacionPractica { get; set; }
        public virtual ICollection<HistorialAcademico> HistorialAcademico { get; set; }
        public virtual ICollection<MateriasPrácticasMateriasPrácticasCursoCursos> MateriasPrácticasMateriasPrácticasCursoCursos { get; set; }
        public virtual ICollection<MateriasPrácticasMateriasPrácticasMaterialApoyoMaterialApoyos> MateriasPrácticasMateriasPrácticasMaterialApoyoMaterialApoyos { get; set; }
        public virtual ICollection<ParametroInicial> ParametroInicial { get; set; }
        public virtual ICollection<SesionPractica> SesionPractica { get; set; }
    }
}
