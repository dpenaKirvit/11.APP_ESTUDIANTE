using Datos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Logica
{
    class ConsultaMateriaPractica
    {
        private string identificacion;
        public List<string> MateriaPractica
        {
            get
            {
                return cs(identificacion);
            }
        }
        public ConsultaMateriaPractica()
        {
            identificacion = GetID();
        }
        private string GetID()
        {
            string identificacion = "1022695874";
            return identificacion;
        }
        private List<string> cs(string data)
        {
            KIRVIT_AppContext db = new KIRVIT_AppContext();

            var Filtro1 = db.Persona.FirstOrDefault(o => o.NúmeroIdentidad.Equals(data));
            var OID = Filtro1.Oid;

            var Filtro2 = db.PersonaEstudiantesGrupoGruposEstudiantes.FirstOrDefault(o => o.Estudiantes.Equals(OID));
            var Grupos = Filtro2.GruposEstudiantes;

            var ListaMateriasPracticas = new List<String>();

            var grupos = from q in db.Grupo
                         join r in db.Curso
                         on q.CursoAsociado equals r.Oid
                         join s in db.MateriasPrácticasMateriasPrácticasCursoCursos
                         on r.Oid equals s.Cursos
                         join t in db.MateriasPrácticas
                         on s.MateriasPrácticas equals t.Oid
                         where q.Oid == Grupos
                         select new
                         {
                             q,
                             r,
                             s,
                             t
                         };
            foreach (var item in grupos)
            {
                var materiapractica = item.t.Título;
                ListaMateriasPracticas.Add(materiapractica.ToString());

            }
            return ListaMateriasPracticas;
        }
    }
}
