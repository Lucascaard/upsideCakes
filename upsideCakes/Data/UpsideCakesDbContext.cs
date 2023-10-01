using Microsoft.EntityFrameworkCore;
using upsideCakes.Models;

namespace upsideCakes.Data;

public class UpsideCakesDbContext : DbContext
{
    public DbSet<Usuario>? Usuario { get; set; }
    public DbSet<Pessoa>? Pessoa { get; set; }

    public DbSet<Produto> Produto { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(connectionString: "DataSource=upsideCakes.db;Cache=Shared;");
    }

    //EXPLICAÇÃO
    /*
     O código que você forneceu faz parte do método OnModelCreating de uma classe de contexto do Entity Framework. Este método é usado para configurar o mapeamento entre objetos C# e tabelas de banco de dados. Vou dar uma breve explicação linha por linha:

    modelBuilder.Entity<MinhaClasse>(): Esta linha começa a configuração para a classe de modelo MinhaClasse. Ela informa ao Entity Framework que você deseja definir configurações específicas para essa entidade.

    .HasKey(x => x.Id): Esta linha define a chave primária para a entidade MinhaClasse. Ela informa que a propriedade Id da classe é a chave primária. A chave primária é usada para identificar exclusivamente cada registro na tabela correspondente no banco de dados.

    .HasAnnotation("Sqlite:Autoincrement", true): Esta linha configura uma anotação para a propriedade Id da entidade. Nesse caso, a anotação "Sqlite:Autoincrement" é usada para informar ao SQLite (o banco de dados utilizado) que o valor da coluna Id deve ser autoincrementado. Isso significa que o SQLite irá gerar automaticamente valores crescentes para a coluna Id sempre que um novo registro for inserido na tabela. Isso é comum para campos de chave primária que devem ser únicos e incrementados automaticamente.

    Em resumo, esse trecho de código está configurando a classe de modelo MinhaClasse para que o Entity Framework saiba que a propriedade Id é a chave primária e que deve ser autoincrementada pelo SQLite quando novos registros são inseridos na tabela correspondente. Isso garante que cada registro tenha um ID exclusivo e crescente, o que é uma prática comum em bancos de dados.
     

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Produto>()
            .HasKey(x => x.Id)
            .HasAnnotation("Sqlite:Autoincrement", true);
    }
    */
}

