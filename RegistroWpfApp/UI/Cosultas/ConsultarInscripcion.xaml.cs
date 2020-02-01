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
    /// Interaction logic for ConsultarInscripcion.xaml
    /// </summary>
    public partial class ConsultarInscripcion : Window
    {
        public ConsultarInscripcion()
        {
            InitializeComponent();
        }

        private void ConsultarButto_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Inscripciones>();

            if (CriterioTexBox.Text.Trim().Length > 0)
            {
                switch (FiltrarComBox.SelectedIndex)
                {
                    case 0:
                        listado = InscripcionBLL.GetLis(prop => true);
                        break;

                    case 1:
                        int id = Convert.ToInt32(CriterioTexBox.Text);
                        listado = InscripcionBLL.GetLis(p => p.InscripcionId == id);
                        break;                          
                    default:
                        MessageBox.Show("No existe esa opción en el Filtro");
                        break;

                }
                listado = listado.Where(c => c.Fecha.Date >= DesdeDateTimePcker.SelectedDate.Value && c.Fecha.Date <= HastaDateTimePicker.SelectedDate.Value).ToList();

            }
            else
            {
                listado = InscripcionBLL.GetLis(p => true);

            }
            
            ConsultaDateGridView.ItemsSource = null;
            ConsultaDateGridView.ItemsSource = listado;
        }
    }
}

