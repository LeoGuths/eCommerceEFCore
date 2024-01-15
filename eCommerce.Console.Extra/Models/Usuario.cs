namespace eCommerce.Console.Extra.Models;

public sealed class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    public string Email { get; set; } = null!;
    public char? Sexo { get; set; }
    public string Cpf { get; set; } = null!;
    public string? Rg { get; set; }
    public string? NomeMae { get; set; }
    public string? NomePai { get; set; }
    public char? SituacaoCadastro { get; set; }
    public DateTimeOffset DataCadastro { get; set; }
    public Contato? Contato { get; set; }
    public ICollection<EnderecoEntrega>? EnderecosEntrega { get; set; }
    public ICollection<Departamento>? Departamentos { get; set; }
}