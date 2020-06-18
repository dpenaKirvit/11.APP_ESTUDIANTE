using System;
using System.Collections.Generic;

namespace Datos.Models
{
    public partial class MateriasTeóricasMateriasTeóricasMaterialApoyoMaterialApoyos
    {
        public int? MaterialApoyos { get; set; }
        public int? MateriasTeóricas { get; set; }
        public int Oid { get; set; }
        public int? OptimisticLockField { get; set; }

        public virtual MaterialApoyo MaterialApoyosNavigation { get; set; }
        public virtual MateriasTeóricas MateriasTeóricasNavigation { get; set; }
    }
}
