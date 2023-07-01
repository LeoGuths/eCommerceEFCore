using eCommerce.Models.FluentAPI.Configurations;
using eCommerce.Models.FluentAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Models.FluentAPI;

public class EcommerceFluentContext : DbContext
{
    public EcommerceFluentContext(DbContextOptions<EcommerceFluentContext> options) : base(options)
    {
    }
     
    public DbSet<Usuario>? Usuarios { get; set; }
    public DbSet<Contato>? Contatos { get; set; }
    public DbSet<EnderecoEntrega>? EnderecosEntrega { get; set; }
    public DbSet<Departamento>? Departamentos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Explicações CAP 7
        
        // modelBuilder.Entity<Usuario>().ToTable("TB_USUARIOS");
        // modelBuilder.Entity<Usuario>().Property(x => x.Rg)
        //     .HasColumnName("REGISTRO_GERAL")
        //     .HasMaxLength(7)
        //     .HasDefaultValue("0000000")
        //     .IsRequired();
        // // modelBuilder.Entity<Usuario>().Ignore(x => x.Sexo);
        // modelBuilder.Entity<Usuario>().Property(x => x.Id).ValueGeneratedOnAdd();
        // modelBuilder.Entity<Usuario>().HasIndex(x => x.Cpf)
        //     .IsUnique()
        //     .HasFilter($"[{nameof(Usuario.Cpf)}] is not null")
        //     .HasDatabaseName("IX_CPF_UNIQUE");
        // modelBuilder.Entity<Usuario>().HasIndex(x => new { x.Cpf, x.Email });
        // modelBuilder.Entity<Usuario>().HasKey(x => x.Id);
        // modelBuilder.Entity<Usuario>()
        //     .HasOne(x => x.Contato)
        //     .WithOne(y => y.Usuario)
        //     .HasForeignKey<Contato>(z => z.UsuarioId)
        //     .OnDelete(DeleteBehavior.Cascade);
        // modelBuilder.Entity<Usuario>()
        //     .HasMany(x => x.EnderecosEntrega)
        //     .WithOne(y => y.Usuario)
        //     .HasForeignKey(z => z.UsuarioId)
        //     .OnDelete(DeleteBehavior.Cascade);
        // modelBuilder.Entity<Usuario>()
        //     .HasMany(x => x.Departamentos)
        //     .WithMany(y => y.Usuarios);
        
        #endregion

        modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
    }
}