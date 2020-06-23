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
using Datos.Models;
using Logica;

namespace Presentacion.Interfaz
{
    /// <summary>
    /// Interaction logic for PNavegacion.xaml
    /// </summary>
    public partial class PNavegacion : Page
    {
        private Persona _usuarioLogeado;
        private string _materiaActual;
       public PNavegacion(Persona UsuarioLogeado)
        {
          InitializeComponent();
            _usuarioLogeado = UsuarioLogeado;
          ((LogViewModelNav)DataContext).UsuarioLogeado = UsuarioLogeado;
        }

      
        private void ListBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = ItemsControl.ContainerFromElement(sender as ListBox, e.OriginalSource as DependencyObject) as ListBoxItem;
            if (item != null)
            {
                grid_Materia.Visibility = Visibility.Visible;
                ((LogViewModelNav)DataContext).MateriaActual = item.Content.ToString();
                _materiaActual = item.Content.ToString();
            }
        }

        private void bX_clic_Salir(object sender, RoutedEventArgs e)
        {
            grid_Materia.Visibility = Visibility.Collapsed;
        }

        private void btnPantalla_NavegacionClick(object sender, RoutedEventArgs e)
        {
            Despliegue ventanaDespliegue = new Despliegue(_usuarioLogeado,_materiaActual);
            ventanaDespliegue.Show();
        }

        private void btn_EvaluacionClick(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Aún no puede presentar la evaluación");
        }

        private void SalirClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Adios");
            Application.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            Application.Current.Shutdown();


        }
    }
}
