namespace LojaDeBrinquedos.Domain.Entities;

public class RelatorioDeEstoque
{
    public int ProdutoId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public decimal Preco { get; set; }
    public decimal ValorTotalVendido { get; set; }
}
