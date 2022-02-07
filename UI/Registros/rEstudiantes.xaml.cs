using System.Windows;
using RegistroEstudiantes.Entidades;
using RegistroEstudiantes.BLL;

namespace RegistroEstudiantes.UI.Registros
{
    public partial class rEstudiantes : Window
    {
        private Estudiantes estudiante = new Estudiantes();

        public rEstudiantes()
        {
            InitializeComponent();

            this.DataContext = estudiante;
        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = this.estudiante;
        }

        private void Limpiar()
        {
            this.estudiante = new Estudiantes();
            this.DataContext = estudiante;
        }

        private bool Validar()
        {
            bool esValido = true;

            if (string.IsNullOrWhiteSpace(estudiante.Nombres))
            {
                esValido = false;
                txtNombres.Focus();
                MessageBox.Show("Debe indicar el Nombre de la carrera!", "Validación", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return esValido;
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var encontrado = EstudiantesBLL.Buscar(this.estudiante.EstudianteId);

            if (encontrado != null)
            {
                this.estudiante = encontrado;
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
             if(EstudiantesBLL.BuscarEstudiante(int.Parse(txtEstudianteId.Text)) || txtEstudianteId.Text == "")
            {
                MessageBox.Show("Ya Existe ", "Fallo",
                MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if(EstudiantesBLL.BuscarEstudiante(int.Parse(txtEstudianteId.Text)))
                {
                    MessageBox.Show("Ya existe", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else{
                bool paso = false;
                if (!Validar())
                return;
            if(Ckbox.IsChecked == true){
                estudiante.Activo ="si";
            }
            else{
                    estudiante.Activo = "no";
                }

                paso = EstudiantesBLL.Guardar(estudiante);

            if (paso)
                MessageBox.Show("Estudiante guardado con éxito", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("No se pudo guardar Estudiante", "Fallo", MessageBoxButton.OK, MessageBoxImage.Information);

                };

        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (EstudiantesBLL.Eliminar(estudiante.EstudianteId))
            {
                Limpiar();
                MessageBox.Show("Carrera eliminada con éxito", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No se pudo eliminar la Carrera", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}