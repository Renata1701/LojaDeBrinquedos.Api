using LojaDeBrinquedos.API.Models;

namespace LojaDeBrinquedos.API.Services;

public class PagamentoService
{
    private readonly List<Pagamento> _pagamentos = new();

    public void RegistrarPagamento(Pagamento pagamento) => _pagamentos.Add(pagamento);

    public List<Pagamento> Listar() => _pagamentos;
}
