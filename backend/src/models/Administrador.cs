using System.ComponentModel.DataAnnotations;

namespace ProjetoConexxa.Models
{
    public class Administrador
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
        public string AreaFormacao { get; set; }

        [Required]
        public string[] CursosMinistrados { get; set; }

        [Required]
        [MinLength(6)]
        public string Senha { get; set; }
    }
}