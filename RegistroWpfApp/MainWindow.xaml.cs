using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RegistroWpfApp.UI;
using RegistroWpfApp.UI.Registros;
using RegistroWpfApp.UI.Cosultas;


namespace RegistroWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ConsultaMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (ConsultaMain.SelectedIndex)
            {
                case 0:
                    RegistroEstudiante ro = new RegistroEstudiante();
                    ro.Show();
                    break;
                case 1:
                    RegistroInscripcion inscricion = new RegistroInscripcion();
                    inscricion.Show();
                    break;
                case 2:
                    Consultar aa = new Consultar();
                    aa.Show();
                    break;
                case 3:
                    ConsultarInscripcion conInscripcio = new ConsultarInscripcion();
                    conInscripcio.Show();
                    break;
            }
        }
    }
}
