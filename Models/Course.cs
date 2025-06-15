using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Laboratorio3.Models
{
    public class Course
    {

        [Required]
        [Key]
        [Display(Name = "Id del Curso")]
        public int Id { get; set; }

        [Required]
        public string? Siglas { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string? Descripcion { get; set; }

        [Required]
        public string? Profesor { get; set; }

        [Required]
        public int EstudiantesMatriculados { get; set; }

        public int AulaId { get; set; }

       
        public Classroom? Aula { get; set; }

    }
}
