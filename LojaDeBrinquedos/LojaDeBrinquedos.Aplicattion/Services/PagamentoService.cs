using LojaDeBrinquedos.Domain.Entities;
using LojaDeBrinquedos.Domain.Interfaces;
using static LojaDeBrinquedos.API.Services.PedidoService;

namespace LojaDeBrinquedos.API.Services;

public class PagamentoService : IPagamentoService
{
    public readonly string _connectionString;

    public PagamentoService(IConfiguration configuration)
    {
        _connectionString = configuration.ConnectionString("MinhaConexaoSQL");
    }

    private readonly List<Pagamento> _pagamentos;


    public IEnumerable<Pagamento> ObterTodosPagamentos()
    {
        return _pagamentos;
    }

    public Pagamento ObterPagamentoPorId(int id)
    {
        return _pagamentos.FirstOrDefault(p => p.Id == id);
    }

    public void AdicionarPagamento(Pagamento pagamento)
    {
        if (pagamento == null) throw new ArgumentNullException(nameof(pagamento));
        if (_pagamentos.Any(p => p.Id == pagamento.Id)) throw new InvalidOperationException("Pagamento já existe.");

        _pagamentos.Add(pagamento);
    }

    public void AtualizarPagamento(Pagamento pagamento)
    {
        if (pagamento == null) throw new ArgumentNullException(nameof(pagamento));
        var existingPagamento = ObterPagamentoPorId(pagamento.Id);
        if (existingPagamento == null) throw new InvalidOperationException("Pagamento não encontrado.");

        existingPagamento.PedidoId = pagamento.PedidoId;
        existingPagamento.Valor = pagamento.Valor;
        // Atualize outras propriedades se houver
    }

    public void RemoverPagamento(int id)
    {
        var pagamento = ObterPagamentoPorId(id);
        if (pagamento == null) throw new InvalidOperationException("Pagamento não encontrado.");

        _pagamentos.Remove(pagamento);
    }

    public Task<IEnumerable<Pagamento>> ObterTodosAsync()
    {
        throw new NotImplementedException();
    }

    IEnumerable<Pagamento> IPagamentoService.ObterTodosPagamentos()
    {
        throw new NotImplementedException();
    }

    Pagamento IPagamentoService.ObterPagamentoPorId(int id)
    {
        throw new NotImplementedException();
    }

}