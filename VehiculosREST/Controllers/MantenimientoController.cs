using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehiculosREST.Data;
using VehiculosREST.Models;

namespace VehiculosREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MantenimientoController : ControllerBase
    {
        private readonly VehiculosDbContext _context;

        public MantenimientoController(VehiculosDbContext context)
        {
            _context = context;
        }

        // GET: api/Mantenimiento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mantenimiento>>> ObtenerMantenimientos()
        {
            var mantenimientos = await _context.Mantenimientos
                .AsNoTracking()
                .Include(m => m.Vehiculo)
                    .ThenInclude(v => v.Categoria)
                .OrderBy(m => m.IdMantenimiento)
                .ToListAsync();

            return Ok(mantenimientos);
        }

        // GET: api/Mantenimiento/1
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Mantenimiento>> ObtenerMantenimiento(int id)
        {
            var mantenimiento = await _context.Mantenimientos
                .AsNoTracking()
                .Include(m => m.Vehiculo)
                    .ThenInclude(v => v.Categoria)
                .FirstOrDefaultAsync(m => m.IdMantenimiento == id);

            if (mantenimiento == null)
                return NotFound(new { mensaje = "Mantenimiento no encontrado" });

            return Ok(mantenimiento);
        }

        // GET: api/Mantenimiento/vehiculo/1
        [HttpGet("vehiculo/{idVehiculo:int}")]
        public async Task<ActionResult<IEnumerable<Mantenimiento>>> ObtenerMantenimientosPorVehiculo(int idVehiculo)
        {
            var vehiculoExiste = await _context.Vehiculos
                .AsNoTracking()
                .AnyAsync(v => v.IdVehiculo == idVehiculo);

            if (!vehiculoExiste)
                return NotFound(new { mensaje = "Vehículo no encontrado" });

            var mantenimientos = await _context.Mantenimientos
                .AsNoTracking()
                .Include(m => m.Vehiculo)
                    .ThenInclude(v => v.Categoria)
                .Where(m => m.IdVehiculo == idVehiculo)
                .OrderBy(m => m.IdMantenimiento)
                .ToListAsync();

            return Ok(mantenimientos);
        }

        // POST: api/Mantenimiento
        [HttpPost]
        public async Task<ActionResult<Mantenimiento>> AgregarMantenimiento(Mantenimiento mantenimiento)
        {
            var vehiculoExiste = await _context.Vehiculos
                .AsNoTracking()
                .AnyAsync(v => v.IdVehiculo == mantenimiento.IdVehiculo);

            if (!vehiculoExiste)
                return NotFound(new { mensaje = "El vehículo no existe" });

            mantenimiento.IdMantenimiento = 0;

            if (mantenimiento.Fecha == default)
                mantenimiento.Fecha = DateTime.Now;

            _context.Mantenimientos.Add(mantenimiento);

            await _context.SaveChangesAsync();

            var mantenimientoCreado = await _context.Mantenimientos
                .AsNoTracking()
                .Include(m => m.Vehiculo)
                    .ThenInclude(v => v.Categoria)
                .FirstOrDefaultAsync(m => m.IdMantenimiento == mantenimiento.IdMantenimiento);

            return Ok(mantenimientoCreado);
        }

        // PUT: api/Mantenimiento/1
        [HttpPut("{id:int}")]
        public async Task<IActionResult> ActualizarMantenimiento(
            int id,
            Mantenimiento mantenimiento)
        {
            var mantenimientoActual = await _context.Mantenimientos
                .FirstOrDefaultAsync(m => m.IdMantenimiento == id);

            if (mantenimientoActual == null)
                return NotFound(new { mensaje = "Mantenimiento no encontrado" });

            var vehiculoExiste = await _context.Vehiculos
                .AsNoTracking()
                .AnyAsync(v => v.IdVehiculo == mantenimiento.IdVehiculo);

            if (!vehiculoExiste)
                return NotFound(new { mensaje = "El vehículo no existe" });

            mantenimientoActual.Fecha = mantenimiento.Fecha;
            mantenimientoActual.Tipo = mantenimiento.Tipo;
            mantenimientoActual.Descripcion = mantenimiento.Descripcion;
            mantenimientoActual.Costo = mantenimiento.Costo;
            mantenimientoActual.Kilometraje = mantenimiento.Kilometraje;
            mantenimientoActual.Estado = mantenimiento.Estado;
            mantenimientoActual.IdVehiculo = mantenimiento.IdVehiculo;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Mantenimiento/1
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> EliminarMantenimiento(int id)
        {
            var mantenimiento = await _context.Mantenimientos
                .FindAsync(id);

            if (mantenimiento == null)
                return NotFound(
                    new { mensaje = "Mantenimiento no encontrado" });

            _context.Mantenimientos.Remove(mantenimiento);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}