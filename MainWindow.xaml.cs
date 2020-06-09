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
using JL_RegistroCompleto.UI.Registro;

namespace JL_RegistroCompleto
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void rPersonaButton_Click(object sender, RoutedEventArgs e)
        {
            rPersonas rDatosPersonales = new rPersonas();
            rDatosPersonales.Show();
        }
        private void rPrestamoButton_Click(object sender, RoutedEventArgs e)
        {
            rPrestamos rPrestamos = new rPrestamos();
            rPrestamos.Show();
        }
        private void rUsuarioButton_Click(object sender, RoutedEventArgs e)
        {
            rUsuarios rUsuarios = new rUsuarios();
            rUsuarios.Show();
        }
        private void SalirButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
