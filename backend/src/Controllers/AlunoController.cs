using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using backend.src.Models;

namespace backend.src.Controllers
{
    [ApiController]
    [Route("Aluno")]
    public class AlunoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AlunoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Aluno>> GetAll()
        {
            return Ok(_context.Alunos.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<Aluno> GetById(int id)
        {
            var aluno = _context.Alunos.Find(id);
            if (aluno == null)
                return NotFound();
            return Ok(aluno);
        }

        [HttpPost]
        public ActionResult<Aluno> Create([FromBody] Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = aluno.Id }, aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Aluno updatedAluno)
        {
            var aluno = _context.Alunos.Find(id);
            if (aluno == null)
                return NotFound();

            aluno.Nome = updatedAluno.Nome;
            aluno.Email = updatedAluno.Email;
            // Add other properties as needed

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _context.Alunos.Find(id);
            if (aluno == null)
                return NotFound();

            _context.Alunos.Remove(aluno);
            _context.SaveChanges();
            return NoContent();
        }
    }
}