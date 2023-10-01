using Microsoft.EntityFrameworkCore;
using upsideCakes.Models;

namespace upsideCakes.Data;

public class UpsideCakesDbContext : DbContext
{

    public DbSet<Produto> Produto { get; set; }
    public DbSet<Pagamento> Pagamento {  get; set; }
    public DbSet<Funcionario> Funcionario { get; set; }
    public DbSet<Gerente> Gerente { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(connectionString: "DataSource=upsideCakes.db;Cache=Shared;");
    }
    /*
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pessoa>()
                .HasNoKey();
    }
    */

}

