using Datos.Models;
using Login.Logica;
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

namespace Login.Vistas
{
    /// <summary>
    /// Interaction logic for Ingreso.xaml
    /// </summary>
    public partial class Ingreso : Page
    {
        LogUsuario LogUsuario;
        Persona Persona;
        public Ingreso()
        {
            InitializeComponent();
        }

        private void B_Ingresar_Click(object sender, RoutedEventArgs e)
        {
            LogUsuario = new LogUsuario();
            Persona = LogUsuario.LVerificarUsuario(TB_Usuario.Text,TB_Password.Text);
            if (Persona != null)
            {
                MessageBox.Show("Correcto");
            }
            else
            {
                TB_Password.Text = "";
                TB_Usuario.Text = "";
                MessageBox.Show("Usuario incorrecto");               
            }
        }
    }
}
