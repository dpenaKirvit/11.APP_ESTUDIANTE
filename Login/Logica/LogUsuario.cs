using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Models;

namespace Login.Logica
{
    public class LogUsuario
    {
        KIRVIT_AppContext db;
        public LogUsuario()
        {
            db = new KIRVIT_AppContext();
        }

        public Persona LVerificarUsuario(string txtUser, string txtPassword)
        {

            PermissionPolicyUser Usuario = db.PermissionPolicyUser.First();

            if (Usuario != null)
            {
                Persona UsuarioRegistrado = db.Persona.FirstOrDefault(x => x.Oid.Equals(Usuario.Oid));
                string password = Usuario.StoredPassword;
                if (password == txtPassword)
                {
                    return UsuarioRegistrado;
                }
                else
                {
                    Console.WriteLine("Contraseña incorrecta " + DateTime.Now.ToString());
                    return null;
                  
                }
            }
            else
            {
                Console.WriteLine("Usuario incorrecto " + DateTime.Now.ToString());
                return null;
            }
        }

    }
}
