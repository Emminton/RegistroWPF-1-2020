using RegistroWpfApp.BLL;
using RegistroWpfApp.Entidades;
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

namespace RegistroWpfApp.UI.Registros
{
    /// <summary>
    /// Interaction logic for RegistroPersona.xaml
    /// </summary>
    public partial class RegistroPersona : Window
    {
        public RegistroPersona()
        {
            InitializeComponent();
        }
       private void Limpiar()
        {
            PersonaIDTex.Text = string.Empty;
            NombreTex.Text = string.Empty;
            TelefonoTex.Text = string.Empty;
            CedulaTex.Text = string.Empty;
            DireccionTex.Text = string.Empty;
            FechaNacimientoDatePicke.SelectedDate = DateTime.Now;
            
        }

        private Personas LlenaClase()
        {
            Personas pers = new Personas();
            pers.PersonaId = Convert.ToInt32(PersonaIDTex.Text);
            pers.Nombre = NombreTex.Text;
            pers.Telefono = TelefonoTex.Text;
            pers.Cedula = CedulaTex.Text;
            pers.Direccion = DireccionTex.Text;
            pers.FechaNacimiento = FechaNacimientoDatePicke.DisplayDate;
        }

        private void ___NuevoButton__Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void ___GuardaButton__Click(object sender, RoutedEventArgs e)
        {
            Personas persona;
            bool paso = false;
            if (!Validar())
                return;

            persona = LlenaClase();

            if (PersonaIDTex.Text =="0")//tengo que terminar
                paso = PersonaBLL.Guardar(persona);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar una persona que no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = PersonaBLL.Modificar(persona);
            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardar!!", "Exito", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Personas persona = PersonaBLL.Buscar((int)Convert.ToInt32(PersonaIDTex));
            return (persona != null);
        }
        
        private void ___EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(PersonaIDTex.Text,out id); 

            Limpiar();
            if (PersonaBLL.Eliminar(id))
                MessageBox.Show("Eliminar", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void Validar()
        {

        }

        private void ___BuscarButton__Click(object sender, RoutedEventArgs e)
        {
            int id;
            Personas persona = new Personas();
            int.TryParse(PersonaIDTex.Text, out id);

            Limpiar();
            persona = PersonaBLL.Buscar(id);
            if(persona != null)
            {
                MessageBox.Show("persona encontrada");
                LlenaClase(persona);

            }
            else
            {
                MessageBox.Show("persona no encontrada");
            }
        }   
        
         
    }
}
