using Datos.Models;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class LogConsulta
    {
        KIRVIT_AppContext db;
        Persona _PersonaLogeada;


        public LogConsulta(Persona Usuario)
        {
            _PersonaLogeada = Usuario;
            db = new KIRVIT_AppContext();
        }
        public List<Curso> GetListaCursos()
        {

            var consulta = from p in db.PersonaEstudiantesGrupoGruposEstudiantes
                           where p.Estudiantes.Equals(_PersonaLogeada.Oid)
                           join g in db.Grupo on p.GruposEstudiantes equals g.Oid
                           join c in db.Curso on g.CursoAsociado equals c.Oid
                           select c;

            return consulta.ToList();

        }
        public List<Grupo> GetListaGrupos()
        {

            var consulta = from p in db.PersonaEstudiantesGrupoGruposEstudiantes
                           where p.Estudiantes.Equals(_PersonaLogeada.Oid)
                           join g in db.Grupo on p.GruposEstudiantes equals g.Oid
                           join c in db.Curso on g.CursoAsociado equals c.Oid
                           select g;

            return consulta.ToList();
        }

        public List<MateriasTeóricas> GetListaMateriasTeoricas()
        {
            var consulta = from p in db.PersonaEstudiantesGrupoGruposEstudiantes
                           where p.Estudiantes.Equals(_PersonaLogeada.Oid)
                           join g in db.Grupo on p.GruposEstudiantes equals g.Oid
                           join c in db.Curso on g.CursoAsociado equals c.Oid
                           join m in db.MateriasTeóricasMateriasTeóricasCursoCursos on c.Oid equals m.Cursos
                           join t in db.MateriasTeóricas on m.MateriasTeóricas equals t.Oid
                           select t;

            return consulta.ToList();
        }
        public List<MateriasPrácticas> GetListaMateriasPracticas()
        {
            var consulta = from p in db.PersonaEstudiantesGrupoGruposEstudiantes
                           where p.Estudiantes.Equals(_PersonaLogeada.Oid)
                           join g in db.Grupo on p.GruposEstudiantes equals g.Oid
                           join c in db.Curso on g.CursoAsociado equals c.Oid
                           join m in db.MateriasPrácticasMateriasPrácticasCursoCursos on c.Oid equals m.Cursos
                           join t in db.MateriasPrácticas on m.MateriasPrácticas equals t.Oid
                           select t;
            return consulta.ToList();
        }

        public List<MaterialApoyo> GetMaterialApoyo()
        {
            var consulta = from p in db.PersonaEstudiantesGrupoGruposEstudiantes
                           where p.Estudiantes.Equals(_PersonaLogeada.Oid)
                           join g in db.Grupo on p.GruposEstudiantes equals g.Oid
                           join c in db.Curso on g.CursoAsociado equals c.Oid
                           join m in db.MateriasTeóricasMateriasTeóricasCursoCursos on c.Oid equals m.Cursos
                           join t in db.MateriasTeóricas on m.MateriasTeóricas equals t.Oid
                           join a in db.MateriasTeóricasMateriasTeóricasMaterialApoyoMaterialApoyos on t.Oid equals a.MateriasTeóricas
                           join ma in db.MaterialApoyo on a.MaterialApoyos equals ma.Oid
                           select ma;
            return consulta.ToList();

        }
        public List<FileData> GetArchivos() {


            var consulta = from p in db.PersonaEstudiantesGrupoGruposEstudiantes
                           where p.Estudiantes.Equals(_PersonaLogeada.Oid)
                           join g in db.Grupo on p.GruposEstudiantes equals g.Oid
                           join c in db.Curso on g.CursoAsociado equals c.Oid
                           join m in db.MateriasTeóricasMateriasTeóricasCursoCursos on c.Oid equals m.Cursos
                           join t in db.MateriasTeóricas on m.MateriasTeóricas equals t.Oid
                           join a in db.MateriasTeóricasMateriasTeóricasMaterialApoyoMaterialApoyos on t.Oid equals a.MateriasTeóricas
                           join ma in db.MaterialApoyo on a.MaterialApoyos equals ma.Oid
                           join fd in db.FileData on ma.Archivo equals fd.Oid
                           select fd;
            return consulta.ToList();

        }
        public List<Persona> DatosUsuario()
        {
            var consulta = from p in db.Persona
                           where p.Oid.Equals(_PersonaLogeada.Oid)
                           select p;
            return consulta.ToList();


        }

      

        public List<Instalacion> GetInstalacion() {

            var consulta = from i in db.Instalacion
                           select i;
            return consulta.ToList();       
        
        }

      
    }
}
