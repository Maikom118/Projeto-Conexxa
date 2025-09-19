using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Services
{
    public class AdministradorService
    {
        private readonly AppDbContext _context;

        public AdministradorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Administrador>> GetAllAsync()
        {
            return await _context.Administradores.ToListAsync();
        }

        public async Task<Administrador> GetByIdAsync(int id)
        {
            return await _context.Administradores.FindAsync(id);
        }

        public async Task<Administrador> CreateAsync(Administrador administrador)
        {
            _context.Administradores.Add(administrador);
            await _context.SaveChangesAsync();
            return administrador;
        }

        public async Task<bool> UpdateAsync(int id, Administrador administrador)
        {
            var existing = await _context.Administradores.FindAsync(id);
            if (existing == null)
                return false;

            existing.Nome = administrador.Nome;
            existing.Email = administrador.Email;
            // Adicione outros campos conforme o seu model

            _context.Administradores.Update(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var administrador = await _context.Administradores.FindAsync(id);
            if (administrador == null)
                return false;

            _context.Administradores.Remove(administrador);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}