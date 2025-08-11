namespace LojaDeBrinquedos.API.Domain.Entities;

public class ItensComprados
{
    internal object ClienteId;
    internal object DataCompra;
    internal object CompraEstoqueId;

    public int Id { get; set; } 
    public int PedidoId { get; set; }
    public int ProdutoId { get; set; }
    public int Quantidade { get; set; }
    public decimal PrecoUnitario { get; set; }
    public ItensComprados(int id, int pedidoId, int produtoId, int quantidade, decimal precoUnitario, object clienteId, object dataCompra)
    {
        Id = id;
        PedidoId = pedidoId;
        ProdutoId = produtoId;
        Quantidade = quantidade;
        PrecoUnitario = precoUnitario;
        ClienteId = clienteId;
        DataCompra = dataCompra;
    }

    internal static object? GetAll()
    {
        throw new NotImplementedException();
    }

    internal static object FirstOrDefault(Func<object, bool> value)
    {
        throw new NotImplementedException();
    }

    internal static void Remove(object item)
    {
        throw new NotImplementedException();
    }
}
