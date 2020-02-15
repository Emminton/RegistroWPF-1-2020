using RegistroWpfApp.BLL;
using RegistroWpfApp.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RegistroWpfApp.UI.Cosultas
{
    /// <summary>
    /// Interaction logic for Consultar.xaml
    /// </summary>
    public partial class Consultar : Window
    {
        public Consultar()
        {
            InitializeComponent();
        }
        private void ConsultarButto_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Estudiantes>();

            if (CriterioTexBox.Text.Trim().Length > 0)
            {
                switch (FiltrarComBox.SelectedIndex)
                {
                    case 0:
                        listado = EstudianteBLL.GetList(prop => true);
                        break;

                    case 1:
                        int id = Convert.ToInt32(CriterioTexBox.Text);
                        listado = EstudianteBLL.GetList(p => p.EstudianteId == id);
                        break;

                    case 2:
                        listado = EstudianteBLL.GetList(p => p.Nombre.Contains(CriterioTexBox.Text));
                        break;

                    case 3:
                        listado = EstudianteBLL.GetList(p => p.Direccion.Contains(CriterioTexBox.Text));
                        break;

                    case 4:
                        listado = EstudianteBLL.GetList(p => p.Telefono.Contains(CriterioTexBox.Text));
                        break;

                    case 5:
                        listado = EstudianteBLL.GetList(p => p.Cedula.Contains(CriterioTexBox.Text));
                        break;
                   
                }
                listado = listado.Where(c => c.FechaNacimiento.Date >= DesdeDateTimePcker.SelectedDate.Value && c.FechaNacimiento.Date <= HastaDateTimePicker.SelectedDate.Value).ToList();

            }
            else
            {
                listado = EstudianteBLL.GetList(p => true);

            }
            
            ConsultaDateGridView.ItemsSource = null;
            ConsultaDateGridView.ItemsSource = listado;
        }
    }
}

    
           
