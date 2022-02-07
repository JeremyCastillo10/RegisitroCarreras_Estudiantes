using System.Windows;
using RegistroCarreras.Entidades;
using RegistroCarreras.BLL;
using System.Linq;
using System.Collections.Generic;

namespace RegistroCarreras.UI.Consultas
{
    public partial class cCarreras : Window
    {

        public cCarreras()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Carreras>();

            if (string.IsNullOrWhiteSpace(CriterioTextBox.Text))         
                listado = CarrerasBLL.GetList(l => true);
            else
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //"ID"
                        //listado =   CarrerasBLL.GetList(l => l.CarreraId.Contains(CriterioTextBox.Text));
                        break;
                    case 1:   //"Nombre" 
                        listado = CarrerasBLL.GetList(l => l.Nombre.Contains(CriterioTextBox.Text));
                        break;
                }
            }

            CarrerasDataGrid.ItemsSource = null;
            CarrerasDataGrid.ItemsSource = listado;

        }

    }
}
