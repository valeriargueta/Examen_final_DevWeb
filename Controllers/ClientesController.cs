using ClienteAPI.Data;
using ClienteAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClienteAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly ClienteContext _context;

        public ClientesController(ClienteContext context)
        {
            _context = context;
        }

        // Endpoint para obtener todos los clientes
        [HttpGet("ListadoGeneral")]
        public async Task<IActionResult> ListadoGeneral()
        {
            var clientes = await _context.Clientes
                .OrderBy(c => c.Apellidos)
                .ThenBy(c => c.FechaNacimiento)
                .ToListAsync();

            return Ok(clientes);
        }
    }
}
