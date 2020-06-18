using Datos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Logica
{
    class ConsultaMateriaTeorica
    {
        private string identificacion;
        public List<string> MateriaTeorica
        {
            get
            {
                return cs(identificacion);
            }
        }
        public ConsultaMateriaTeorica()
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

            var ListaMateriasTeoricas = new List<String>();

            var grupos = from q in db.Grupo
                         join r in db.Curso
                         on q.CursoAsociado equals r.Oid
                         join s in db.MateriasTeóricasMateriasTeóricasCursoCursos
                         on r.Oid equals s.Cursos
                         join t in db.MateriasTeóricas
                         on s.MateriasTeóricas equals t.Oid
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
                var materiateorica = item.t.Título;
                ListaMateriasTeoricas.Add(materiateorica.ToString());

            }
            return ListaMateriasTeoricas;
        }
    }
}
