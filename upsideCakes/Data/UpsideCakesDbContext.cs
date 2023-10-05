using Microsoft.EntityFrameworkCore;
using upsideCakes.Models;

namespace upsideCakes.Data;

public class UpsideCakesDbContext : DbContext
{
    public DbSet<Cardapio> Cardapio { get; set; }
    public DbSet<Cliente> Cliente { get; set; }
    public DbSet<Funcionario> Funcionario { get; set; }
    public DbSet<Gerente> Gerente { get; set; }
    public DbSet<Pagamento> Pagamento { get; set; }
    public DbSet<Pedido> Pedido { get; set; }
    public DbSet<Produto> Produto { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(connectionString: "DataSource=upsideCakes.db;Cache=Shared;");
    }
}
