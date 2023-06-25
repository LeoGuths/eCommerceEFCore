using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Models.DataAnnotations;

[Index(nameof(Email), IsUnique = true, Name = "IX_EMAIL_UNICO")]
[Table(("TB_USUARIOS"))]
public sealed class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    [MaxLength(100)]
    public string Email { get; set; } = null!;
    [Required]
    public char? Sexo { get; set; }
    public string Cpf { get; set; } = null!;
    [Column("REGISTRO_GERAL")]
    public string? Rg { get; set; }
    public string? NomeMae { get; set; }
    public string? NomePai { get; set; }
    public char? SituacaoCadastro { get; set; }
    [NotMapped]
    public bool RegistroAtivo { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Matricula { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTimeOffset DataCadastro { get; set; }
    public Contato? Contato { get; set; }
    public ICollection<EnderecoEntrega>? EnderecosEntrega { get; set; }
    public ICollection<Departamento>? Departamentos { get; set; }
    [InverseProperty("Cliente")]
    public ICollection<Pedido>? PedidosCompradosPeloCliente { get; set; }
    [InverseProperty("Colaborador")]
    public ICollection<Pedido>? PedidosCompradosPeloColaborador { get; set; }
    [InverseProperty("Supervisor")]
    public ICollection<Pedido>? PedidosCompradosPeloColaboradorSupervisor { get; set; }
}