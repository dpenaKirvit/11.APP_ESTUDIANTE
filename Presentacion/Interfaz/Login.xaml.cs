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
        private LogViewModelIngreso logViewModelIngreso;
        private Persona Usuario;
        private LogConsulta LogConsulta;
        public Login()
        {
            logViewModelIngreso = new LogViewModelIngreso();
            InitializeComponent();
        }
        private void B_Ingresar_Click(object sender, RoutedEventArgs e)
        {
            LogIngreso = new LogIngreso();
            Usuario = LogIngreso.ValidarUsuario(TB_Usuario.Text, TB_Password.Password);
            if (Usuario == null)
            {
                MessageBox.Show("Usuario y/o contraseña incorrecta");
            }
            else 
            {
                LogConsulta = new LogConsulta(Usuario);
                this.NavigationService.Navigate(new Uri("/Interfaz/PNavegacion.xaml", UriKind.Relative));
                MessageBox.Show("Correcto");

            }
        }
    }
}
