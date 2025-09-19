using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Controllers
{
    [ApiController]
    [Route("administrador")]
    public class AdministradorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AdministradorController(AppDbContext context)
        {
            _context = context;
        }

        // POST: administrador/create
        [HttpPost("create")]
        public async Task<ActionResult<Administrador>> Create([FromBody] Administrador administrador)
        {
            _context.Administradores.Add(administrador);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = administrador.Id }, administrador);
        }

        // GET: administrador/all
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Administrador>>> GetAll()
        {
            return Ok(await _context.Administradores.ToListAsync());
        }

        // GET: administrador/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Administrador>> GetById(int id)
        {
            var administrador = await _context.Administradores.FindAsync(id);
            if (administrador == null)
                return NotFound();
            return Ok(administrador);
        }

        // PUT: administrador/update/{id}
        [HttpPut("update/{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Administrador updatedAdministrador)
        {
            var administrador = await _context.Administradores.FindAsync(id);
            if (administrador == null)
                return NotFound();

            administrador.Nome = updatedAdministrador.Nome;
            administrador.Email = updatedAdministrador.Email;
            // Atualize outros campos conforme necessário

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: administrador/delete/{id}
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var administrador = await _context.Administradores.FindAsync(id);
            if (administrador == null)
                return NotFound();

            _context.Administradores.Remove(administrador);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}