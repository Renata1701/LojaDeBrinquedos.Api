namespace LojaDeBrinquedos.API.Models;

public class Frete
{
    public int Id { get; set; }
    public int PedidoId { get; set; }
    public decimal Valor { get; set; }
    public string Tipo { get; set; } 
    public DateTime DataEnvio { get; set; }
    public DateTime DataEntregaEstimada { get; set; }
    public string Status { get; set; } 
    public Frete(int id, int pedidoId, decimal valor, string tipo, DateTime dataEnvio, DateTime dataEntregaEstimada, string v, string status)
    {
        Id = id;
        PedidoId = pedidoId;
        Valor = valor;
        Tipo = tipo;
        DataEnvio = dataEnvio;
        DataEntregaEstimada = dataEntregaEstimada;
        Status = status;
    }
}
