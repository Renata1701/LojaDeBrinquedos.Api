namespace LojaDeBrinquedos.API.Domain.Entities;

public class Pedido
{
    private int v1;
    private int v2;
    private DateTime now;
    private decimal v3;
    private string v4;
    internal object Produtos;

    public int Id { get; set; }
    public int LojaId { get; set; }
    public int ClienteId { get; set; }
    public DateTime DataPedido { get; set; }
    public decimal ValorTotal { get; set; }
    public string Status { get; set; }

    public Pedido(int id, int lojaId, int clienteId, DateTime dataPedido, decimal valorTotal, string status)
    {
        Id = id;
        LojaId = lojaId;
        ClienteId = clienteId;
        DataPedido = dataPedido;
        ValorTotal = valorTotal;
        Status = status;
    }

    public Pedido(int v1, int v2, DateTime now, decimal v3, string v4)
    {
        this.v1 = v1;
        this.v2 = v2;
        this.now = now;
        this.v3 = v3;
        this.v4 = v4;
    }

    public Pedido(int v1, int v2, DateTime now, decimal v3)
    {
        this.v1 = v1;
        this.v2 = v2;
        this.now = now;
        this.v3 = v3;
    }
}
