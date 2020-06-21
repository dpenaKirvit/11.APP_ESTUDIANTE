using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class LogViewModelNav : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private List<string> _ListaCursos;
        private List<string> _ListaGrupos;
        private List<string> _ListaMateriasTeoricas;
        private List<string> _ListaMateriasPracticas;
        private List<string> _DatosUsuario;

        public List<string> ListaCursos
        {
            get { return _ListaCursos; }
            set
            {
                _ListaCursos = value;
                OnPropertyChanged();
            }
        }

        public List<string> ListaGrupos
        {
            get { return _ListaGrupos; }
            set
            {
                _ListaGrupos = value;
                OnPropertyChanged();
            }
        }
        public List<string> ListaMateriasTeoricas
        {
            get { return _ListaMateriasTeoricas; }
            set
            {
                _ListaMateriasTeoricas = value; 
                    OnPropertyChanged();
            }
        }
        public List<string> ListaMateriasPracticas
        {
            get { return _ListaMateriasPracticas; }
            set
            {
                _ListaMateriasPracticas = value;
                OnPropertyChanged();
            }
        }

        public List<string> DatosUsuario
        {
            get { return _DatosUsuario; }
            set 
            {
                _DatosUsuario = value;
                OnPropertyChanged();           
            }     
        
        }

        public LogViewModelNav()
        {
            
        }





    }
}
