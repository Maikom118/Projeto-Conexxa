using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projeto_Conexxa.src.Models;

namespace Projeto_Conexxa.src.Services
{
    public class GrupoService
    {
        private readonly AppDbContext _context;

        public GrupoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Grupo>> GetAllAsync()
        {
            return await _context.Grupos.ToListAsync();
        }

        public async Task<Grupo> GetByIdAsync(int id)
        {
            return await _context.Grupos.FindAsync(id);
        }

        public async Task<Grupo> CreateAsync(Grupo grupo)
        {
            _context.Grupos.Add(grupo);
            await _context.SaveChangesAsync();
            return grupo;
        }

        public async Task<bool> UpdateAsync(int id, Grupo grupo)
        {
            var existingGrupo = await _context.Grupos.FindAsync(id);
            if (existingGrupo == null)
                return false;

            existingGrupo.Nome = grupo.Nome;
            existingGrupo.Descricao = grupo.Descricao;
            // Adicione outros campos conforme o model

            _context.Grupos.Update(existingGrupo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var grupo = await _context.Grupos.FindAsync(id);
            if (grupo == null)
                return false;

            _context.Grupos.Remove(grupo);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}