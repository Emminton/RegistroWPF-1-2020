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
    /// Interaction logic for RegistroEstudiante.xaml
    /// </summary>
    public partial class RegistroEstudiante : Window
    {
        public RegistroEstudiante()
        {
            InitializeComponent();
            EstudianteIDTex.Text = "0";
            BalanceTex.Text = "0";
        }
       private void Limpiar()
        {
            EstudianteIDTex.Text = string.Empty;
            NombreTex.Text = string.Empty;
            TelefonoTex.Text = string.Empty;
            CedulaTex.Text = string.Empty;
            DireccionTex.Text = string.Empty;
            FechaNacimientoDatePicke.SelectedDate = DateTime.Now;
            BalanceTex.Text = "0";        
            EstudianteIDTex.Text = "0";
        }

        private  Estudiantes LlenaClase()                                    
        {
           Estudiantes estudiante = new Estudiantes();
           estudiante.EstudianteId = Convert.ToInt32(EstudianteIDTex.Text);
           estudiante.Nombre = NombreTex.Text;
           estudiante.Telefono = TelefonoTex.Text;
           estudiante.Cedula = CedulaTex.Text;
           estudiante.Direccion = DireccionTex.Text;
           estudiante.FechaNacimiento = FechaNacimientoDatePicke.DisplayDate;
           estudiante.Balance = Convert.ToDecimal(BalanceTex.Text);
           return estudiante;
        }

        private void LlenaCampo(Estudiantes estudiantes)
        {
            EstudianteIDTex.Text = Convert.ToString(estudiantes.EstudianteId);
            NombreTex.Text = estudiantes.Nombre;
            TelefonoTex.Text = estudiantes.Telefono;
            CedulaTex.Text = estudiantes.Cedula;
            DireccionTex.Text = estudiantes.Direccion;
            FechaNacimientoDatePicke.SelectedDate = estudiantes.FechaNacimiento;
            BalanceTex.Text = Convert.ToString(estudiantes.Balance);
        }

        private void ___NuevoButton__Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void ___GuardaButton__Click(object sender, RoutedEventArgs e)
        {
            Estudiantes persona;
            bool paso = false;
            if (!Validar())
                return;

            persona = LlenaClase();

            if (Convert.ToInt32(EstudianteIDTex.Text)==0)
                paso = EstudianteBLL.Guardar(persona);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                   MessageBox.Show("No se puede modificar una persona que no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = EstudianteBLL.Modificar(persona);
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
            Estudiantes persona = EstudianteBLL.Buscar(Convert.ToInt32(EstudianteIDTex.Text));
            return (persona != null);
        }   
        
        private void ___EliminarButton_Click(object sender, RoutedEventArgs e)//El metodo Eliminar Persona 
        {
            int id;
            int.TryParse(EstudianteIDTex.Text,out id); 

            Limpiar();
            if (EstudianteBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private bool Validar()//Se valindan los campos para no cometer errore al llenarlos 
        {
            bool paso = true;
            

            if(EstudianteIDTex.Text== "")
            {
                MessageBox.Show("El Campo ID no puede estar vacio");
                EstudianteIDTex.Focus();
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
          
            return paso;           
        }
        private void ___BuscarButton__Click(object sender, RoutedEventArgs e)
        {
            int id;
            Estudiantes estudiantes = new Estudiantes();
            int.TryParse(EstudianteIDTex.Text, out id);

            Limpiar();
            estudiantes = EstudianteBLL.Buscar(id);
            if(estudiantes != null)
            {
                
                LlenaCampo(estudiantes);
            }
            else
            {
                MessageBox.Show("Persona NO Encontrada...");
            }
        }                
    }
}
