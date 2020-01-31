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
            PersonaIDTex.Text = "0";
        }
       private void Limpiar()
        {
            PersonaIDTex.Text = string.Empty;
            NombreTex.Text = string.Empty;
            TelefonoTex.Text = string.Empty;
            CedulaTex.Text = string.Empty;
            DireccionTex.Text = string.Empty;
            FechaNacimientoDatePicke.SelectedDate = DateTime.Now;
            InscripcionTex.Text ="0";
            PagoTex.Text = "0";
            BalanceTex.Text = "0";
            PersonaIDTex.Text = "0";
        }

        private  Personas LlenaClase()
        {
           Personas persona = new Personas();
           persona.PersonaId = Convert.ToInt32(PersonaIDTex.Text);
           persona.Nombre = NombreTex.Text;
           persona.Telefono = TelefonoTex.Text;
           persona.Cedula = CedulaTex.Text;
           persona.Direccion = DireccionTex.Text;
           persona.FechaNacimiento = FechaNacimientoDatePicke.DisplayDate;
           persona.Inscripcion = Convert.ToDouble(InscripcionTex.Text);
           persona.Pago = Convert.ToDouble(PagoTex);
           persona.Balance = Convert.ToDouble(BalanceTex);
           return persona;
        }

        private void LlenaCampo(Personas persona)
        {
            PersonaIDTex.Text = Convert.ToString(persona.PersonaId);
            NombreTex.Text = persona.Nombre;
            TelefonoTex.Text = persona.Telefono;
            CedulaTex.Text = persona.Cedula;
            DireccionTex.Text = persona.Direccion;
            FechaNacimientoDatePicke.SelectedDate = persona.FechaNacimiento;
            InscripcionTex.Text = Convert.ToString(persona.Inscripcion);
            PagoTex.Text = Convert.ToString(persona.Pago);
            BalanceTex.Text = Convert.ToString(persona.Balance);
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

            if (Convert.ToInt32(PersonaIDTex.Text)==0)
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
                MessageBox.Show("Guardado!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Personas persona = PersonaBLL.Buscar(Convert.ToInt32(PersonaIDTex.Text));
            return (persona != null);
        }   
        
        private void ___EliminarButton_Click(object sender, RoutedEventArgs e)//El metodo Eliminar Persona 
        {
            int id;
            int.TryParse(PersonaIDTex.Text,out id); 

            Limpiar();
            if (PersonaBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private bool Validar()//Se valindan los campos para no cometer errore al llenarlos 
        {
            bool paso = true;
            

            if(PersonaIDTex.Text== "")
            {
                MessageBox.Show("El Campo ID no puede estar vacio");
                PersonaIDTex.Focus();
                paso = false;
            }
            if (NombreTex.Text== string.Empty)
            {
                MessageBox.Show("El Campo nombre no puede estar vacio");
                NombreTex.Focus();
                paso = false;
            }
            if(TelefonoTex.Text == string.Empty)
            {
                MessageBox.Show("El campo telefono no puede estar vacio");
                TelefonoTex.Focus();
                paso = false;

            }
            if(CedulaTex.Text == string.Empty)
            {
                MessageBox.Show("El campo cedula no pude estar vacio");
                CedulaTex.Focus();
                paso = false;

            }
            if(DireccionTex.Text == string.Empty)
            {
                MessageBox.Show("El campo direcion no puede estar vacio");
                DireccionTex.Focus();
                paso = false;
            }
            if(InscripcionTex.Text == "0" )
            {
                MessageBox.Show("El campo Inscripcion no puede ser cero..");
                InscripcionTex.Focus();
                paso = false;
                   
            }
            if(PagoTex.Text == "0")
            {
                MessageBox.Show("Debe de pagar antes de hacer otra Inscripcion...");
                PagoTex.Focus();
                paso = false;
            }

            return paso;           
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
                
                LlenaCampo(persona);
            }
            else
            {
                MessageBox.Show("Persona NO Encontrada...");
            }
        }                
    }
}
