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
            var listado = new List<Personas>();

            if (CriterioTexBox.Text.Trim().Length > 0)
            {

                switch (FiltrarComBox.SelectedIndex)
                {
                    case 0:
                        listado = PersonaBLL.GetList(prop => true);
                        break;

                    case 1:
                        int id = Convert.ToInt32(CriterioTexBox.Text);
                        listado = PersonaBLL.GetList(p => p.PersonaId == id);
                        break;

                    case 2:
                        listado = PersonaBLL.GetList(p => p.Nombre.Contains(CriterioTexBox.Text));
                        break;

                    case 3:
                        listado = PersonaBLL.GetList(p => p.Direccion.Contans(CriterioTexBox.Text));
                        break;

                    case 4:
                        listado = PersonaBLL.GetList(p => p.TelefonoTex.Contains(CriterioTexBox.Text));
                        break;

                    case 5:
                        listado = PersonaBLL.GetList(p => p.CelularTex.Contains(CriterioTexBox.Text));
                        break;


                }


                listado = listado.Where(c => c.FechaNacimiento.Date >= DesdeDateTimePcker.Value.Date && c.FechaNacimiento.Date <= HastaDateTimePicker.Value.Date).ToList();


            }
            else
            {
                listado = PersonaBLL.GetList(p => true);

            }
            ConsultaDateGridView.ItemsSource = listado;
            ConsultaDataGridview.ItemSource = null;

        }
    }
}

    
           
