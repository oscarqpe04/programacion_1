using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationAPI.Models;

namespace WebApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public VentaController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/Venta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VentaModel>>> GetventasCollection()
        {
          if (_context.ventasCollection == null)
          {
              return NotFound();
          }
            return await _context.ventasCollection.ToListAsync();
        }

        // GET: api/Venta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VentaModel>> GetVentaModel(int id)
        {
          if (_context.ventasCollection == null)
          {
              return NotFound();
          }
            var ventaModel = await _context.ventasCollection.FindAsync(id);

            if (ventaModel == null)
            {
                return NotFound();
            }

            return ventaModel;
        }

        // PUT: api/Venta/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVentaModel(int id, VentaModel ventaModel)
        {
            if (id != ventaModel.id)
            {
                return BadRequest();
            }

            _context.Entry(ventaModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentaModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Venta
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VentaModel>> PostVentaModel(VentaModel ventaModel)
        {
          if (_context.ventasCollection == null)
          {
              return Problem("Entity set 'ApplicationDBContext.ventasCollection'  is null.");
          }
            _context.ventasCollection.Add(ventaModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVentaModel", new { id = ventaModel.id }, ventaModel);
        }

        // DELETE: api/Venta/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVentaModel(int id)
        {
            if (_context.ventasCollection == null)
            {
                return NotFound();
            }
            var ventaModel = await _context.ventasCollection.FindAsync(id);
            if (ventaModel == null)
            {
                return NotFound();
            }

            _context.ventasCollection.Remove(ventaModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VentaModelExists(int id)
        {
            return (_context.ventasCollection?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
