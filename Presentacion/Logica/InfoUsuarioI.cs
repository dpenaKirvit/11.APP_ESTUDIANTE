using Datos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Logica
{
    class InfoUsuarioI
    {
        private string identificacion;
        public List<string> Info
        {
            get
            {
                return cs(identificacion);
            }
        }
        public InfoUsuarioI()
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
            var nombres = Filtro1.Nombres;
            var apellidos = Filtro1.Apellidos;
            var id = Filtro1.NúmeroIdentidad;

            var ListaInfo = new List<String>();

            ListaInfo.Add(nombres.ToString());
            ListaInfo.Add(apellidos.ToString());
            ListaInfo.Add(id.ToString());

            return ListaInfo;
        }
    }
}
