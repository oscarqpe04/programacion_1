using WebApplicationAPI.Models;
using WebApplicationAPI.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace WebApplicationAPI.Service
{
    public class VentaService : IVentaService
    {
        private readonly IVentaRepository ventaRepository;
        private readonly IDetalleVentaRepository detalleVentaRepository;
        private readonly IProductoRepository productoRepository;
        public VentaService(IVentaRepository ventaRepository, IDetalleVentaRepository detalleVentaRepository, IProductoRepository productoRepository)
        {
            this.ventaRepository = ventaRepository;
            this.detalleVentaRepository = detalleVentaRepository;
            this.productoRepository = productoRepository;
        }

        public void RealizarVenta(VentaModel venta)
        {
            // iniciar bloque Transaccion
            try
            {
                // validar disponibilidad de producto
                foreach (var detalle in venta.detallesVenta)
                {
                    var validarDisponibilidad = productoRepository.EstaDisponible(detalle.producto_id);
                    if (!validarDisponibilidad)
                    {
                        return;
                    }
                }

                ventaRepository.CrearVenta(venta);
                foreach (var detalle in venta.detallesVenta)
                {
                    detalleVentaRepository.Crear(detalle);
                }
                // commit
            }
            catch (Exception ex)
            {
                // rollback
            }
            finally
            {

            }
            // fin bloque transaccion
        }

        public void DevolverVenta(VentaModel venta)
        {
            // facturacionRepository
            // ventaRepository
            // productoRepository
            // transaccion
        }
    }
}
