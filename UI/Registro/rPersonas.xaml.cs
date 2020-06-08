using System;
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
    public partial class rPersonas : Window
    {
        private Personas Personas = new Personas();

        public rPersonas()
        {
            InitializeComponent();
            // Asignar la instancia del al formulario para usarla en BINDINGS
            this.DataContext = Personas;
        }
        //——————————————————————————————————————————————[ LIMPIAR ]——————————————————————————————————————————————
        private void Limpiar()
        {
            this.Personas = new Personas();
            this.DataContext = Personas;
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
            var personales = PersonasBLL.Buscar(Utilidades.ToInt(IdPersonaTextbox.Text));

            if (Personas != null)
                this.Personas = personales;
            else
                this.Personas = new Personas();

            this.DataContext = this.Personas;
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

                var paso = PersonasBLL.Guardar(Personas);

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
                if (PersonasBLL.Eliminar(Utilidades.ToInt(IdPersonaTextbox.Text)))
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
