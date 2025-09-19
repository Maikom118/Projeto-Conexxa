using System.Collections.Generic;
using System.Threading.Tasks;
using Projeto_Conexxa.backend.src.Models;
using Projeto_Conexxa.backend.src.Repositories;

namespace Projeto_Conexxa.backend.src.Services
{
    public class AlunoService
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoService(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public async Task<IEnumerable<Aluno>> GetAllAsync()
        {
            return await _alunoRepository.GetAllAsync();
        }

        public async Task<Aluno> GetByIdAsync(int id)
        {
            return await _alunoRepository.GetByIdAsync(id);
        }

        public async Task<Aluno> CreateAsync(Aluno aluno)
        {
            return await _alunoRepository.CreateAsync(aluno);
        }

        public async Task<bool> UpdateAsync(int id, Aluno aluno)
        {
            var existingAluno = await _alunoRepository.GetByIdAsync(id);
            if (existingAluno == null)
                return false;

            aluno.Id = id;
            await _alunoRepository.UpdateAsync(aluno);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existingAluno = await _alunoRepository.GetByIdAsync(id);
            if (existingAluno == null)
                return false;

            await _alunoRepository.DeleteAsync(id);
            return true;
        }
    }
}