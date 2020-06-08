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
//No olvidar Agregar los siguientes [using].
using JL_RegistroCompleto.BLL; //Nombre del proyecto.BLL
using JL_RegistroCompleto.Entidades; //Nombre del proyecto.Entidades

namespace JL_RegistroCompleto.UI.Registro
{
    public partial class rUsuarios : Window
    {
        private Usuarios Usuarios = new Usuarios();
        public rUsuarios()
        {
            InitializeComponent();
            // Asignar la instancia del al formulario para usarla en BINDINGS
            this.DataContext = Usuarios;
        }
        //——————————————————————————————————————————————[ LIMPIAR ]——————————————————————————————————————————————
        private void Limpiar()
        {
            this.Usuarios = new Usuarios();
            this.DataContext = Usuarios;
        }
        //——————————————————————————————————————————————[ VALIDAR ]——————————————————————————————————————————————
        private bool Validar()
        {
            bool esValido = true;
                if (UsuarioIdTextbox.Text.Length == 0)
                {
                    esValido = false;
                    MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            return esValido;
        }
        //——————————————————————————————————————————————[ BUSCAR ]——————————————————————————————————————————————
        private void Button_Click_Buscar(object sender, RoutedEventArgs e)
        {
            var usuarios = UsuariosBLL.Buscar(Utilidades.ToInt(UsuarioIdTextbox.Text));
                if (Usuarios != null)
                    this.Usuarios = usuarios;
                else
                    this.Usuarios = new Usuarios();
                this.DataContext = this.Usuarios;
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

                var paso = UsuariosBLL.Guardar(Usuarios);
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
        private void Button_Click_Eliminar(object sender, RoutedEventArgs e)
        {
            {
                if (UsuariosBLL.Eliminar(Utilidades.ToInt(UsuarioIdTextbox.Text)))
                {
                    Limpiar();
                    MessageBox.Show("Registro Eliminado!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("No fue posible eliminar", "Fallo",  MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //—————————————————————————————————————————————————————————————————————————————————————————————————————————
    }
}