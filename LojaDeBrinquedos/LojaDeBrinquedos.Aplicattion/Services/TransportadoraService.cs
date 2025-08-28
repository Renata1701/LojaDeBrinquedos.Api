using LojaDeBrinquedos.Aplicattion.Interfaces;
using static LojaDeBrinquedos.API.Services.PedidoService;

namespace LojaDeBrinquedos.API.Services;

public class TransportadoraService : ITransportadoraService
{
    private readonly string _connectionString;

    public TransportadoraService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("MinhaConexaoSQL");
    }

    private readonly List<TransportadoraService> _transportadoras;
    private object Id;
    private object Nome;
    private object Telefone;

    public void AdicionarTransportadora(TransportadoraService transportadora)
    {
        if (transportadora == null)
            throw new ArgumentNullException(nameof(transportadora));

        if (_transportadoras.Any(t => t.Id == transportadora.Id))
            throw new InvalidOperationException("Transportadora já existe.");

        _transportadoras.Add(transportadora);
    }

    public IEnumerable<TransportadoraService> ObterTodasTransportadoras()
    {
        return _transportadoras;
    }

    public TransportadoraService ObterTransportadoraPorId(int id)
    {
        return _transportadoras.FirstOrDefault(t => Id == id);
    }

    public void AtualizarTransportadora(TransportadoraService transportadora)
    {
        var existente = ObterTransportadoraPorId((int)transportadora.Id);
        if (existente == null)
            throw new InvalidOperationException("Transportadora não encontrada.");

        existente.Nome = transportadora.Nome;
        existente.Telefone = transportadora.Telefone;
        
    }

    public void RemoverTransportadora(int id)
    {
        var transportadora = ObterTransportadoraPorId(id);
        if (transportadora == null)
            throw new InvalidOperationException("Transportadora não encontrada.");

        _transportadoras.Remove(transportadora);
    }

    IEnumerable<ITransportadoraService> ITransportadoraService.ObterTodasTransportadoras()
    {
        throw new NotImplementedException();
    }

    ITransportadoraService ITransportadoraService.ObterTransportadoraPorId(int id)
    {
        throw new NotImplementedException();
    }

    void ITransportadoraService.AdicionarTransportadora(ITransportadoraService transportadora)
    {
        throw new NotImplementedException();
    }

    void ITransportadoraService.AtualizarTransportadora(ITransportadoraService transportadora)
    {
        throw new NotImplementedException();
    }
}