using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media.Media3D;
using Datos.Models;

namespace Logica
{
    public class LogViewModelNav : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            if (name == "UsuarioLogeado")
            {
                LlenarListas();
            }
            if (name == "MateriaActual")
            {
                LlenarInfoMaterias();

            }
            if (name == "TipoMaterialActual")
            {
                ActualizarMaterialApoyo();

            }
            if (name == "MaterialSeleccionado")
            {

                ActualizarURL();
            }
        }

        private List<string> _ListaCursos;
        private List<string> _ListaGrupos;
        private List<string> _ListaMateriasTeoricas;
        private List<string> _ListaMateriasPracticas;
        private List<string> _ListaMaterialApoyo;
        private string _NombreUsuario;
        private string _UserName;
        private string _NombreSoftware;
        private string _NombreAbreviado;
        private string _IdentificacionUsuario;
        private LogConsulta _logConsulta;
        private Persona _usuarioLogeado;
        private byte[] _logo;
        private byte[] _foto;
        private byte[] _byteimagen;
        private string _MateriaActual;
        private string _DescripcionMateria;
        private int _TipoMaterialActual;
        private string _MaterialSeleccionado;
        private string _URL;




        public Persona UsuarioLogeado
        {
            get { return _usuarioLogeado; }
            set
            {
                _usuarioLogeado = value;
                OnPropertyChanged();
            }


        }

        public string MaterialSeleccionado
        {
            get { return _MaterialSeleccionado; }
            set
            {
                _MaterialSeleccionado = value;
                OnPropertyChanged();
            }

        }
        public string URL
        {
            get { return _URL; }
            set
            {
                _URL = value;
                OnPropertyChanged();
            }

        }

        public string DescripcionMateria
        {
            get { return _DescripcionMateria; }
            set
            {
                _DescripcionMateria = value;
                OnPropertyChanged();
            }

        }

        public int TipoMaterialActual
        {
            get { return _TipoMaterialActual; }
            set
            {
                _TipoMaterialActual = value;
                OnPropertyChanged();
            }

        }
        public string NombreSoftware
        {
            get { return _NombreSoftware; }
            set
            {
                _NombreSoftware = value;
                OnPropertyChanged();
            }

        }
        public string MateriaActual
        {
            get { return _MateriaActual; }
            set
            {
                _MateriaActual = value;
                OnPropertyChanged();
            }

        }



        public string NombreAbreviado
        {
            get { return _NombreAbreviado; }
            set
            {
                _NombreAbreviado = value;
                OnPropertyChanged();
            }

        }

        public List<string> ListaCursos
        {
            get { return _ListaCursos; }
            set
            {
                _ListaCursos = value;
                OnPropertyChanged();
            }
        }

        public List<string> ListaMaterialApoyo
        {
            get { return _ListaMaterialApoyo; }
            set
            {
                _ListaMaterialApoyo = value;
                OnPropertyChanged();
            }
        }

        public byte[] Logo
        {
            get { return _logo; }
            set
            {
                _logo = value;
                OnPropertyChanged();
            }

        }
        public byte[] Foto
        {
            get { return _foto; }
            set
            {
                _foto = value;
                OnPropertyChanged();
            }

        }

        public byte[] byetImagen
        {
            get { return _byteimagen; }
            set
            {
                _byteimagen = value;
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

        public string NombreUsuario
        {
            get { return _NombreUsuario; }
            set
            {
                _NombreUsuario = value;
                OnPropertyChanged();
            }

        }

        public string IdentificacionUsuario
        {
            get { return _IdentificacionUsuario; }
            set
            {
                _IdentificacionUsuario = value;
                OnPropertyChanged();
            }

        }
        public string UserName { get => _UserName; set => _UserName = value; }

        private void LlenarListas()
        {
            _logConsulta = new LogConsulta(_usuarioLogeado);
            NombreSoftware = _logConsulta.GetInstalacion().Select(x => x.NombreAbreviado).First();
            Logo = _logConsulta.GetInstalacion().Select(x => x.Imagen).First();
            ListaCursos = _logConsulta.GetListaCursos().Select(x => x.Título).ToList();
            ListaGrupos = _logConsulta.GetListaGrupos().Select(x => x.Título).ToList();
            ListaMateriasTeoricas = _logConsulta.GetListaMateriasTeoricas().Select(x => x.Título).ToList();
            ListaMateriasPracticas = _logConsulta.GetListaMateriasPracticas().Select(x => x.Título).ToList();
            NombreUsuario = _logConsulta.DatosUsuario().Select(x => x.Nombres.ToString()).First() + " " + _logConsulta.DatosUsuario().Select(x => x.Apellidos.ToString()).First();
            IdentificacionUsuario = _logConsulta.DatosUsuario().Select(x => x.NúmeroIdentidad.ToString()).First();
            Foto = _logConsulta.DatosUsuario().Select(x => x.Foto).First();

        }

        private void LlenarInfoMaterias()
        {

            DescripcionMateria = _logConsulta.GetListaMateriasTeoricas().FirstOrDefault(x => x.Título == MateriaActual).Descripción;
            ListaMaterialApoyo = _logConsulta.GetMaterialApoyo().Select(x => x.Nombre).ToList();


        }

        private void ActualizarMaterialApoyo()
        {
            ListaMaterialApoyo = _logConsulta.GetMaterialApoyo().Where(x => x.TipoMaterial.Equals(TipoMaterialActual)).Select(x => x.Nombre).Distinct().ToList();
               
        }

        private void ActualizarURL()
        {
            var oid = _logConsulta.GetMaterialApoyo().FirstOrDefault(x => x.Nombre == MaterialSeleccionado).Archivo;
            var tipo = _logConsulta.GetMaterialApoyo().FirstOrDefault(x => x.Nombre == MaterialSeleccionado).TipoMaterial;
            byte[] archivo = _logConsulta.GetArchivos().FirstOrDefault(x => x.Oid.Equals(oid)).Content;
            switch (tipo)
            {
                case 1:
                    string animacionFilePath = "E://animacion.mp4";
                    System.IO.File.WriteAllBytes(animacionFilePath, archivo);
                    URL = animacionFilePath;

                    break;
                case 2:
                    string ImagenFilePath = "E://animacion.png";
                    System.IO.File.WriteAllBytes(ImagenFilePath, archivo);
                    URL = ImagenFilePath;
                    break;
                case 3:
                    string pdfFilePath ="E://manual.pdf";
                    System.IO.File.WriteAllBytes(pdfFilePath, archivo);
                    URL = pdfFilePath;
                    break;
                case 4:
                    string pdfFilePathTablas = "E://tablas.pdf";
                    System.IO.File.WriteAllBytes(pdfFilePathTablas, archivo);
                    URL = pdfFilePathTablas;
                    break;
                case 5:
                    //sonidos
                    break;
                case 6:
                    string pdfFilePathPresentaciones = "E://presentaciones.pdf";
                    System.IO.File.WriteAllBytes(pdfFilePathPresentaciones, archivo);
                    URL = pdfFilePathPresentaciones;
                    break;
                case 7:
                    byetImagen = archivo;
                    break;



            }




        }
        public LogViewModelNav()
        {
            URL = "www.google.com";
           
        }





    }
}
