using Microsoft.EntityFrameworkCore;

namespace SistemaDeNotas.Data
{
    //Banco de dados
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        // Tabela nota aluno 
        public DbSet<NotaAluno> NotasAlunos { get; set; } = default!;
    }

    public class NotaAluno
    {
        public int Id { get; set; }
        public string NomeAluno { get; set; } = string.Empty;
        public double Dic1 { get; set; }
        public double Dic2 { get; set; }
        public double Dic3 { get; set; }
        public double Dic4 { get; set; }
        public double Dic5 { get; set; }
        public double PresencaPercentual { get; set; }

        public double CalcularMedia() => (Dic1 + Dic2 + Dic3 + Dic4 + Dic5) / 5;
    }
}
