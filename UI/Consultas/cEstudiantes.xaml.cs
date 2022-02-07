using System.Windows;
using RegistroEstudiantes.Entidades;
using RegistroEstudiantes.BLL;
using System.Linq;
using System.Collections.Generic;

namespace RegistroEstudiantes.UI.Consultas
{
    public partial class cEstudiantes : Window
    {

        public cEstudiantes()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Estudiantes>();

            if (string.IsNullOrWhiteSpace(CriterioTextBox.Text))         
                listado = EstudiantesBLL.GetList(l => true);
            else
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //"ID"
                        //listado =   CarrerasBLL.GetList(l => l.CarreraId.Contains(CriterioTextBox.Text));
                        break;
                    case 1:  
                        listado = EstudiantesBLL.GetList(l => l.Nombres.Contains(CriterioTextBox.Text));
                        break;
                    case 2:    
                        listado = EstudiantesBLL.GetList(l => l.Email.Contains(CriterioTextBox.Text));
                        break;
                }
            }

            EstudiantesDataGrid.ItemsSource = null;
            EstudiantesDataGrid.ItemsSource = listado;

        }

    }
}