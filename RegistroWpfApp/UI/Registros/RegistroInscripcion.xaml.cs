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
    /// Interaction logic for Inscripcion.xaml
    /// </summary>
    public partial class RegistroInscripcion : Window
    {
        public RegistroInscripcion()
        {
            InitializeComponent();
           
            InscripcionIDTex.Text = "0";
            EstudianteIDTex.Text = "0";
        }

        private void Limpiar()
        {
            InscripcionIDTex.Text = string.Empty;
            FechaDatePicker.SelectedDate = DateTime.Now;
            EstudianteIDTex.Text = string.Empty;
            ComentarioTex.Text = string.Empty;
            MontoTex.Text = string.Empty;
            PagoTex.Text = string.Empty;
            BalanceTex.Text = string.Empty;
            InscripcionIDTex.Text = "0";
            EstudianteIDTex.Text = "0";
        }

        private Inscripciones LlenaClase()
        {
            decimal monto, pago, balance ;
        
            Inscripciones inscricion = new Inscripciones();
            inscricion.InscripcionId = Convert.ToInt32(InscripcionIDTex.Text);
            inscricion.Fecha = FechaDatePicker.DisplayDate;
            inscricion.EstudianteId = Convert.ToInt32(EstudianteIDTex.Text);
            inscricion.Comentario = ComentarioTex.Text;
            inscricion.InscripcionBalance = Convert.ToDecimal(MontoTex.Text) - Convert.ToDecimal(PagoTex.Text);
            monto = Convert.ToDecimal(MontoTex.Text);
            pago = Convert.ToDecimal(PagoTex.Text);
            balance = monto - pago;
            inscricion.Monto = monto;
            inscricion.Pago = pago;
            inscricion.InscripcionBalance = balance;
          
            return inscricion;
        }

        public void LlenaCampo(Inscripciones inscripcion)
        {
            InscripcionIDTex.Text = Convert.ToString(inscripcion.InscripcionId);
            FechaDatePicker.SelectedDate = inscripcion.Fecha;
            EstudianteIDTex.Text = Convert.ToString(inscripcion.EstudianteId);
            ComentarioTex.Text = inscripcion.Comentario;
            MontoTex.Text = Convert.ToString(inscripcion.Monto);
            PagoTex.Text = Convert.ToString(inscripcion.Pago);
            BalanceTex.Text = Convert.ToString(inscripcion.InscripcionBalance);
                    
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            Inscripciones inscripcion;
            bool paso = false;
            if (!Validar())
                return;

            inscripcion = LlenaClase();

            if (Convert.ToInt32(InscripcionIDTex.Text) == 0 && ExisteEnLaBaseDeDatosEstudiante() == true)
                paso = InscripcionBLL.Guardar(inscripcion);
            else
            {
                if (!ExisteEnLaBaseDeDatosInscripcion())
                {
                    MessageBox.Show("No se puede modificar una persona que no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = InscripcionBLL.Modificar(inscripcion);
            }
            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Nuevo_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();

        }
        private bool ExisteEnLaBaseDeDatosEstudiante()
        {
            Estudiantes persona = EstudianteBLL.Buscar(Convert.ToInt32(EstudianteIDTex.Text));
            return (persona != null);
        }

        private bool ExisteEnLaBaseDeDatosInscripcion()
        {
            Inscripciones persona = InscripcionBLL.Buscar(Convert.ToInt32(InscripcionIDTex.Text));
            return (persona != null);
        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(InscripcionIDTex.Text, out id);
            int EstudianteId;
            int.TryParse(EstudianteIDTex.Text, out EstudianteId);

            Limpiar();
            if (InscripcionBLL.Eliminar(id, EstudianteId))
                MessageBox.Show("Se Eliminado El Balance", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("No se puede eliminar, porque no existe.");
        }
        private void Buscar_Click(object sender, RoutedEventArgs e)
        {
            int id;
            Inscripciones inscripcion = new Inscripciones();
            int.TryParse(InscripcionIDTex.Text, out id);


            Limpiar();
            inscripcion = InscripcionBLL.Buscar(id);
            if (inscripcion != null)
            {
                LlenaCampo(inscripcion);
            }
            else
            {
                MessageBox.Show("Inscripcion NO Encontrada...");
            }
        }

        private bool Validar()//Se valindan los campos para no cometer errore al llenarlos 
        {
            bool paso = true;

            if (InscripcionIDTex.Text == "")
            {
                MessageBox.Show("El Campo InscripcionID no puede estar vacio");
                EstudianteIDTex.Focus();
                paso = false;
            }
            if (FechaDatePicker.Text == string.Empty)
            {
                MessageBox.Show("El Campo Fecha no puede estar vacio");
                FechaDatePicker.Focus();
                paso = false;
            }
            if (EstudianteIDTex.Text == "")
            {
                MessageBox.Show("El campo EstudianteID no puede estar vacio");
                EstudianteIDTex.Focus();
                paso = false;

            }
            if (ComentarioTex.Text == string.Empty)
            {
                MessageBox.Show("El campo Comentario no pude estar vacio");
                ComentarioTex.Focus();
                paso = false;
            }
            if(PagoTex.Text == "0")
            {
                MessageBox.Show("El Campo Pago no puede estar vacio");
                PagoTex.Focus();
            }
            if (MontoTex.Text == "0")
            {
                MessageBox.Show("El campo Monto no puede estar vacio");
                MontoTex.Focus();
                paso = false;
            }
            
            return paso;
        }

        private void MontoTex_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal monto  = 0;
            decimal pago = 0;

            if (!string.IsNullOrWhiteSpace(MontoTex.Text) && MontoTex.Text != "-")
            {
                monto = decimal.Parse(MontoTex.Text);
            }
            if (!string.IsNullOrWhiteSpace(PagoTex.Text) && PagoTex.Text != "-")
            {
                pago = decimal.Parse(PagoTex.Text);
            }

            decimal resultado = monto - pago;

            BalanceTex.Text = resultado.ToString();
        }

        private void PagoTex_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal monto = 0;
            decimal pago = 0;

            if (!string.IsNullOrWhiteSpace(MontoTex.Text) && MontoTex.Text != "-")
            {
                monto = decimal.Parse(MontoTex.Text);
            }
            if (!string.IsNullOrWhiteSpace(PagoTex.Text) && PagoTex.Text != "-")
            {
                pago = decimal.Parse(PagoTex.Text);
            }

            decimal resultado = monto - pago;

            BalanceTex.Text = resultado.ToString();
        }
       
    }
    
}
