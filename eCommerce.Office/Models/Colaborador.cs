namespace eCommerce.Office.Models;

public sealed class Colaborador
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    public ICollection<Veiculo>? Veiculos { get; set; }
    public ICollection<Setor>? Setores { get; set; }
    public ICollection<Turma>? Turmas { get; set; }
}