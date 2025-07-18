namespace LojaDeBrinquedos.API.Models;

public class Pagamento
{
    private int v1;
    private int v2;
    private DateTime now;
    private string v3;
    private string v4;

    public int Id { get; set; }
    public int PedidoId { get; set; }
    public decimal Valor { get; set; }
    public string Metodo { get; set; }
    public DateTime DataPagamento { get; set; }
    public string Status { get; set; }
    public Pagamento(int id, int pedidoId, decimal valor, string metodo, DateTime dataPagamento, string status)
    {
        Id = id;
        PedidoId = pedidoId;
        Valor = valor;
        Metodo = metodo;
        DataPagamento = dataPagamento;
        Status = status;
    }

    public Pagamento(int v1, int v2, DateTime now, string v3, string v4)
    {
        this.v1 = v1;
        this.v2 = v2;
        this.now = now;
        this.v3 = v3;
        this.v4 = v4;
    }
}
