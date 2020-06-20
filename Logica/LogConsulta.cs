using Datos.Models;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class LogConsulta
    {
        KIRVIT_AppContext db;
        

        public LogConsulta()
        {
            db = new KIRVIT_AppContext();
        }

        public List<Curso> GetListaCursos(Persona PersonaLogeada)
        {
            
            var consulta = from p in db.PersonaEstudiantesGrupoGruposEstudiantes
                           where p.Estudiantes.Equals(PersonaLogeada.Oid)
                           join g in db.Grupo on p.GruposEstudiantes equals g.Oid
                           join c in db.Curso on g.CursoAsociado equals c.Oid
                           select c;

            return consulta.ToList();          
            
          }

       
        public List<Grupo> GetListaGrupos(Persona PersonaLogeada) {


            var consulta = from p in db.PersonaEstudiantesGrupoGruposEstudiantes
                           where p.Estudiantes.Equals(PersonaLogeada.Oid)
                           join g in db.Grupo on p.GruposEstudiantes equals g.Oid
                           join c in db.Curso on g.CursoAsociado equals c.Oid
                           select g;

            return consulta.ToList();
        }

        public List<MateriasTeóricas> GetListaMateriasTeoricas(Persona PersonaLogeada) {
            var consulta = from p in db.PersonaEstudiantesGrupoGruposEstudiantes
                           where p.Estudiantes.Equals(PersonaLogeada.Oid)
                           join g in db.Grupo on p.GruposEstudiantes equals g.Oid
                           join c in db.Curso on g.CursoAsociado equals c.Oid
                           join m in db.MateriasTeóricasMateriasTeóricasCursoCursos on c.Oid equals m.Cursos
                           join t in db.MateriasTeóricas on m.MateriasTeóricas equals t.Oid
                           select t;

            return consulta.ToList();
        }
        public List<MateriasPrácticas> GetListaMateriasPracticas(Persona PersonaLogeada) {
            var consulta = from p in db.PersonaEstudiantesGrupoGruposEstudiantes
                           where p.Estudiantes.Equals(PersonaLogeada.Oid)
                           join g in db.Grupo on p.GruposEstudiantes equals g.Oid
                           join c in db.Curso on g.CursoAsociado equals c.Oid
                           join m in db.MateriasPrácticasMateriasPrácticasCursoCursos on c.Oid equals m.Cursos
                           join t in db.MateriasPrácticas on m.MateriasPrácticas equals t.Oid
                           select t;
            return consulta.ToList();
        }

        public List<MaterialApoyo> GetMaterialApoyo(Persona PersonaLogeada) {
            var consulta = from p in db.PersonaEstudiantesGrupoGruposEstudiantes
                           where p.Estudiantes.Equals(PersonaLogeada.Oid)
                           join g in db.Grupo on p.GruposEstudiantes equals g.Oid
                           join c in db.Curso on g.CursoAsociado equals c.Oid
                           join m in db.MateriasTeóricasMateriasTeóricasCursoCursos on c.Oid equals m.Cursos
                           join t in db.MateriasTeóricas on m.MateriasTeóricas equals t.Oid
                           join a in db.MateriasTeóricasMateriasTeóricasMaterialApoyoMaterialApoyos on t.Oid equals a.MaterialApoyos
                           join ma in db.MaterialApoyo on a.MaterialApoyos equals ma.Oid
                           select ma;
            return consulta.ToList();

        }
    }
}
