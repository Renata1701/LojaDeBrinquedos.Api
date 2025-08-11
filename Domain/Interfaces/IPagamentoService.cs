using LojaDeBrinquedos.API.Domain.Entities;

namespace LojaDeBrinquedos.API.Domain.Interfaces;

public interface IPagamentoService
{
    Task<IEnumerable<Pagamento>> ObterTodosAsync();
    Task<Pagamento> ObterPorIdAsync(int id);
    Task<Pagamento> AdicionarAsync(Pagamento pagamento);
    Task<Pagamento> AtualizarAsync(Pagamento pagamento);
    Task<bool> ExcluirAsync(int id);
}
