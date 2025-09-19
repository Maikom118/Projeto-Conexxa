using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Projeto_Conexxa.Models;

namespace Projeto_Conexxa.Controllers
{
    [Route("Grupos")]
    [ApiController]
    public class GrupoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GrupoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Grupos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GrupoDeEstudo>>> GetGrupos()
        {
            return await _context.GruposDeEstudo.ToListAsync();
        }

        // GET: Grupos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GrupoDeEstudo>> GetGrupo(int id)
        {
            var grupo = await _context.GruposDeEstudo.FindAsync(id);

            if (grupo == null)
            {
                return NotFound();
            }

            return grupo;
        }

        // POST: Grupos
        [HttpPost]
        public async Task<ActionResult<GrupoDeEstudo>> CreateGrupo(GrupoDeEstudo grupo)
        {
            _context.GruposDeEstudo.Add(grupo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGrupo), new { id = grupo.Id }, grupo);
        }

        // PUT: Grupos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGrupo(int id, GrupoDeEstudo grupo)
        {
            if (id != grupo.Id)
            {
                return BadRequest();
            }

            _context.Entry(grupo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GrupoExists(id))
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

        // DELETE: Grupos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrupo(int id)
        {
            var grupo = await _context.GruposDeEstudo.FindAsync(id);
            if (grupo == null)
            {
                return NotFound();
            }

            _context.GruposDeEstudo.Remove(grupo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GrupoExists(int id)
        {
            return _context.GruposDeEstudo.Any(e => e.Id == id);
        }
    }
}