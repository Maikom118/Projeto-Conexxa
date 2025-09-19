namespace ProjetoConexxa.Models
{
    public class Aluno
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string NomeCompleto { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string EmailInstitucional { get; set; }

        [Required]
        [MaxLength(100)]
        public string Curso { get; set; }

        [Required]
        [Range(1, 10)]
        public int Periodo { get; set; }

        [Required]
        [MinLength(6)]
        public string Senha { get; set; }
    }
}