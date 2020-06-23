using Datos.Models;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Presentacion.Interfaz
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        private LogIngreso LogIngreso;
        private Persona _usuario;

        public Login()
        {
            InitializeComponent();
        }

       
        private void B_Ingresar_Click(object sender, RoutedEventArgs e)
        {
            LogIngreso = new LogIngreso();
        
            if (LogIngreso.ValidarUsuario(TB_Usuario.Text, TB_Password.Password) == null)
            {
                MessageBox.Show("Usuario y/o contraseña incorrecta");
            }
            else
            {
                _usuario = LogIngreso.ValidarUsuario(TB_Usuario.Text, TB_Password.Password);
                this.NavigationService.Navigate(new PNavegacion(_usuario));
                MessageBox.Show("Correcto");

            }
        }
    }
}
