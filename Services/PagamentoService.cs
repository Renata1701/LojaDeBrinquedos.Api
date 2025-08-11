using LojaDeBrinquedos.API.Domain.Entities;
using LojaDeBrinquedos.API.Domain.Interfaces;
using Microsoft.Data.SqlClient;

namespace LojaDeBrinquedos.API.Services;

public class PagamentoService : IPagamentoService
{
    private readonly string _connectionString;

    public PagamentoService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("MinhaConexaoSQL");
    }

    private readonly List<Pagamento> _pagamentos;

    public PagamentoService()
    {
        _pagamentos = new List<Pagamento>
        {
            
            new Pagamento(1, 1, DateTime.Now, 200.00m) 
        };
    }

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

    public Task<Pagamento> ObterPorIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Pagamento> AdicionarAsync(Pagamento pagamento)
    {
        throw new NotImplementedException();
    }

    public Task<Pagamento> AtualizarAsync(Pagamento pagamento)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExcluirAsync(int id)
    {
        throw new NotImplementedException();
    }
}