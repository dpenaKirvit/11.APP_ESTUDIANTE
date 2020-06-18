using Datos.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Presentacion.Logica
{
    public class Consulta
    {
        private string identificacion;
        public List<string> Grupo
        {
            get
            {
                return cs(identificacion);
            }
        }
        public Consulta()
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

            var ListaGrupos = new List<String>();
            
            var grupos = from q in db.Grupo
                         join r in db.Curso
                         on q.CursoAsociado equals r.Oid
                         where q.Oid == Grupos
                         select new
                         {
                             q,
                             r
                         };
            foreach (var item in grupos)
            {
                var grupo = item.q.Título;
                ListaGrupos.Add(grupo.ToString());

            }
            return ListaGrupos;
        }
    }
}
