using System.ComponentModel.DataAnnotations;

namespace RegistroEstudiantes.Entidades
{
    public class Estudiantes
    {
        [Key]
        public int EstudianteId { get; set; }
        public string ?Nombres { get; set; }
        public string ?Email { get; set; }
        public string ?CarreraId { get; set; }
        public string ?Activo { get; set; }
    }
}