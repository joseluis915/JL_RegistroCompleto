﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Tarea2_RegistroCompleto.BLL;
using Tarea2_RegistroCompleto.Entidades;

namespace Tarea2_RegistroCompleto.UI.Registro
{
    public partial class rDatosPersonales : Window
    {
        private DatosPersonales DatosPersonales = new DatosPersonales();

        public rDatosPersonales()
        {
            InitializeComponent();
            // Asignar la instancia del al formulario para usarla en BINDINGS
            this.DataContext = DatosPersonales;
        }
        //——————————————————————————————————————————————[ LIMPIAR ]——————————————————————————————————————————————
        private void Limpiar()
        {
            this.DatosPersonales = new DatosPersonales();
            this.DataContext = DatosPersonales;
        }
        //——————————————————————————————————————————————[ VALIDAR ]——————————————————————————————————————————————
        private bool Validar()
        {
            bool esValido = true;

            if (NombreCompletoTextbox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return esValido;
        }
        //——————————————————————————————————————————————[ BUSCAR ]——————————————————————————————————————————————
        private void Button_Click_Buscar(object sender, RoutedEventArgs e)
        {
            var personales = DatosPersonalesBLL.Buscar(Utilidades.ToInt(IdPersonaTextbox.Text));

            if (DatosPersonales != null)
                this.DatosPersonales = personales;
            else
                this.DatosPersonales = new DatosPersonales();

            this.DataContext = this.DatosPersonales;
        }
        //——————————————————————————————————————————————[ NUEVO ]——————————————————————————————————————————————
        private void Button_Click_Nuevo(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        //——————————————————————————————————————————————[ GUARDAR ]——————————————————————————————————————————————
        private void Button_Click_Guardar(object sender, RoutedEventArgs e)
        {
            {
                if (!Validar())
                    return;

                var paso = DatosPersonalesBLL.Guardar(DatosPersonales);

                if (paso)
                {
                    Limpiar();
                    MessageBox.Show("Transaccion Exitosa!", "Exito",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("Transaccion Fallida", "Fallo",
                        MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //——————————————————————————————————————————————[ ELIMINAR ]——————————————————————————————————————————————
        private void Button_Click_Eliminar(object sender, RoutedEventArgs e)
        {
            {
                if (DatosPersonalesBLL.Eliminar(Utilidades.ToInt(IdPersonaTextbox.Text)))
                {
                    Limpiar();
                    MessageBox.Show("Registro Eliminado!", "Exito",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("No fue posible eliminar", "Fallo",
                        MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //—————————————————————————————————————————————————————————————————————————————————————————————————————————
    }
}
