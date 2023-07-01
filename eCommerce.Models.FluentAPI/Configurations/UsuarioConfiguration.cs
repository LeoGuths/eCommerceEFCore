using eCommerce.Models.FluentAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eCommerce.Models.FluentAPI.Configurations;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("TB_USUARIOS");
        
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Rg)
            // .HasColumnName("REGISTRO_GERAL")
            .HasMaxLength(7)
            .HasDefaultValue("0000000")
            .IsRequired();
        // modelBuilder.Entity<Usuario>().Ignore(x => x.Sexo);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        
        builder.HasIndex(x => x.Cpf)
            .IsUnique()
            .HasFilter($"[{nameof(Usuario.Cpf)}] is not null")
            .HasDatabaseName("IX_CPF_UNIQUE");
        builder.HasIndex(x => new { x.Cpf, x.Email });
        
        builder.HasOne(x => x.Contato)
            .WithOne(y => y.Usuario)
            .HasForeignKey<Contato>(z => z.UsuarioId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(x => x.EnderecosEntrega)
            .WithOne(y => y.Usuario)
            .HasForeignKey(z => z.UsuarioId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(x => x.Departamentos)
            .WithMany(y => y.Usuarios);
    }
}