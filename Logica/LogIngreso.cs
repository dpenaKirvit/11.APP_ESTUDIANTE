using Datos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class LogIngreso
    {
        private KIRVIT_AppContext db;
        
        public LogIngreso() 
        {
            db = new KIRVIT_AppContext();        
        }

      
        public Persona ValidarUsuario(string txt_user, string txt_password) {
            PermissionPolicyUser UsuarioDatos = db.PermissionPolicyUser.FirstOrDefault(x => x.UserName.Equals(txt_user));

            if (UsuarioDatos != null)
            {

                if (UsuarioDatos.StoredPassword == null) {
                    if (txt_password == "")
                    {
                        return db.Persona.FirstOrDefault(x => x.Oid.Equals(UsuarioDatos.Oid));

                    }
                    else 
                    {
                        return null;
                    }
                
                }
                else if (UsuarioDatos.StoredPassword.Equals(txt_password))
                {
                    return db.Persona.FirstOrDefault(x => x.Oid.Equals(UsuarioDatos.Oid));
                }
                else
                {
                    return null;
                }

            }
            else {

                return null;
            }
                
        }


    }
}
