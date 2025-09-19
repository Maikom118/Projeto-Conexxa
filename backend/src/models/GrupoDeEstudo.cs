using System.Collections.Generic;

namespace ProjetoConexxa.Models
{
    public class GrupoDeEstudo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(100)]
        public string Curso { get; set; }

        [Required]
        [Range(1, 10)]
        public int Periodo { get; set; }

        public List<Aluno> Membros { get; set; }

        public string FotoPerfilUrl { get; set; }


        public string Descricao { get; set; }

        public GrupoDeEstudo()
        {
            Membros = new List<Aluno>();
        }
    }
}