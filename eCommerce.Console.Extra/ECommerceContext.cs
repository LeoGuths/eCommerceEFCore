using eCommerce.Console.Extra.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Console.Extra;

public class ECommerceContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data source=(localdb)\\MSSQLLocalDB;Initial Catalog=eCommerce;Integrated Security=True;");
    }
    
    public DbSet<Usuario>? Usuarios { get; set; }
    public DbSet<Contato>? Contatos { get; set; }
    public DbSet<EnderecoEntrega>? EnderecosEntrega { get; set; }
    public DbSet<Departamento>? Departamentos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>().HasQueryFilter(x => x.SituacaoCadastro == 'A');
        // modelBuilder.Entity<Usuario>().Property(x => x.SituacaoCadastro).HasConversion<string>();
    }
}