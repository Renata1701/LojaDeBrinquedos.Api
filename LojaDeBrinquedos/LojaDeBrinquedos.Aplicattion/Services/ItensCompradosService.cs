using LojaDeBrinquedos.Aplicattion.Interfaces;
using LojaDeBrinquedos.Domain.Entities;
using static LojaDeBrinquedos.API.Services.PedidoService;

namespace LojaDeBrinquedos.API.Services;

public class ItensCompradosService : IItensCompradosService
{
    private readonly string _connectionString;

    public ItensCompradosService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("MinhaConexaoSQL");
    }

    private readonly List<ItensComprados> _itens;


    public void AdicionarItem(ItensComprados item)
    {
        if (item == null)
            throw new ArgumentNullException(nameof(item));

        if (_itens.Any(i => i.Id == item.Id))
            throw new InvalidOperationException("Item já existe.");

        _itens.Add(item);
    }

    public IEnumerable<ItensComprados> ObterTodosItens()
    {
        return _itens;
    }

    public ItensComprados ObterItemPorId(int id)
    {
        return _itens.FirstOrDefault(i => i.Id == id);
    }

    public void AtualizarItem(ItensComprados item)
    {
        var existente = ObterItemPorId(item.Id);
        if (existente == null)
            throw new InvalidOperationException("Item não encontrado.");

        existente.ProdutoId = item.ProdutoId;
        existente.PedidoId = item.PedidoId;
        existente.Quantidade = item.Quantidade;
        existente.PrecoUnitario = item.PrecoUnitario;
    }

    public void RemoverItem(int id)
    {
        var item = ObterItemPorId(id);
        if (item == null)
            throw new InvalidOperationException("Item não encontrado.");

        _itens.Remove(item);
    }

    public IEnumerable<ItensComprados> ObterTodosItensComprados()
    {
        throw new NotImplementedException();
    }

    public void AdicionarItensComprados(ItensComprados itensComprados)
    {
        throw new NotImplementedException();
    }

    public void AtualizarItensComprados(ItensComprados itensComprados)
    {
        throw new NotImplementedException();
    }

    public void RemoverItensComprados(int id)
    {
        throw new NotImplementedException();
    }
}