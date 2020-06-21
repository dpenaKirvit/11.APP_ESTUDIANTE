using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Datos.Models;
using Microsoft.EntityFrameworkCore.Internal;
using static System.Net.Mime.MediaTypeNames;

namespace Logica
{
    public class LogViewModelIngreso
    {
        private string _NombreSoftware;
        private string _NombreAbreviado;
        private byte[] _Logo;
        private KIRVIT_AppContext db;


        public string NombreSoftware
        {
            get { return _NombreSoftware; }
            set { _NombreSoftware = value; }

        }

        public string NombreAbreviado
        {
            get { return _NombreAbreviado; }
            set { _NombreAbreviado = value; }

        }

        public byte[] Logo
        {
            get { return _Logo; }
            set { _Logo = value; }

        }

      

        private List<Instalacion> ConsultaInicial() {

            var ConsultaTabla = from ins in db.Instalacion
                                select ins;
            return ConsultaTabla.ToList();
        
        }
        public LogViewModelIngreso()
        {
            db = new KIRVIT_AppContext();
            NombreSoftware = ConsultaInicial().Select(x => x.NombreAbreviado).First().ToString();
            NombreAbreviado = ConsultaInicial().Select(x => x.Nombre).First().ToString();
            Logo = ConsultaInicial().Select(x => x.Imagen).First();      

        }

    }
}
