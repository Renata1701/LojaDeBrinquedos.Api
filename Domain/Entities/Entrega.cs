namespace LojaDeBrinquedos.API.Domain.Entities;

public class Entrega
{
    public int Id { get; set; }
    public int PedidoId { get; set; }
    public DateTime DataEntrega { get; set; }
    public string Status { get; set; }
    public string EnderecoEntrega { get; set; }
    public string Transportadora { get; set; }
    public Entrega(int id, int pedidoId, DateTime dataEntrega, string status, string enderecoEntrega, string transportadora)
    {
        Id = id;
        PedidoId = pedidoId;
        DataEntrega = dataEntrega;
        Status = status;
        EnderecoEntrega = enderecoEntrega;
        Transportadora = transportadora;
    }

}