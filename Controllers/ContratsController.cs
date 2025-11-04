using ContactosApi.Data;
using ContactosApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactosApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactosController : ControllerBase
    {
        private readonly ContactosDbContext _context;

        public ContactosController(ContactosDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contacto>>> GetAll() =>
            await _context.Contactos.ToListAsync();

        [HttpPost]
        public async Task<ActionResult<Contacto>> Create(Contacto contacto)
        {
            _context.Contactos.Add(contacto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAll), new { id = contacto.Id }, contacto);
        }

        [HttpGet("buscar")]
        public async Task<ActionResult<IEnumerable<Contacto>>> Filtrar([FromQuery] string nombre) =>
            await _context.Contactos.Where(c => c.Nombre.Contains(nombre)).ToListAsync();
    }
}