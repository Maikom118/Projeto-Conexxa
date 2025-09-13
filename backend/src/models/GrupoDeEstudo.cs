using System.Collections.Generic;

namespace ProjetoConexxa.Models
{
    public class GrupoDeEstudo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Curso { get; set; }
        public string Periodo { get; set; }
        public List<Aluno> Membros { get; set; }
        public string FotoPerfilUrl { get; set; }
        public string Descricao { get; set; }

        public GrupoDeEstudo()
        {
            Membros = new List<Aluno>();
        }
    }
}