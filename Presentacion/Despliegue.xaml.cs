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
using System.Windows.Shapes;
using Datos.Models;
using Logica;

namespace Presentacion
{
    /// <summary>
    /// Interaction logic for Despliegue.xaml
    /// </summary>
    public partial class Despliegue : Window
    {
        public Despliegue(Persona UsuarioLogeado, string MateriaActual)
        {
            InitializeComponent();
            Height = Double.Parse(Presentacion.Properties.Settings.Default.Despliegue_Height);
            Width = Double.Parse(Presentacion.Properties.Settings.Default.Despliegue_Width);
            ((LogViewModelNav)DataContext).UsuarioLogeado = UsuarioLogeado;
            ((LogViewModelNav)DataContext).MateriaActual = MateriaActual;
        }

    
   
        private void Btn_VideosClic(object sender, RoutedEventArgs e)
        {
            ((LogViewModelNav)DataContext).TipoMaterialActual = 7;
            NombreArchivos.Text = "Videos";
            Browser.Visibility = Visibility.Collapsed;
            Videos.Visibility = Visibility.Visible;
          

        }

        private void Btn_ImagenesClic(object sender, RoutedEventArgs e)
        {
            ((LogViewModelNav)DataContext).TipoMaterialActual = 2;
            NombreArchivos.Text = "Imagenes";
            Browser.Visibility = Visibility.Collapsed;
            Videos.Visibility = Visibility.Visible;

        }

        private void Button_ManualesClick(object sender, RoutedEventArgs e)
        {
            ((LogViewModelNav)DataContext).TipoMaterialActual = 3;
            NombreArchivos.Text = "Manuales";
            Browser.Visibility = Visibility.Visible;
            Videos.Visibility = Visibility.Collapsed;

        }

        private void Button_TablasClick(object sender, RoutedEventArgs e)
        {
            ((LogViewModelNav)DataContext).TipoMaterialActual = 4;
            NombreArchivos.Text = "Tablas";
            Browser.Visibility = Visibility.Visible;
            Videos.Visibility = Visibility.Collapsed;


        }

        private void Btn_PresentacionesClic(object sender, RoutedEventArgs e)
        {
            ((LogViewModelNav)DataContext).TipoMaterialActual = 6;
            NombreArchivos.Text = "Presentaciones";
            Browser.Visibility = Visibility.Visible;
            Videos.Visibility = Visibility.Collapsed;

        }

        private void Button_AnimacionesClick(object sender, RoutedEventArgs e)
        {
            ((LogViewModelNav)DataContext).TipoMaterialActual = 1;
            NombreArchivos.Text = "Animaciones";
            Browser.Visibility = Visibility.Collapsed;
            Videos.Visibility = Visibility.Visible;


        }

        private void ListBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = ItemsControl.ContainerFromElement(sender as ListBox, e.OriginalSource as DependencyObject) as ListBoxItem;
            if (item != null)
            {
                ((LogViewModelNav)DataContext).MaterialSeleccionado = item.Content.ToString();
                MessageBox.Show(((LogViewModelNav)DataContext).MaterialSeleccionado = item.Content.ToString());
               


            }
        }
    }
}
