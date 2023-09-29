using Microsoft.EntityFrameworkCore;
using upsideCakes.Models;

namespace upsideCakes.Data;

public class UpsideCakesDbContext : DbContext
{
    public DbSet<Usuario>? Usuario { get; set; }
    public DbSet<Pessoa>? Pessoa { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(connectionString: "DataSource=upsideCakes.db;Cache=Shared;");
    }
}