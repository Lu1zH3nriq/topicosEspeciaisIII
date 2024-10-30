namespace aula13_MTMPostgreSQL
{
    public class Pessoa
    {
        public int PessoaId { get; set; }
        public string Nome { get; set; } = string.Empty;

        public List<Habilidade> Habilidades { get; set; } = new List<Habilidade>(); // Relacionamento N:N
    }
}
