﻿using Datos.Models;

using Presentacion.Interfaz;
using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace Presentacion
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class Navegacion : NavigationWindow
    {
        public Navegacion()
        {          
            InitializeComponent();
            Height = Double.Parse(Presentacion.Properties.Settings.Default.Nav_Height);
            Width = Double.Parse(Presentacion.Properties.Settings.Default.Nav_Width);
        }

               
    }
}
