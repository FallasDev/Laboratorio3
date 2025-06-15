using System.ComponentModel.DataAnnotations;

namespace Laboratorio3.Models
{
    public class Classroom
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public int Capacidad { get; set; }

        [Required]
        public bool TieneAireAcondicionado { get; set; }

    }
}
