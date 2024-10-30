using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace aula13_MTMPostgreSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                // Adicionando Pessoas e Habilidades (Relacionamento N:N)
                var pessoa1 = new Pessoa { Nome = "Maria" };
                var pessoa2 = new Pessoa { Nome = "José" };

                var habilidade1 = new Habilidade { Nome = "Programação" };
                var habilidade2 = new Habilidade { Nome = "Design" };

                pessoa1.Habilidades.Add(habilidade1);
                pessoa1.Habilidades.Add(habilidade2);

                pessoa2.Habilidades.Add(habilidade1); // José também tem a habilidade de programação
                
                // adiciona as instâncias de Pessoa (neste caso, pessoa1 e pessoa2) ao DbSet Pessoas do contexto de dados.
                // AddRange é um método que permite adicionar múltiplas instâncias de uma entidade de uma só vez.
                context.Pessoas.AddRange(pessoa1, pessoa2);
                // adiciona as instâncias de Habilidade (neste caso, habilidade1 e habilidade2) ao DbSet Habilidades do contexto de dados.
                // habilidade1 e habilidade2 serão preparadas para serem salvas na tabela Habilidades.
                context.Habilidades.AddRange(habilidade1, habilidade2);
                // salva as mudanças pendentes no banco de dados. 
                // executa as operações que foram preparadas anteriormente, como a adição de pessoa1, pessoa2, habilidade1 e habilidade2.
                context.SaveChanges();

                // Consultando
                var pessoas = context.Pessoas.Include(p => p.Habilidades).ToList();
                foreach (var pessoa in pessoas)
                {
                    Console.WriteLine($"Pessoa: {pessoa.Nome}");
                    foreach (var habilidade in pessoa.Habilidades)
                    {
                        Console.WriteLine($"Habilidade: {habilidade.Nome}");
                    }
                }
            }
        }
    }
}
