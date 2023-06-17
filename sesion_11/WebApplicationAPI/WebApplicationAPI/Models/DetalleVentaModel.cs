using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationAPI.Models
{
    [Table("detalle_venta")]
    public class DetalleVentaModel
    {
        public int id { get; set; }
        public int producto_id { get; set; }
        public int venta_id { get; set; }
        public double precio { get; set; }
    }
}
