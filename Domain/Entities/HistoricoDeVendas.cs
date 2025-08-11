namespace LojaDeBrinquedos.API.Domain.Entities;

public class HistoricoDeVendas
{
    private int v1;
    private int v2;
    private DateTime now;
    private decimal v3;
    private string v4;

    public int Id { get; set; }
    public int ProdutoId { get; set; }
    public int QuantidadeVendida { get; set; }
    public decimal ValorTotal { get; set; }
    public DateTime DataVenda { get; set; }
    public HistoricoDeVendas(int id, int produtoId, int quantidadeVendida, decimal valorTotal, DateTime dataVenda)
    {
        Id = id;
        ProdutoId = produtoId;
        QuantidadeVendida = quantidadeVendida;
        ValorTotal = valorTotal;
        DataVenda = dataVenda;
    }

    public HistoricoDeVendas(int v1, int v2, DateTime now, decimal v3, string v4)
    {
        this.v1 = v1;
        this.v2 = v2;
        this.now = now;
        this.v3 = v3;
        this.v4 = v4;
    }
}
