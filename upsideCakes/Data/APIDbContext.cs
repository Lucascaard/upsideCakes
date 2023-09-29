using upsideCakes.Models;
using Microsoft.EntityFrameworkCore;


namespace upsideCakes.Data;

public class APIDbContext : DbContext
{

    public DbSet<Gerente> Gerente { get; set; }
    public DbSet<Pagamento> Pagamento { get; set; }


    public DbSet<Produto> Produto { get; set; }
    public DbSet<Cardapio> Cardapio { get; set; }
    public DbSet<Cliente> Cliente { get; set; }
    public DbSet<Funcionario> Funcionario { get; set; }
    public DbSet<Pedido> Pedido { get; set; }
    public DbSet<Pessoa> Pessoa { get; set; }
    public DbSet<Usuario> Usuario { get; set; }



    //EXPLICAÇÃO
    /*
     O código que você forneceu parece ser uma parte de uma classe de contexto do Entity Framework, especificamente para configuração de acesso a um banco de dados SQLite. Vou explicar as partes desse código:

    public DbSet<Produto>? Produto { get; set; }:

    public DbSet<Produto>: Isso declara uma propriedade pública chamada Produto do tipo DbSet<Produto>. Um DbSet é uma coleção que representa uma tabela no banco de dados. Nesse caso, a classe Produto representa a entidade (ou tabela) que você pode consultar e manipular por meio dessa propriedade.
    ?: O ponto de interrogação (?) após DbSet<Produto> indica que a propriedade pode ser nula (nullable). Isso significa que, se a tabela Produto não existir no banco de dados, a propriedade Produto será nula.
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder):

    Este método é uma parte da classe de contexto do Entity Framework e é usado para configurar as opções de conexão com o banco de dados.
    DbContextOptionsBuilder optionsBuilder: O parâmetro optionsBuilder é um objeto que permite configurar várias opções de contexto, incluindo a configuração de provedores de banco de dados e cadeias de conexão.
    optionsBuilder.UseSqlite(connectionString: "DataSource=upsideCakes.db;Cache=Shared"):

    optionsBuilder.UseSqlite(...): Isso configura o provedor SQLite para ser usado com o Entity Framework.
    connectionString: "DataSource=upsideCakes.db;Cache=Shared": Aqui, você está especificando a cadeia de conexão para o banco de dados SQLite. A cadeia de conexão contém informações sobre onde encontrar o banco de dados e, neste caso, é "upsideCakes.db". A opção "Cache=Shared" é usada para configurar o cache compartilhado para o banco de dados SQLite.
    Em resumo, esse código faz parte da configuração de um contexto do Entity Framework para acessar um banco de dados SQLite chamado "upsideCakes.db". Ele declara uma propriedade Produto que permite o acesso à tabela Produto no banco de dados e configura as opções de conexão com o SQLite por meio do método OnConfiguring. Com essa configuração, você pode usar o contexto para consultar e manipular os dados da tabela Produto no banco de dados SQLite.
     */
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(connectionString: "DataSource=upsideCakes.db;Cache=Shared");
    }
    //EXPLICAÇÃO
    /*
     O código que você forneceu faz parte do método OnModelCreating de uma classe de contexto do Entity Framework. Este método é usado para configurar o mapeamento entre objetos C# e tabelas de banco de dados. Vou dar uma breve explicação linha por linha:

    modelBuilder.Entity<MinhaClasse>(): Esta linha começa a configuração para a classe de modelo MinhaClasse. Ela informa ao Entity Framework que você deseja definir configurações específicas para essa entidade.

    .HasKey(x => x.Id): Esta linha define a chave primária para a entidade MinhaClasse. Ela informa que a propriedade Id da classe é a chave primária. A chave primária é usada para identificar exclusivamente cada registro na tabela correspondente no banco de dados.

    .HasAnnotation("Sqlite:Autoincrement", true): Esta linha configura uma anotação para a propriedade Id da entidade. Nesse caso, a anotação "Sqlite:Autoincrement" é usada para informar ao SQLite (o banco de dados utilizado) que o valor da coluna Id deve ser autoincrementado. Isso significa que o SQLite irá gerar automaticamente valores crescentes para a coluna Id sempre que um novo registro for inserido na tabela. Isso é comum para campos de chave primária que devem ser únicos e incrementados automaticamente.

    Em resumo, esse trecho de código está configurando a classe de modelo MinhaClasse para que o Entity Framework saiba que a propriedade Id é a chave primária e que deve ser autoincrementada pelo SQLite quando novos registros são inseridos na tabela correspondente. Isso garante que cada registro tenha um ID exclusivo e crescente, o que é uma prática comum em bancos de dados.
     */

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Produto>()
            .HasKey(x => x.Id)
            .HasAnnotation("Sqlite:Autoincrement", true);
        //deixar o cpf do gerente sendo unico
        modelBuilder.Entity<Gerente>()
            .HasIndex(c => c._cpfGerente)
            .IsUnique();
    }
}
