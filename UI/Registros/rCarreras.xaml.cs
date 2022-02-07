using System.Windows;
using RegistroCarreras.Entidades;
using RegistroCarreras.BLL;

namespace RegistroCarreras.UI.Registros
{
    public partial class rCarreras : Window
    {
        private Carreras carrera = new Carreras();

        public rCarreras()
        {
            InitializeComponent();

            this.DataContext = carrera;
        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = this.carrera;
        }

        private void Limpiar()
        {
            this.carrera = new Carreras();
            this.DataContext = carrera;
        }

        private bool Validar()
        {
            bool esValido = true;

            if (string.IsNullOrWhiteSpace(carrera.Nombre))
            {
                esValido = false;
                NombreTextBox.Focus();
                MessageBox.Show("Debe indicar el Nombre de la carrera!", "Validación", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return esValido;
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var encontrado = CarrerasBLL.Buscar(this.carrera.CarreraId);

            if (encontrado != null)
            {
                this.carrera = encontrado;
                Cargar();

            }
            else
            {
                Limpiar();
                MessageBox.Show("No se encontro el libro!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }


        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
             if(CarrerasBLL.BuscarCarrera(NombreTextBox.Text) || NombreTextBox.Text == "")
            {
                MessageBox.Show("Ya Existe ", "Fallo",
                MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if(CarrerasBLL.BuscarCarrera(NombreTextBox.Text))
                {
                    MessageBox.Show("Solo puede haber una sola carrera de este tipo", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else{
                bool paso = false;
                if (!Validar())
                return;

                paso = CarrerasBLL.Guardar(carrera);

            if (paso)
                MessageBox.Show("Carrera guardado con éxito", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("No se pudo guardar Carrera", "Fallo", MessageBoxButton.OK, MessageBoxImage.Information);

                };

        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (CarrerasBLL.Eliminar(carrera.CarreraId))
            {
                Limpiar();
                MessageBox.Show("Carrera eliminada con éxito", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No se pudo eliminar la Carrera", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}