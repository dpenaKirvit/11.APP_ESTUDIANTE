using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Logica
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #region
        private List<string> verGrupos;
        public List<string> VerGrupos
        {
            get
            {
                return verGrupos;
            }
            set
            {
                verGrupos = value;
                OnPropertyChanged();
            }
        }
        private List<string> verCursos;
        public List<string> VerCursos
        {
            get
            {
                return verCursos;
            }
            set
            {
                verCursos = value;
                OnPropertyChanged();
            }
        }
        private List<string> verMateriasTeoricas;
        public List<string> VerMateriasTeoricas
        {
            get
            {
                return verMateriasTeoricas;
            }
            set
            {
                verMateriasTeoricas = value;
                OnPropertyChanged();
            }
        }
        private List<string> verMateriasPracticas;
        public List<string> VerMateriasPracticas
        {
            get
            {
                return verMateriasPracticas;
            }
            set
            {
                verMateriasPracticas = value;
                OnPropertyChanged();
            }
        }
        private List<string> verInfoUsuario;
        public List<string> VerInfoUsuario
        {
            get
            {
                return verInfoUsuario;
            }
            set
            {
                verInfoUsuario = value;
                OnPropertyChanged();
            }
        }
        #endregion



        #region
        private List<string> verGruposI;
        public List<string> VerGruposI
        {
            get
            {
                return verGruposI;
            }
            set
            {
                verGruposI = value;
                OnPropertyChanged();
            }
        }
        private List<string> verCursosI;
        public List<string> VerCursosI
        {
            get
            {
                return verCursosI;
            }
            set
            {
                verCursosI = value;
                OnPropertyChanged();
            }
        }
        private List<string> verMateriasPracticasI;
        public List<string> VerMateriasPracticasI
        {
            get
            {
                return verMateriasPracticasI;
            }
            set
            {
                verMateriasPracticasI = value;
                OnPropertyChanged();
            }
        }
        private List<string> verInfoUsuarioI;
        public List<string> VerInfoUsuarioI
        {
            get
            {
                return verInfoUsuarioI;
            }
            set
            {
                verInfoUsuarioI = value;
                OnPropertyChanged();
            }
        }
        #endregion
        public ViewModel()
        {
            Consulta consulta = new Consulta();
            verGrupos = consulta.Grupo;
            ConsultaCurso consultaCurso = new ConsultaCurso();
            verCursos = consultaCurso.Curso;
            ConsultaMateriaTeorica consultaMateriaTeorica = new ConsultaMateriaTeorica();
            verMateriasTeoricas = consultaMateriaTeorica.MateriaTeorica;
            ConsultaMateriaPractica consultaMateriaPractica = new ConsultaMateriaPractica();
            verMateriasPracticas = consultaMateriaPractica.MateriaPractica;
            InfoUsuario infoUsuario = new InfoUsuario();
            verInfoUsuario = infoUsuario.Info;
            
            ConsultaI consultaI = new ConsultaI();
            verGruposI = consultaI.Grupo;
            ConsultaCursoI consultaCursoI = new ConsultaCursoI();
            verCursosI = consultaCursoI.Curso;
            ConsultaMateriaPracticaI consultaMateriaPracticaI = new ConsultaMateriaPracticaI();
            verMateriasPracticasI = consultaMateriaPracticaI.MateriaPractica;
            InfoUsuarioI infoUsuarioI = new InfoUsuarioI();
            verInfoUsuarioI = infoUsuarioI.Info;
        }
    }
}
