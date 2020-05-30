﻿using System;
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
using Tarea2_RegistroCompleto.UI.Registro;

namespace Tarea2_RegistroCompleto
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Persona(object sender, RoutedEventArgs e)
        {
            rDatosPersonales rDatosPersonales = new rDatosPersonales();
            rDatosPersonales.Show();
        }
        private void Button_Click_Prestamo(object sender, RoutedEventArgs e)
        {
            rPrestamos rPrestamos = new rPrestamos();
            rPrestamos.Show();
        }

        private void Button_Click_Salir(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
