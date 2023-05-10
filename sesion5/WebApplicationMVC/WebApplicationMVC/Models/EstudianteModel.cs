using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationMVC.Models
{
    [Table("estudiante")]
    public class EstudianteModel
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
    }
}
