using LojaDeBrinquedos.API.Domain.Entities;

namespace LojaDeBrinquedos.API.Domain.Interfaces;

public interface IItensCompradosService
{
    void AdicionarItem(ItensComprados item);
    IEnumerable<ItensComprados> ObterTodosItens();
    ItensComprados ObterItemPorId(int id);
    void AtualizarItem(ItensComprados item);
    void RemoverItem(int id);
}
