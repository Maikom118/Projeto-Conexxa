namespace ProjetoConexxa.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string EmailInstitucional { get; set; }
        public string Curso { get; set; }
        public int Periodo { get; set; }
        public string Senha { get; set; }
    }
}