using Datos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Logica
{
    class ConsultaCursoI
    {
        private string identificacion;
        public List<string> Curso
        {
            get
            {
                return cs(identificacion);
            }
        }
        public ConsultaCursoI()
        {
            identificacion = GetID();
        }
        private string GetID()
        {
            string identificacion = "52789635";
            return identificacion;
        }
        private List<string> cs(string data)
        {
           KIRVIT_AppContext db = new KIRVIT_AppContext();

            var Filtro1 = db.Persona.FirstOrDefault(o => o.NúmeroIdentidad.Equals(data));
            var OID = Filtro1.Oid;

            var Filtro2 = db.PersonaInstructoresGrupoGruposInstructores.FirstOrDefault(o => o.Instructores.Equals(OID));
            var Grupos = Filtro2.GruposInstructores; ;

            var ListaCursos = new List<String>();

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
                var curso = item.r.Título;
                ListaCursos.Add(curso.ToString());

            }
            return ListaCursos;
        }
    }
}
