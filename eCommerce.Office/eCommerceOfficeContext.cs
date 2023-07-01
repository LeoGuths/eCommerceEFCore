using eCommerce.Office.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Office;

public class ECommerceOfficeContext : DbContext
{
    public DbSet<Colaborador>? Colaboradores { get; set; }
    public DbSet<ColaboradorSetor>? ColaboradoresSetores { get; set; }
    public DbSet<Setor>? Setores { get; set; }
    public DbSet<Turma>? Turmas { get; set; }
    public DbSet<Veiculo>? Veiculos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=eCommerceOffice;");
    }
}