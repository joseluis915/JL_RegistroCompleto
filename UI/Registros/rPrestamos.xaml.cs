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
using JL_RegistroCompleto.BLL;
using JL_RegistroCompleto.Entidades;

namespace JL_RegistroCompleto.UI.Registro
{
    public partial class rPrestamos : Window
    {
        private Prestamos Prestamos = new Prestamos();
        public rPrestamos()
        {
            InitializeComponent();
            // Asignar la instancia del al formulario para usarla en BINDINGS
            this.DataContext = Prestamos;
        }
        //——————————————————————————————————————————————[ LIMPIAR ]——————————————————————————————————————————————
        private void Limpiar()
        {
            this.Prestamos = new Prestamos();
            this.DataContext = Prestamos;
        }
        //——————————————————————————————————————————————[ VALIDAR ]——————————————————————————————————————————————
        private bool Validar()
        {
            bool esValido = true;

            if (IdPrestamoTextbox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return esValido;
        }
        //——————————————————————————————————————————————[ BUSCAR ]——————————————————————————————————————————————
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var prestamos = PrestamosBLL.Buscar(Utilidades.ToInt(IdPrestamoTextbox.Text));

            if (Prestamos != null)
                this.Prestamos = prestamos;
            else
                this.Prestamos = new Prestamos();

            this.DataContext = this.Prestamos;
        }
        //——————————————————————————————————————————————[ NUEVO ]——————————————————————————————————————————————
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        //——————————————————————————————————————————————[ GUARDAR ]——————————————————————————————————————————————
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (!Validar())
                    return;

                var paso = PrestamosBLL.Guardar(Prestamos);

                if (paso)
                {
                    Limpiar();
                    MessageBox.Show("Transaccion Exitosa!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //——————————————————————————————————————————————[ ELIMINAR ]——————————————————————————————————————————————
        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (PrestamosBLL.Eliminar(Utilidades.ToInt(IdPrestamoTextbox.Text)))
                {
                    Limpiar();
                    MessageBox.Show("Registro Eliminado!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("No fue posible eliminar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //—————————————————————————————————————————————————————————————————————————————————————————————————————————
    }
}