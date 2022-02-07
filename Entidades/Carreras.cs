using System.ComponentModel.DataAnnotations;

namespace RegistroCarreras.Entidades
{
    public class Carreras
    {
        [Key]
        public int CarreraId { get; set; }
        public string ?Nombre { get; set; }
    }
}