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
using RegistroCarreras.UI.Registros;
using RegistroCarreras.UI.Consultas;
using RegistroEstudiantes.UI.Registros;
using RegistroEstudiantes.UI.Consultas;

namespace RegistroCarreras
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

        private void RegistroCarrerasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var rCarreras = new rCarreras();
            rCarreras.Show();

        }

        private void ConsultaCarrerasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var cCarreras = new cCarreras();
            cCarreras.Show();
            
        }
        private void RegistroEstudiantesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var rEstudiantes = new rEstudiantes();
            rEstudiantes.Show();

        }

        private void ConsultaEstudiantesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var cEstudiantes = new cEstudiantes();
            cEstudiantes.Show();

        }

        
    }
}
